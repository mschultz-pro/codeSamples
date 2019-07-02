// Copyright and License 
 
import invintoryApp.*;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;
import java.util.Scanner;

public class invintoryClient
{
  static invintory invintoryImpl;

  public static void main(String args[])
    {
        Scanner scanner = new Scanner(System.in);
      try{
        // create and initialize the ORB
        ORB orb = ORB.init(args, null);

        // get the root naming context
        org.omg.CORBA.Object objRef = 
            orb.resolve_initial_references("NameService");
        // Use NamingContextExt instead of NamingContext. This is 
        // part of the Interoperable naming Service.  
        NamingContextExt ncRef = NamingContextExtHelper.narrow(objRef);
 
        // resolve the Object Reference in Naming
        String name = "invintory";
        invintoryImpl = invintoryHelper.narrow(ncRef.resolve_str(name));

        System.out.println("Obtained a handle on server object: " + invintoryImpl);

        boolean option = false;
        
        while  (option == false){
        System.out.println("what would you like to do?\n"
                            + "1    List all Items\n"
                            + "2    List Items Low In Stock\n"
                            + "3    Sell an Item\n"
                            + "4    Check the Stock of an Item\n"
                            + "5    Check the Availability of an Item\n"
                            + "6    quit\n"
                            + "Enter a number 1-6");
        int num = scanner.nextInt();
        if (num >0 && num <7){
            switch(num){
                case 1:{
                    System.out.println(invintoryImpl.listItems());
                    continue;
                }
                case 2:{
                    System.out.println(invintoryImpl.listLowStock());
                    continue;
                }
                case 3:{
                    System.out.println("What Item?");
                    String item = scanner.next();
                    System.out.println(invintoryImpl.sellItem(item));
                    continue;
                }
                case 4:{
                    System.out.println("What Item?");
                    String item = scanner.next();
                    System.out.println(invintoryImpl.checkStock(item));
                    continue;
                }
                case 5:{
                    System.out.println("What Item?");
                    String item = scanner.next();
                    System.out.println(invintoryImpl.checkAvailability(item));
                    continue;
                }
                case 6:{
                    option = true;
                    break;
                }
            }
            
        }else
            System.out.println("Please Enter a number 1-6");
        }

        } catch (Exception e) {
          System.out.println("ERROR : " + e) ;
          e.printStackTrace(System.out);
          }
    }

}
