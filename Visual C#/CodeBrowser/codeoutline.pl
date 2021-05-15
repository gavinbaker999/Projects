#!/usr/bin/perl -w

use Getopt::Std;
use Time::localtime;
use IO::File;
use File::Basename;
use POSIX qw(tmpnam);

sub extension {
	my $path = shift;
	my $ext = (fileparse($path,'\..*?'))[2];
	$ext =~ s/^\.//;
	return $ext;
}

$copyright = "(c) End House Software 2008-2016";
$appname = "Code Outliner Version 2.00";

$opt_o = "";
getopts("o:"); # sets $opt_o to the value of the command line parameter (does not count in @ARGV)

# create a temp filename for the XML output
$tmpfilename = tmpnam();
$tmpfilename = basename("$tmpfilename");
#do {$tmpfilename = tmpnam();}
#	until $fh = IO::File->new($tmpfilename,O_RDWR|O_CREAT|O_EXCL);

if (@ARGV != 1) {die "Wrong number of command arguments\nperl codeoutline.pl [-o description] sourcefilename\n";}
$a = $ARGV[0];
open(IN,"$a") || die "Can't open file for reading $a\n";
open(OUT,">$a.out") || die "Can't open file for writing $a.out\n";
#open(OUTXML,">$a.xml") || die "Can't open file for writing $a.xml\n";
open(OUTXML,">$tmpfilename") || die "Can't open file for writing $tmpfilename\n";
open(OUTJAVADOC,">$a.javadoc") || die "Can't open file for writing $a.javadoc\n";

$ext = extension($a);

print "$appname\n";
print "$copyright\n";
print "Output Files: $a.out and $a.xml\n";

$alwaysnextline = 0;
$inclass = 0;
$bracecount = 0;
$globalbracelevel = 0; # JAVA 1 and c++/c# 0
if ($ext eq "java") {$globalbracelevel = 1;}
$bracefudge  = 0;
$funcdef = 0;
$vardef = 0;
@classnames = ();
@classbracecounts = ();
@glines = ();
print "File extension: $ext: $globalbracelevel\n";

print OUT "$appname\n";
print OUT "$copyright\n";

$tm = localtime;
$day = $tm->mday;
$month = $tm->mon+1;
$year = $tm->year+1900;
print OUTXML "<?xml version=\"1.0\"?>\n\t<codeoutline name=\"$a\" date=\"$day/$month/$year\" description=\"$opt_o\">\n";

#while (<IN>) {
#	$line = $_;
#	$line =~ s/^\s+//; # remove leading ws
#	$line =~ s/\s+$//; # rewmove trailing ws
#	chomp($line); # remove newline character
#	$orgline = $line;
#
#	print OUT "$line\n";
#	print OUTJAVADOC "$orgline\n";
#
#	$line =~ s#//.*$##g; # remove comment lines
#	$linenostrings = $line;
#	$linenostrings =~ s#\".*?\"#\"\"#g; # copy of line with empty string lierals
#	
#	$obracecount = 0;
#	$cbracecount = 0;
#	$tmp = $linenostrings;
#	while ($tmp =~ /(.)/g) {
#		if ($1 eq "{") {$obracecount++;}
#		if ($1 eq "}") {$cbracecount++;}
#	}
#	
#	$_ = $linenostrings;
#	
#	if (/\bclass\b/ || /\binterface\b/) {
#		@l = split(" ",$line);
#		$classname = "...";
#		print OUTXML "\t\t<class name=\"$classname\" description=\"\">\n";
#		push (@classnames,$classname);
#		if ($bracecount > $globalbracelevel) {$inclass = 1;}
#		next;
#	}
#	if (end of class)
#	{
#		$classname = pop(@classnames);
#		print OUTXML "\t\t</class>\n";
#		$inclass = 0;
#	}
#
#	$extra = "";
#	if ($inclass == 0) {
#		# not in class defination push global lines onto a stack so we can output them all at the end
#		push(@glines,$line);
#		$extra = "global";
#	} 
#
#	if (function def)
#	{
#		print OUTXML "\t\t<"."$extra"."function description=\"\" access=\"$access\" rettype=\"$rettype\" params=\"$params\" name=\"$name";
#		print OUTXML "\">\n\t\t</function>\n";
#	}
#	if (variable def)
#	{
#		# split multiple variable names up so they appear in separate output lines
#		@fields = split(",",$name);
#		foreach $field (@fields) {
#			print OUTXML "\t\t<"."$extra"."variable description=\"\"  access=\"$access\" type=\"$type\" defvalue=\"$defvalue\" name=\"$field";
#			if ($#fields != 0) {print OUTXML "\">\n\t\t</"."$extra"."variable>\n";$varenddone = 1;} ???
#			print OUTXML "\">\n\t\t</variable>\n";
#		}
#	}
#	if (enum)
#	{
#		print OUTXML "\t\t<"."$extra"."enum name=\"$name\" access=\"$access\" values=\"$values\"/>\n";
#	}
#}

