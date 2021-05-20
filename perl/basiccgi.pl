#let the browser know we're coming
&printhtmlhead;

#read in CGI parameters to %cgiVals
&readparam;   

#check if any arguments
print("Hello world from CGI\n\n");
if (%cgiVals) {
}
else {
}

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

# read parameters
# name/value pairs are in %cgiVals (global) hash
sub readparam {

  if ( ($ENV{'REQUEST_METHOD'} eq 'POST') || ($ENV{'REQUEST_METHOD'} eq 'post') ) {
    read(STDIN, $buffer, $ENV{'CONTENT_LENGTH'});          #read for POST method to $buffer
    @cgiPairs = split(/\&/,$buffer);
  }
  else {
    #get the pairs of parameters passed to the script      for GET method
    @cgiPairs = split(/\&/,$ENV{'QUERY_STRING'}); 
  }

  #split the pairs into a %cgiVals hash
  foreach $pair ( @cgiPairs ) {
       ($var,$val) = split("=",$pair);
       $val =~ s/\+/ /g;
       $val =~ s/%(..)/pack("c",hex($1))/ge;
       $cgiVals{"$var"} = "$val";
  }
}
