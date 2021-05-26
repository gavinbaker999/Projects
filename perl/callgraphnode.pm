package CallGraphNode;
require Exporter;
@ISA = qw(Exporter);
@EXPORT = qw(funca);
$VERSION = 1.0;

sub new {
    my $class = shift;
    my $self = {};
    bless $self,$class;
    return $self;
}

sub funca {

}

sub DESTROY {
    
}