while (<IN>) {
	$line = $_;
	$orgline = $line;
	chomp($line);  # remove newline character
	
	print("$line\n");

	$line =~ s#//.*$##g; # remove comment lines
	$linenostrings = $line;
	$linenostrings =~ s#\".*?\"#\"\"#g; # copy of line with empty string lierals
	
	$obracecount = 0;
	$cbracecount = 0;
	$tmp = $linenostrings;
	while ($tmp =~ /(.)/g) {
		if ($1 eq "{") {$obracecount++;}
		if ($1 eq "}") {$cbracecount++;}
	}
	$bracecount = $bracecount + $obracecount - $cbracecount + $bracefudge;
	$bracefudge = 0;
	
	#remove function parameters, opening brace and rest of line
	$params = "";
	$line =~ s/\((.*)\).*{.*$//g;
	if (defined $1) {$params = $1;}
	
	$line =~ s/^\s+//; # remove leading ws
	$line =~ s/\s+$//; # rewmove trailing ws
	
	if ($cbracecount > 0) {
		print("bracecount=$bracecount\n");		
		$a = $classbracecounts[$#classbracecounts];
		if ($a-1 == $bracecount)
		{
			$classname = pop(@classnames);
			pop (@classbracecounts);
			print OUT "Endclass $classname\n";
			print OUTXML "\t\t</class>\n";
			$inclass = 0;
		}
	}

	$_ = $linenostrings;
	
	# get the index of the class name on the line - access modifier (e.g. public) can be optional	
	$classnameindex = 0;
	if (/\bclass\b/ || /\binterface\b/) {
		$classnameindex = 1;
		if (/\bpublic\b/ || /\bprivate\b/ || /\bprotected\b/) {
			$classnameindex = 2;
		}
	}
	
	$line =~ s/\{//g;
	
	if ($alwaysnextline == 1) {
		print OUT "$line\n";
		print OUTXML "$line";
		if (/;/) {$alwaysnextline = 0;}
		if ($funcdef == 1) {print OUTXML "\">\n\t\t</function>\n";}
		if ($vardef == 1) {print OUTXML "\">\n\t\t</variable>\n";}
		$funcdef = 0;
		$vardef = 0;
		next;
	}
	# if line ends in a '=' output next line(s) until we reach a ';'
	if (/=$/) {$alwaysnextline = 1;}
	
	# have to nest the conditions below so we do not process a 'class' that say appears in an error string
	if (/\bpublic\b/ || /\bprivate\b/ || /\bprotected\b/ || $classnameindex != 0) {
		if (/\bclass\b/ || /\binterface\b/) {
			if ($obracecount == 0) { # where opening brace of class or interface appears on next line
				$bracefudge = -1;
				$bracecount++;
			}
			print OUT "\n$line\n";
			#print OUT "bracecount=$bracecount\n";
			@l = split(" ",$line);
			$classname = $l[$classnameindex];
			#print OUT "classname=$classname\n";
			print OUTXML "\t\t<class name=\"$classname\" description=\"\">\n";
			push (@classnames,$classname);
			push (@classbracecounts,$bracecount);
			if ($bracecount > $globalbracelevel) {$inclass = 1;}
			next;
		}
		
		$extra = "";
		if ($inclass == 0) {
			# not in class defination push global lines onto a stack so we can output them all at the end
			push(@glines,$line);
			$extra = "global";
		} 
		
			if ($inclass == 1) {print OUT "\t$line\n";}
			# set vardef or funcdef to 1
			if (/\benum\b/) {
				$line =~ s/};//g;
				@l = split(" ",$line);
				$access = $l[0];
				$name = $l[$#l - 1];
				$values = $l[$#l];
				print OUTXML "\t\t<"."$extra"."enum name=\"$name\" access=\"$access\" values=\"$values\"/>\n";
			} else {
				if ($line =~ /;/) {
					$vardef = 1;
					$line =~ s/;//g;
					$line =~ s/(\s*)=(\s*)/ = /g;
					@l = split(" ",$line);
					$access = $l[0];
					
					if (/=/) {
						$index = 0;
						foreach $elem (@l) {
							if ($elem eq "=") {last;}
							$index++;
						}
					
						$name = $l[$index-1];
						$type = $l[$index-2];
						$defvalue = join ' ',@l[$index+1 .. $#l];
						if ($defvalue =~ /}$/) {
							$defvalue = "{" . $defvalue;
						}
						$defvalue =~ s/"/'/g;
					} else {
						$name = $l[$#l];
						$type = $l[$#l - 1];
						$defvalue = "";
					}
				} else {
					$funcdef = 1;
					@l = split(" ",$line);
					$access = $l[0];
					$name = $l[$#l];
					$rettype = $l[$#l - 1];
					if ($rettype eq $access) {
						$rettype = "constructor";
					}
				}
			}
			
			if ($funcdef == 1) {print OUTXML "\t\t<"."$extra"."function description=\"\" access=\"$access\" rettype=\"$rettype\" params=\"$params\" name=\"$name";}
			$varenddone = 0;
			if ($vardef == 1) {
				# split multiple variable names up so they appear in separate output lines
				@fields = split(",",$name);
				foreach $field (@fields) {
					print OUTXML "\t\t<"."$extra"."variable description=\"\"  access=\"$access\" type=\"$type\" defvalue=\"$defvalue\" name=\"$field";
					if ($#fields != 0) {print OUTXML "\">\n\t\t</"."$extra"."variable>\n";$varenddone = 1;}
				}
			}
			if ($alwaysnextline == 0) {
				if ($funcdef == 1) {print OUTXML "\">\n\t\t</"."$extra"."function>\n";}
				if ($vardef == 1 && $varenddone == 0) {print OUTXML "\">\n\t\t</"."$extra"."variable>\n";}
				$funcdef = 0;
				$vardef = 0;
			}
		
		#print OUT "bracecount=$bracecount\n";
	}
	
	print OUTJAVADOC "$orgline\n";
}

print OUT "\n";
foreach $glines (@glines) {
	# output all global lines (i.e. outside class definitions) in a block at end of file
	print OUT "$glines\n";
	print OUTXML "\t\t\<global line=\"$glines\"/>\n";
}

print OUTXML "\t</codeoutline>\n";

close(IN);
close(OUT);
close(OUTXML);
close(OUTJAVADOC);

# rename the temp XML format output file to the correct name (to allow code browser's file watcher to work properly with only one change notification) 
$a = $ARGV[0];
unlink("$a.xml");
rename("$tmpfilename","$a.xml");
