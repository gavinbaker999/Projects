#!/usr/bin/perl -w
if (@ARGV != 1) {die "Wrong number of command arguments\n";}
$a = $ARGV[0];
open(IN,"$a.txt") || die "Can't open file for reading $a.txt\n";
open(OUT,">$a.out") || die "Can't open file for writing $a.out\n";

open(SQL,">$a.php") || die "Can't open file for writing $a.php\n";
print SQL "<html><head></head><body>\n<?\n\$mylink = dbx_connect (DBX_MYSQL, \"localhost\", \"endhousesoftware_com_-_endhousesoftware\", \"endhousesoftware\", \"links\");\n";

$linenum = 0;
$output = 0;
$text = "";
$cat = "";
$catdesc = "";
while (<IN>) {
	$line = $_;
	chomp($line);
	$linenum = $linenum + 1;
	if ($linenum == 1) {$cat = $line;next;}
	if ($linenum == 2) {
		$catdesc = $line;
		print SQL "\$result=dbx_query(\$mylink,\"INSERT INTO linksCatDescriptions VALUES (null, '$cat', 'rootcat', '$catdesc', 'Gavin Baker', 'endhousesoftware\@hotmail\.com', '2007-01-01', '09:00:00', 1)\",DBX_RESULT_ASSOC);\n";
		next;
	}
	$lineorg = $line;
	$line=~tr/A-Z/a-z/;
	$start = 0;
	if ($output == 0) {
		$start = index($line,"<a href");
	}
	if ($start == -1) {next;}
	$output = 1;
	$end = index($line,"</a>");
	if ($end != -1) {
		$output = 0;
		
		$text = $text . substr($lineorg,$start,$end-$start+4);
		print OUT "$text\n";
		
		$urlstart = index($text,"\"") + 1;
		$urlend = index($text,"\"",$urlstart) - 1;
		$url = substr($text,$urlstart,$urlend-$urlstart+1);
		$urldescstart = index($text,"\">") + 2;
		$urldescend = index($text,"</A>",$urldescstart) - 1;
		$urldesc = substr($text,$urldescstart,$urldescend-$urldescstart+1);
		
		print SQL "\$result=dbx_query(\$mylink,\"INSERT INTO linksLinkDescriptions VALUES (null,'$url','$urldesc','2007-01-01', '09:00:00','Gavin Baker','$cat',5,1,'','http')\",DBX_RESULT_ASSOC);\n";
		$text = "";
		next;
	}
	$text = $text . substr($lineorg,0,$line.length()-1);
}
close(IN);
close(OUT);

print SQL "dbx_close(\$mylink);\n?>\n</body></html>\n";
close(SQL);


