#!/usr/bin/perl -w
#
# File:   	basicdbi.pl
# Author:   Gavin Baker <cgiscripts@endhousesoftware.com>
# Date:     23.08.00
# Updated:  See revision history
#
# -------------------------------------------------------------------------
#
# EXPLANATION
#
# A script to show basic DBI operation
#
# -------------------------------------------------------------------------
#
# REVISION HISTORY
#
# 23.08.00    GDB    Version 1.0
#
# -------------------------------------------------------------------------
#
#   LEGAL NOTICE
# 
# This script may be freely copied, distributed and modified. Use 
# of the script is at the risk of the user. The script is presented 
# "as-is" without any warranty, and the author is not liable for 
# any loss or damages arising out of the use of or failure to use 
# this script. This notice must appear in any modified copy of the 
# script in which the name of the original author also appears.
#
# -------------------------------------------------------------------------
#
# INSTALLING THIS SCRIPT
#
# 1. Check the interpreter line - the very first line of this script to be
#    sure that it contains the correct path to your copy of the Perl
#    interpreter. It should begin with '#!' followed by the full path to
#    the interpreter. If you're not sure where Perl is installed, type:
#
#	      which perl
#
#    at the shell prompt, or ask your administrator.
#
# 2. Make sure that your script is installed in an appropriate place (i.e.
#    the directory where you have installed your other scripts), and has
#    been given the permissions it needs to allow it to be executed as
#    a CGI-bin script.
#
# -------------------------------------------------------------------------
#
      use DBI();

#let the browser know we're coming
&printhtmlhead;

      # Connect to the database.
#      my $dbh = DBI->connect("DBI:mysql:database=endhousesoftware_com;host=localhost",
#                             "endhousesoftware", "links");
#	  die "Unable to connect: $DBI::errstr\n" unless (defined $dbh);

#	  print "$DBI::errstr\n";

#	  $sth = $dbh->prepare(q{SHOW DATABASES}) or 
#        die "Unable to prepare show databases: " . $dbh->errrstr . "\n";
#      $sth->execute or
#        die "Unable to execute show databases: " . $dbh->errrstr . "\n";
#	  while ($aref = $sth->fetchrow_arrayref) {
#		print "Database: $aref->[0]";
#	    print "<BR>\n";  
#	  }
#	  $sth->finish;


      # Disconnect from the database.
#      $dbh->disconnect();

&printhtmlfoot;

#exit script
exit(0);

#prints HTML header
sub printhtmlhead {

   print("Content-type: text/html\n\n");
   print <<EndOfHTML;
<HTML><HEAD><TITLE>title</TITLE></HEAD>
<BODY>
EndOfHTML
;

}

#print HTML footer
sub printhtmlfoot {

  print("</BODY></HTML>\n");
}

sub mdydate() {
#
# send time (integer), delimiter, and format string
# returns nice date
# by default- returns date as MMDDYYYY with no delimiter
# if called as mdydate(time)
#
# e.g
# $nicedate=&mdydate(time,"/","mmddyyyy");
# print "$nicedate\n";
#

 my($in_time,$delim,$format) = @_;
 $format=~tr/[A-Z]/[a-z]/;
 %mn = ('Jan','01', 'Feb','02', 'Mar','03', 'Apr','04',
        'May','05', 'Jun','06', 'Jul','07', 'Aug','08',
        'Sep','09', 'Oct','10', 'Nov','11', 'Dec','12' );

 my $sydate=localtime($in_time);
 my ($day, $month, $num, $time, $year) = split(/\s+/,$sydate);
 my $zl=length($num);
 if ($zl == 1) { 
   $num = "0$num";
 }
 if ($format eq "") { 
   return "$mn{$month}$delim$num$delim$year";  #default MMDDYYYY
 }
 if ($format=~/yyyy/) {
   $year=$year;
 }
  else {
    $year = substr($year,2,2);
  }
 if ($format eq "mmddyyyy") { return "$mn{$month}$delim$num$delim$year";}
 if ($format eq "yyyymmdd") { return "$year$delim$mn{$month}$delim$num";}
 if ($format eq "ddmmyyyy") { return "$num$delim$mn{$month}$delim$year";}
 if ($format eq "mmddyy") { return "$mn{$month}$delim$num$delim$year";}
 if ($format eq "yymmdd") { return "$year$delim$mn{$month}$delim$num";}
 if ($format eq "ddmmyy") { return "$num$delim$mn{$month}$delim$year";}
}
