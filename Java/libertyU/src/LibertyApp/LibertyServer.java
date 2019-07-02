// included are all packages imported in order to make this app work
import LibertyApp.*;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;

public class LibertyServer 
{
  public static void main(String args[])
  {
    try{
       // create and initialize the ORB
      ORB orb = ORB.init(args, null);
      
      // create the servant and register it with the ORB
      LibertyServant libertyRef = new LibertyServant();
      orb.connect(libertyRef);
      
      // get root naming context
    org.omg.CORBA.Object objRef = orb.resolve_initial_references("NameService");
      NamingContext ncRef = NamingContextHelper.narrow(objRef);
      
      // bind the object reference in naming
      NameComponent nc = new NameComponent("Liberty", "");
      NameComponent path[] = {nc};
      ncRef.rebind(path, libertyRef);
      
      // wait for invocations from clients
      java.lang.Object sync = new java.lang.Object();
      synchronized(sync){
        sync.wait();	
      }
          } catch(Exception e) {
        System.err.println("ERROR: " + e);
        e.printStackTrace(System.out);
      }  
  }
}

class LibertyServant extends _LibertyImplBase	
{
  public String libertyU()
  {
    return "\nLiberty U!!\n";
    }
}
