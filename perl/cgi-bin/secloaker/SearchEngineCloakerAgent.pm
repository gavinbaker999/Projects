
#
# SearchEngineCloakerAgent was HTTP::Lite.pm
#
# $Id: SearchEngineCloakerAgent.pm,v 1.1 2009/04/21 19:10:57 Default Exp $
#
# $Log: SearchEngineCloakerAgent.pm,v $
# Revision 1.1  2009/04/21 19:10:57  Default
# Inital Version
#
# Revision 1.7  2000/12/21 18:05:09  rhooper
# FIxed post form MIME-Type -- was application/x-www-urlencoded should
# have been x-www-form-urlencoded.
#
# Revision 1.6  2000/11/02 01:47:58  rhooper
# Fixed a greedy regular expression in the URL decoder.  URLs with :// embedded now work.
#
# Revision 1.5  2000/10/31 01:27:03  rhooper
# added proxy port support.
#
# Revision 1.4  2000/09/29 03:47:53  rhooper
# Requests without a terminating CR or LF are now properly handled.
# HTTP/1.1 chunked mode transfers are now supported
# Host: headers are properly added to all requests
# Proxy support has been added
# Significant test code updates
#
# Revision 1.3  2000/09/09 18:06:55  rhooper
# Revision 1.2  2000/08/28 02:46:05  rhooper
# Revision 1.1  2000/08/28 02:43:57  rhooper
# Initial revision
#

package SearchEngineCloakerAgent;

use vars qw($VERSION);
use strict qw(vars);

$VERSION = "6.053";
my $CRLF = "\r\n";

# Required modules for Network I/O
use Socket 1.3;
use Fcntl;
use Errno qw(EAGAIN);

# Forward declarations
sub prepare_post;
sub http_writeline;
sub http_readline;

sub new 
{
  my $self = {};
  bless $self;
  $self->initialize();
  return $self;
}

sub initialize
{
  my $self = shift;
  foreach my $var ("body", "request", "content", "status", "proxy",
    "proxyport", "resp-protocol", "error-message", "response", 
    "resp-headers")
  {
    $self->{$var} = undef;
  }
  $self->{method} = "GET";
  $self->{timeout} = 120;
  $self->{headers} = { 'User-Agent' => "SearchEngineCloakerAgent/$VERSION" };
  $self->{HTTPReadBuffer} = "";
}

sub reset
{
  my $self = shift;
  $self->initialize;
}


# URL-encode data
sub escape {
  my $toencode = shift;
  $toencode=~s/([^a-zA-Z0-9_.-])/uc sprintf("%%%02x",ord($1))/eg;
  return $toencode;
}

