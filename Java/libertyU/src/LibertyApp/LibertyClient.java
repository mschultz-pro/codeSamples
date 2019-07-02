import LibertyApp.*;           // The package containing your stubs.
import org.omg.CosNaming.*;  // LibertyClient will use the naming service.
import org.omg.CORBA.*;      // All CORBA applications need these classes.

public class LibertyClient
{
  public static void main(String args[])
  {
    try{
      
      // create and initialize the ORB
      ORB orb = ORB.init(args, null);
      
      // get the root naming context
      org.omg.CORBA.Object objRef = orb.resolve_initial_references("NameService");
      NamingContext ncRef = NamingContextHelper.narrow(objRef);
      
      // resolve the object reference in naming
      NameComponent nc = new NameComponent("Liberty", "");
      NameComponent path[] = {nc};
      Liberty libertyRef = LibertyHelper.narrow(ncRef.resolve(path));
      
      // call the Liberty server object and print results
      String liberty = libertyRef.libertyU();
      System.out.println(liberty);
          
    } catch(Exception e) {
        System.out.println("ERROR : " + e);
        e.printStackTrace(System.out);
      }  
  }
}
