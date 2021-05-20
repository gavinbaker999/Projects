use Tk;

#let the browser know we're coming
&printhtmlhead;

#my $mw = MainWindow->new;
#$mw->title("Hello World");
#$mw->Button(-text => "Done", -command=>sub {exit;})->pack;
&printhtmlfoot;
#MainLoop;

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

