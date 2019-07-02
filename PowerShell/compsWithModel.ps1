#script to collect data about computer 

#variables for script 
#OUs to check
$OUs = "OU=LAPTOPS,OU=COMPUTERS,DC=Organization,DC=org"#,"OU=DESKTOPS,OU=COMPUTERS,DC=Organization,DC=org"

#working dircetory 
$pathToDir = "$env:temp\findCompModelInfo\"
if (!(Test-Path $pathToDir)){
    #make dir if needed
    New-Item -ItemType directory -Path $pathToDir
    write-host "path created"
}

#computers we found this time
$foundComps = @()

#computer we found last time
$prevFoundComps = @()

#computer objects from AD
$comps = @()

#info we are collecting from computers
$compInfo = @()

#flag for findng previous comps
$haveComps = $false

#test if there is a record of previous computers
if (Test-Path $pathToDir"prevFoundComps.csv"){
    write-host "found record of prvious couputers"
    #import those computer objects
    $prevFoundComps = Import-Csv $pathToDir"prevFoundComps.csv"
    #set flag
    $haveComps = $true
} 

#test if there is a record of previous computer info
if (Test-Path $pathToDir"compInfo.csv"){
    write-host "found record of computer info"
    #import that info
    $compInfo = Import-Csv $pathToDir"compInfo.csv"
} 

#get computer opbjects from each ou specified 
foreach ($ou in $OUs){
    #if there is a record of previous comps
    if ($haveComps){
        #omit them form the search 
        $comps += Get-ADComputer -filter * -Properties LastLogonTimeStamp -SearchBase $ou | where name -notin $prevFoundComps.Name
    } else {
        #other wise get a complete list
        $comps += Get-ADComputer -filter * -Properties LastLogonTimeStamp -SearchBase $ou #-ResultSetSize 3
    }
}

#tell how many are found 
write-host $comps.count computers found

#for evey computer loaded from AD
foreach ($computer in $comps){
    #pull some atributes 
    $cName = $computer.Name
    $cDNS = $computer.DNSHostName
    #see if you can connect to that computer 
    if(!(Test-Connection $cDNS -BufferSize 16 -Count 1 -ea 0 -quiet)){
        write-host "cannot reach $cName offline" -f red
        #comp last seem
        "last logon at: "+[datetime]::FromFileTime($computer.LastLogonTimeStamp) | write-host -f red
        write-host ' '
    } else {
        Try{
            #try to gather info and add to list of computer info
            $compInfo += Get-WmiObject -Class Win32_ComputerSystem -Computer $cDNS -ErrorAction Stop
            #add comp to list of found comps
            $foundComps += $computer
            write-host "found info for $cName"
            
        } catch {
            #if error tell user about it
            write-host "Error communicating with $cName, skipping to next" -f red
            write-host $_.Exception.Message
            #add to log file
            $cName, $_.Exception.Message | add-content $pathToDir"compsWithModelerror.log"
        }
    }
}

#if there are any previous comps or new comps 
if ($prevFoundComps.count -gt 0 -or $foundComps.count -gt 0 ){
    $output = $prevFoundComps + $foundComps
    #save them to a CSV
    $output | Export-Csv -NoTypeInformation -path $pathToDir"prevFoundComps.csv"
    "record of found computers writen to "+$pathToDir+"prevFoundComps.csv" | Write-Host 

}

#if there is any computer info
if ($compInfo.count -gt 0 ){
    #save it to a CSV
    $compInfo | Export-Csv -NoTypeInformation -path $pathToDir"compInfo.csv"
    "record of computers info writen to "+$pathToDir+"compInfo.csv" | Write-Host
}