import invintoryApp.*;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;
import org.omg.PortableServer.*;
import org.omg.PortableServer.POA;

import java.util.Properties;

class invintoryImpl extends invintoryPOA {
  private ORB orb;

  public void setORB(ORB orb_val) {
    orb = orb_val; 
  }

  public String invintoryItems[] = {"photo","hanger","clock","landscape","organzer"};
  public short invintoryCount[] ={5,6,2,1,5};
  
    
  @Override
  public String checkAvailability(String item){
    
              for (int i=0;i < invintoryItems.length;i++){
         if (invintoryItems[i].equals(item)){
             if (invintoryCount[i] > 0){
                 System.out.println(); 
                 return "in stock";
             }else{
                System.out.println();
                return "sold out";
                }
         }
    }
      return "\n" + "item not found or something went wrong";
  }
  
  @Override
  public short checkStock(String item){
      
      for (int i=0;i < invintoryItems.length;i++){
          if (invintoryItems[i].equals(item)){
             System.out.println();
             return invintoryCount[i]; 
          }
     }
      System.out.println();
      return -99;
  }
  
  @Override
  public String sellItem (String item){
      
        for (int i=0;i < invintoryItems.length;i++){
         if (invintoryItems[i].equals(item)){
                  invintoryCount[i] = (short) (invintoryCount[i] -1); 
                  System.out.println();
                  return invintoryItems[i]+" sold";
          }
      }
      return "\n" + "item not found or something went wrong";
  }
  
  @Override
  public String listLowStock (){
      String lowList = "";
      for (int i=0;i < invintoryItems.length;i++){
          if (invintoryCount[i] <2){ 
                  lowList += invintoryItems[i] +"\n";
          }
      }
      return "\n" +lowList;
   
  }
  
  @Override  
   public String listItems(){
    String itemList = "";
    for (int i=0;i < invintoryItems.length;i++)
        itemList += invintoryItems[i] + "       " + invintoryCount[i] + " in stock\n";
    return "\n" + itemList ;

  }
    
}



public class invintoryServer {

  public static void main(String args[]) {
      
   
    
    try{
      // create and initialize the ORB
      ORB orb = ORB.init(args, null);

      // get reference to rootpoa & activate the POAManager
      POA rootpoa = POAHelper.narrow(orb.resolve_initial_references("RootPOA"));
      rootpoa.the_POAManager().activate();

      // create servant and register it with the ORB
      invintoryImpl invintoryImpl = new invintoryImpl();
      invintoryImpl.setORB(orb); 

      // get object reference from the servant
      org.omg.CORBA.Object ref = rootpoa.servant_to_reference(invintoryImpl);
      invintory href = invintoryHelper.narrow(ref);
          
      // get the root naming context
      // NameService invokes the name service
      org.omg.CORBA.Object objRef =
          orb.resolve_initial_references("NameService");
      // Use NamingContextExt which is part of the Interoperable
      // Naming Service (INS) specification.
      NamingContextExt ncRef = NamingContextExtHelper.narrow(objRef);

      // bind the Object Reference in Naming
      String name = "invintory";
      NameComponent path[] = ncRef.to_name( name );
      ncRef.rebind(path, href);

      System.out.println("invintory Server ready and waiting ...");

      
      // wait for invocations from clients
      orb.run();
    } 
        
      catch (Exception e) {
        System.err.println("ERROR: " + e);
        e.printStackTrace(System.out);
      }
          
      System.out.println("invintory Server Exiting ...");
      
      
        
  }
}
