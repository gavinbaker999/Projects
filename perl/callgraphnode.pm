package CallGraphNode;
use ObjectTemplate;
require Exporter;
@ISA = qw(ObjectTemplate Exporter);
$VERSION = 1.0;

attributes('filename','classname','fuctionname','linenumber','funcscalled');

# initialize will be called by new()
sub initialize {
#    my $self = shift;
#    $self->three(1) unless defined $self->three();
}

#sub create {
#	my ($pkg,$name) = @_;
#	return {bless {name => $name}, $pkg};
#}
#sub DESTROY {
#	my $obj = shift;
#}
#
#sub name {
#	my $obj = shift;
#	@_ ? $obj->{name} = shift;
#	   : $obj->{name};
#}

