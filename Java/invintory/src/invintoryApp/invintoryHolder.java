package invintoryApp;

/**
* invintoryApp/invintoryHolder.java .
* Generated by the IDL-to-Java compiler (portable), version "3.2"
* from invintory.idl
* Friday, August 26, 2016 7:44:01 PM EDT
*/

public final class invintoryHolder implements org.omg.CORBA.portable.Streamable
{
  public invintoryApp.invintory value = null;

  public invintoryHolder ()
  {
  }

  public invintoryHolder (invintoryApp.invintory initialValue)
  {
    value = initialValue;
  }

  public void _read (org.omg.CORBA.portable.InputStream i)
  {
    value = invintoryApp.invintoryHelper.read (i);
  }

  public void _write (org.omg.CORBA.portable.OutputStream o)
  {
    invintoryApp.invintoryHelper.write (o, value);
  }

  public org.omg.CORBA.TypeCode _type ()
  {
    return invintoryApp.invintoryHelper.type ();
  }

}
