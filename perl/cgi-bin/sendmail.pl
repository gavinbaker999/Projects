#!/usr/bin/perl -w
open(OUT,">>logs/sendmail1.log");

$numargs = @ARGV - 1;
print OUT "\nSend Mail 1 - ",scalar(localtime()),"\n";
for ($i = 0;$i <= $numargs;$i++) {
	$arg = $ARGV[$i];
	print OUT "$arg ";
}
close(OUT);
