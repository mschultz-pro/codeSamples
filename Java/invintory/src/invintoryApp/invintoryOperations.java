package invintoryApp;


/**
* invintoryApp/invintoryOperations.java .
* Generated by the IDL-to-Java compiler (portable), version "3.2"
* from invintory.idl
* Friday, August 26, 2016 7:44:01 PM EDT
*/

public interface invintoryOperations 
{
  String checkAvailability (String item);
  short checkStock (String item);
  String sellItem (String item);
  String listLowStock ();
  String listItems ();
} // interface invintoryOperations
