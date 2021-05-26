#!/usr/bin/perl -w

use CallGraphNode;

if (@ARGV != 1) {die "Wrong number of command arguments\nperl callgraph.pl sourcefilename\n";}
$a = $ARGV[0];
open(IN,"$a") || die "Can't open file for reading $a\n";
open(OUT,">$a.out") || die "Can't open file for writing $a.out\n";

print "JAVA Call Graph Version 1.00\n";
print "(c) End House Software 2020\n";

#  $foo = CallGraphNode->new();

while (<IN>) {
	$line = $_;
	chomp($line);

	$line =~ s#//.*$##g;
	$line =~ s/{.*}//g;
	$line =~ s/{.*$//g;
	
	$_ = $line;
		
}

close(IN);
close(OUT);

