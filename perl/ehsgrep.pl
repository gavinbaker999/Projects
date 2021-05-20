#!/usr/bin/perl -w

use File::Find;
use File::Basename;

sub intSignalCatcher {
	$intsignal = 1;
}

sub processTextFile {
	$fileCount++;
	$replaceMade = 0;

	$fileName = $_[0];
	#$dir = dirname($fileName);
	#$fileName = basename($fileName); # as File::Find changes the current directory 
	($fileName,$dir,$ext) = fileparse($fileName,'\..*');
	if ($ext eq ".sql" || substr($ext,-1) eq "~" || $ext eq ".bak" || $ext eq ".tmp") {
		return;
	}
	$fileName = "$fileName$ext";
	
	open(IN,"<$fileName") || die "Can't open file for reading $fileName\n";
	open(OUT,">$fileName.gav") || die "Can't open file for writing $fileName.gav\n";
	while (<IN>) {
		if (@ARGV == 2) { # find
			if (/$searchStr/o) {
				#$_ =~ s/^\s+//; # remove leading ws
				#$_ =~ s/\s+$//; # remove trailing ws
				print "$dir$fileName:$. $_\n";
				$findCount++;
			}
		} else { # find and replace
			$matches = ($_ =~ s/$searchStr/$replaceStr/g);
			if ($matches > 0) {
				$replaceMade = 1;
			}
			$findCount = $findCount + $matches;
		}
		
		print OUT "$_";
	}
	
	close(IN);
	close(OUT);
	
	if ($replaceMade == 0) {
		unlink ("$fileName.gav");
	} else {
		#rename("$fileName","$fileName.orig");
		unlink ("$fileName");
		rename("$fileName.gav","$fileName");
	}
}
sub fileProcess {
	processTextFile($File::Find::name) if -T;
	if ($intsignal == 1) {
		print "\nProcess Aborted\n\n";
		exit();
	}
}

print "EHS Grep Utility. Version 1.00\n";
print "(c) End House Software 2009-2012\n\n";

#@ARGV = ('.') unless @ARGV;
if (@ARGV != 2 && @ARGV != 3) {die "usage: perl ehsgrep.pl directoy find_string [replace_string]\n";}
$searchStr = $ARGV[1];
$replaceStr = "";
if (@ARGV == 3) {$replaceStr = $ARGV[2]}
print "Searching for $searchStr ...\n\n";

$intsignal = 0;
$SIG{'INT'} = 'intSignalCatcher';

$fileCount = 0;
$findCount = 0;
$replaceMade = 0;
find(\&fileProcess,$ARGV[0]);
print "$findCount matches in $fileCount files\n";

