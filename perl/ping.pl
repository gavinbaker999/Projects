#!/usr/bin/perl
use Net::Ping;
use DBI;

$source = "DBI:mysql:database=gavin999_endhousesoftware;host=localhost";
$username = "root";
$password = "joidefoster";

$dbc = DBI->connect($source, $username, $password) or die "Unable to connect to mysql: $DBI::errstr\n";

$sql = $dbc->prepare("select linkID, linkDescription, linkURL from linkslinkdescriptions");

$out = $sql->execute() or die "Unable to execute sql: $sql->errstr";

my $p = Net::Ping->new();
while (($id, $name, $url) = $sql->fetchrow_array())
{
    my ($ret, $duration, $ip) = $p->ping($url);
    print "Id: $id Name: $name Ping: $duration\n";
}

$dbc->disconnect();
