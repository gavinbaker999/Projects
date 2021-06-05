#!/usr/bin/perl -w
use Time::Local;
open(OUT,">>logs/cron1.log");

$numargs = @ARGV - 1;
print OUT "\nCron 1 - ",scalar(localtime()),"\n";
for ($i = 0;$i <= $numargs;$i++) {
	$arg = $ARGV[$i];
	print OUT "$arg ";
}
close(OUT);
