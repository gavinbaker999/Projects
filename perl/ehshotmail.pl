#!/usr/bin/perl -w

use Hotmail;
  
  my $hotmail = Hotmail->new();
  
  $hotmail->login('endhousesoftware@hotmail.com', "joidefoster")
   or die $Hotmail::errstr;
  
  my @msgs = $hotmail->messages();
  die $Hotmail::errstr if ($!);

  print "You have ".scalar(@msgs)." messages\n";

  for (@msgs) {
        print "messge from ".$_->from."\n";
        # retrieve the message from hotmail
        my $mail = $_->retrieve;
        # deliver it locally
        $mail->accept;
        # forward the message
        #$mail->resend('myother@email.address.com');
        # delete it from the inbox
        #$_->delete;
  }
  
  #$hotmail->compose(
  #  to      => ['user@email.com','otheruser@otheremail.com'],
  #  subject => 'Hello Person!',
  #  body    => q[Dear Person,
  # 
  #I am writing today to tell you about something important.
  #
  #Thanks for all your support.
  #
  #Sincerely,
  #Other Person
  #]) or die $WWW::Hotmail::errstr;

