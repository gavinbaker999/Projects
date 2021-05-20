
  package Foo;
  use Class::ObjectTemplate;
  require Exporter;
  @ISA = qw(Class::ObjectTemplate Exporter);

  attributes('one', 'two', 'three');

  # initialize will be called by new()
  sub initialize {
    my $self = shift;
    $self->three(1) unless defined $self->three();
  }

  use Foo;
  $foo = Foo->new();

  # store 27 in the 'one' attribute
  $foo->one(27);

  # check the value in the 'two' attribute
  die "should be undefined" if defined $foo->two();

  # set using the utility method
  $foo->set_attribute('one',27);

  # check using the utility method
  $two = $foo->get_attribute('two');

  # set more than one attribute using the named parameter style
  $foo->set_attributes('one'=>27, 'two'=>42);

  # or using array references
  $foo->set_attributes(['one','two'],[27,42]);

  # get more than one attribute
  @list = $foo->get_attributes('one', 'two');

  # get a list of all attributes known by an object
  @attrs = $foo->get_attribute_names();

  # check that initialize() is called properly
  die "initialize didn't set three()" unless $foo->three();

