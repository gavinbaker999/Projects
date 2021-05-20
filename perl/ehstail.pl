#!/usr/bin/perl -w

print "EHS Tail Utility. Version 1.00\n";
print "(c) End House Software 2009\n\n";

if (@ARGV != 1 && @ARGV != 2) {die "usage: perl ehstail.pl filename [-displaylines=n]\n";}
$a = $ARGV[0];

$totallinenum = 0;
$displaylines = 10;

# check for and process command line arg -displaylines=n
while ($arg = shift @ARGV) {
	if ($arg=~/-(\w+)=(\w+)/) {
		$varname=$1;
		$value=$2;
		if ($varname eq "displaylines") {$$varname=$value;}
	}
}

open(IN,"$a") || die "Can't open file for reading $a\n";
while (<IN>) {
	$totallinenum++;
}
close(IN);
$linenum = 0;
open(IN,"$a") || die "Can't open file for reading $a\n";
while (<IN>) {
	$linenum++;
	if ($linenum > ($totallinenum - $displaylines)) {
		print "$_";
	}
}
close(IN);

