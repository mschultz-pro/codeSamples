#script to edit premissions of AD printers to remove the "everyone" permission

$Logfile = "C:\PowershellScripts\printerPremissions.log"

Function LogWrite
{
   Param ([string]$logstring)

   Add-content $Logfile -value $logstring
}


#strings that represent each security group 
#from what i can tell all premissions for the everyone grroup end in ;WD
$EveryonePrint = '(A;;SWRC;;;WD)'
$EveryoneRead = '(A;CIIO;GX;;;WD)'
$AllStaff = '(A;;SWRC;;;S-1-5-21-208081021-1031441830-2450441743-1625)'

#name of all printer servers your working on
$printServers = @('calculon')#,'DYMOSHARE1','DYMOSHARE2')

foreach ($printServer in $printServers) { #for each printer server
     LogWrite "working on $printServer"
     LogWrite ""

    #Get-Printer -Full -ComputerName $printServer | where name -like "testPrinter*" | select name,PermissionSDDL -ExpandProperty PermissionSDDL | Sort-Object Name | ForEach-Object { #get test printers
     Get-Printer -Full -ComputerName $printServer | where Shared -EQ True           | where name -NotLike "Admin-Billing" | select name,PermissionSDDL -ExpandProperty PermissionSDDL | Sort-Object Name | ForEach-Object { #get printers on the printserver
     
        $permissionString = $_.PermissionSDDL #get permission String
        $name = $_.Name

        if ($permissionString -like '*'+$EveryonePrint+'*' -or $permissionString -like '*'+$EveryoneRead+'*'){ #if printer has a everyone permission
            #tell user what printer your working on
            LogWrite "working on $Name"
            LogWrite "intial permissionString: $permissionString"
        
            if ($permissionString -Notlike '*'+$AllStaff+'*') { #if printer doesn't have all staff permission
                LogWrite 'added $AllStaff' #tell user what your adding
                $permissionString = $permissionString + $AllStaff #add to permission string 
            }

            if ($permissionString -like '*'+$EveryonePrint+'*'){ #if printer has the everyone print permission
                LogWrite 'removed $EveryonePrint' #tell user what your removing
                $permissionString = $permissionString.Replace($EveryonePrint,"") #remove from permission string
            }

            if ($permissionString -like '*'+$EveryoneRead+'*'){ #if printer has the everyone read permission
                LogWrite 'removed $EveryoneRead' #tell user what your removing
                $permissionString = $permissionString.Replace($EveryoneRead,"") #remove from permission string
            }
            
            Set-Printer -ComputerName calculon -name $name -PermissionSDDL $permissionString #write permission String to printer 

            #tell user printer was updated
            LogWrite "permissions updated on $name"
            LogWrite "final permissionString: $permissionString"
            LogWrite ""

        }#close if printer has a everyone permission
    }#close for each printer loop
}#close for each print server loop