sub request
{
  my ($self, $url) = @_;
  
  my $method = $self->{method};

  # Parse URL 
  my ($protocol,$host,$junk,$port,$object) = 
    $url =~ m{^([^:/]+)://([^/:]*)(:(\d+))?(/.*)$};

  # Only HTTP is supported here
  if ($protocol ne "http")
  {
    warn "Only http is supported by SearchEngineCloakerAgent";
    return undef;
  }
  
  # Setup the connection
  my $proto = getprotobyname('tcp');
  my $fhname = $url . localtime;
  my $fh = *$fhname;
  socket($fh, PF_INET, SOCK_STREAM, $proto);
  $port = 80 if !$port;

  my $connecthost = $self->{'proxy'} || $host;
  $connecthost = $connecthost ? $connecthost : $host;
  my $connectport = $self->{'proxyport'} || $port;
  $connectport = $connectport ? $connectport : $port;
  my $addr = inet_aton($connecthost);
  if (!$addr) {
    close($fh);
    return undef;
  }
  if ($connecthost ne $host)
  {
    # if proxy active, use full URL as object to request
    $object = "$url";
  }

  my $sin = sockaddr_in($connectport,$addr);
  connect($fh, $sin) || return undef;
  # Set nonblocking IO on the handle to allow timeouts
  if ( $^O ne "MSWin32" ) {
    fcntl($fh, F_SETFL, O_NONBLOCK);
  }

  # Start the request (HTTP/1.1 mode)
  http_writeline($fh, "$method $object HTTP/1.1$CRLF");

  # Add some required headers
  # we only support a single transaction per request in this version.
  $self->add_req_header("Connection", "close");    
  $self->add_req_header("Host", $host);
  $self->add_req_header("Accept", "*/*");
    
  # Output headers
  my $headerref = $self->{headers};
  foreach my $header (keys %$headerref)
  {
    http_writeline($fh, $header.": ".$$headerref{$header}."$CRLF");
  }
  
  # Handle Content-type and Content-Length seperately
  if (defined($self->{content}))
  {
    http_writeline($fh, "Content-Length: ".length($self->{content})."$CRLF");
  }
  http_writeline($fh, "$CRLF");
  
  # Output content, if any
  if (defined($self->{content}))
  {
    http_writeline($fh, $self->{content});
  }
  
  # Read response from server
  my $headmode=1;
  my $chunkmode=undef;
  my $chunksize=0;
  my $chunklength=0;
  my $chunk;
  my $line = 0;
  while ($_ = $self->http_readline($fh))
  {
    #print "reading: $chunkmode, $chunksize, $chunklength, $headmode, ".
    #	length($self->{body}).": //$_//\n";
    $line++;
    if ($line == 1)
    {
      my ($proto,$status,$message) = split(' ', $_, 3);
      $self->{status}=$status;
      $self->{'resp-protocol'}=$proto;
      $self->{'error-message'}=$message;
      next;
    } 
    $self->{response} .= $_;
    if ($_ =~ /^[\r\n]*$/ && ($headmode || $chunkmode eq "entity-header"))
    {
      if ($chunkmode)
      {
        undef $chunkmode;
      }
      $headmode = 0;
      
      # Check for Transfer-Encoding
      my $header = join(' ',@{$self->get_header("Transfer-Encoding")});
      if ($header =~ /chunked/i)
      {
        $chunkmode = "chunksize";
      }
      next;
    }
    if ($headmode || $chunkmode eq "entity-header")
    {
      my ($var,$data) = $_ =~ /^([^:]*):\s*(.*)$/;
      if (defined($var))
      {
        $data =~s/[\r\n]$//g;
        $var = lc($var);
        $var =~ s/^(.)|(-.)/&upper($1,$2)/ge;
        my $hr = ${$self->{'resp-headers'}}{$var};
        if (!ref($hr))
        {
          $hr = [ $data ];
        }
        else 
        {
          push @{ $hr }, $data;
        }
        ${$self->{'resp-headers'}}{$var} = $hr;
      }
    } elsif ($chunkmode)
    {
      if ($chunkmode eq "chunksize")
      {
        $chunksize = $_;
        $chunksize =~ s/^\s*|;.*$//g;
        $chunksize =~ s/\s*$//g;
        $chunksize = hex($chunksize);
        if ($chunksize == 0)
        {
          $chunkmode = "entity-header";
        } else {
          $chunkmode = "chunk";
          $chunklength = 0;
        }
      } elsif ($chunkmode eq "chunk")
      {
        $chunk .= $_;
        $chunklength += length($_);
        if ($chunklength >= $chunksize)
        {
          $chunkmode = "chunksize";
          if ($chunklength > $chunksize)
          {
            $chunk = substr($chunk,0,$chunksize);
          } 
          elsif ($chunklength == $chunksize && $chunk !~ /$CRLF$/) 
          {
            # chunk data is exactly chunksize -- need CRLF still
            $chunkmode = "ignorecrlf";
          }
          $self->{'body'} .= $chunk;
          $chunk="";
          $chunklength = 0;
          $chunksize = "";
        } 
      } elsif ($chunkmode eq "ignorecrlf")
      {
        $chunkmode = "chunksize";
      }
    } else {
      $self->{body}.=$_;
    }
  }
  close($fh);
  return $self->{status};
}

sub add_req_header
{
  my $self = shift;
  my ($header, $value) = @_;
  
  ${$self->{headers}}{$header} = $value;
}

sub get_req_header
{
  my $self = shift;
  my ($header) = @_;
  
  return $self->{headers}{$header};
}

sub delete_req_header
{
  my $self = shift;
  my ($header) = @_;
  
  my $exists;
  if ($exists=defined(${$self->{headers}}{$header}))
  {
    delete ${$self->{headers}}{$header};
  }
  return $exists;
}

sub body
{
  my $self = shift;
  return $self->{body};
}

sub response
{
  my $self = shift;
  return $self->{response};
}

sub status
{
  my $self = shift;
  return $self->{status};
}

sub protocol
{
  my $self = shift;
  return $self->{'resp-protocol'};
}

sub status_message
{
  my $self = shift;
  return $self->{'error-message'};
}

sub proxy
{
  my $self = shift;
  my ($value) = @_;
  
  # Parse URL 
  my ($protocol,$host,$junk,$port,$object) = 
    $value =~ m{^(\S+)://([^/:]*)(:(\d+))?(/.*)$};
  if (!$host)
  {
    ($host,$port) = $value =~ /^([^:]+):(.*)$/;
  }

  $self->{'proxy'} = $host || $value;
  $self->{'proxyport'} = $port || 80;
}

sub headers_array
{
  my $self = shift;
  
  my @array = ();
  
  foreach my $header (keys %{$self->{'resp-headers'}})
  {
    my $aref = ${$self->{'resp-headers'}}{$header};
    foreach my $value (@$aref)
    {
      push @array, "$header: $value";
    }
  }
  return @array;
}

sub headers_string
{
  my $self = shift;
  
  my $string = "";
  
  foreach my $header (keys %{$self->{'resp-headers'}})
  {
    my $aref = ${$self->{'resp-headers'}}{$header};
    foreach my $value (@$aref)
    {
      $string .= "$header: $value\n";
    }
  }
  return $string;
}

sub get_header
{
  my $self = shift;
  my $header = shift;

  return $self->{'resp-headers'}{$header};
}


sub prepare_post
{
  my $self = shift;
  my $varref = shift;
  
  my $body = "";
  while (my ($var,$value) = map { escape($_) } each %$varref)
  {
    if ($body)
    {
      $body .= "&$var=$value";
    } else {
      $body = "$var=$value";
    }
  }
  $self->{content} = $body;
  $self->{headers}{'Content-Type'} = "application/x-www-form-urlencoded"
    unless defined ($self->{headers}{'Content-Type'}) and 
    $self->{headers}{'Content-Type'};
  $self->{method} = "POST";
}

sub http_writeline
{
  my ($fh,$line) = @_;
  syswrite($fh, $line, length($line));
}


sub http_readline
{
  my $self = shift;
  my ($fh, $timeout) = @_;
  my $EOL = "\n";
  
  # is there a line in the buffer yet?
  while ($self->{HTTPReadBuffer} !~ /$EOL/)
  {
    # nope -- wait for incoming data
    my ($inbuf,$bits,$chars) = ("","",0);
    vec($bits,fileno($fh),1)=1;
    my $nfound = select($bits, undef, $bits, $timeout);
    if ($nfound == 0)
    {
      # Timed out
      return undef;
    } else {
      # Get the data
      $chars = sysread($fh, $inbuf, 256);
    }
    # End of stream?
    if ($chars <= 0 && !$!{EAGAIN})
    {
      last;
    }
    # tag data onto end of buffer
    $self->{HTTPReadBuffer}.=$inbuf;
  }
  # get a single line from the buffer
  my $nlat = index($self->{HTTPReadBuffer}, $EOL);
  my $newline;
  my $oldline;
  if ($nlat > -1)
  {
    $newline = substr($self->{HTTPReadBuffer},0,$nlat+1);
    $oldline = substr($self->{HTTPReadBuffer},$nlat+1);
  } else {
    $newline = substr($self->{HTTPReadBuffer},0);
    $oldline = "";
  }
  # and update the buffer
  $self->{HTTPReadBuffer}=$oldline;
  # Put the linefeed back on the line and return it
  return $newline;
}

sub upper
{
  return uc(join("",@_));
}

1;
