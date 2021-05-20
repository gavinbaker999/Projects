#!/usr/bin/perl -w
if (@ARGV != 1) {die "Wrong number of command arguments\n";}
$a = $ARGV[0];

open(IN,"$a.sql") || die "Can't open file for reading $a.sql\n";
open(SQL,">$a.php") || die "Can't open file for writing $a.php\n";
print SQL "<html><head></head><body>\n<?\n";
print SQL "include(\"website\\scripts\\common.php\");\n";
print SQL "include(\"website\\scripts\\dbconnect.php\");\n";

print "SQL Dump to PHP Converter. Version 1.10\n";
print "(c) End House Software 2009-2014\n";

$out = "";
while (<IN>) {
	$line = $_;
	chomp($line);
	next if /^$/; # ignore blank lines
	next if /^--/; # ignore comment lines
	next if /^./*/!/;
	
	$out = $out . $line;
	if (/;$/) {
		chop ($out); # remove the ; character
		$out =~ s/\"\"//g;
		print SQL "\$result = mysql_query(\"$out\");\n";
		print SQL "mysqlError(\$result);\n";
		$out = "";
		next;
	}
}

close(IN);
print SQL "\nmysql_close(\$link);\n?>";
print SQL "\n<center>Database Has Been Updated ...</center>";
print SQL "\n</body></html>\n";
close(SQL);


