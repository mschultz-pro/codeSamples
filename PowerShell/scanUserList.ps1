#script to get a formated list of users to import into printers. 

Import-Module ActiveDirectory

#directory to store files 
$dir = "\\Server\Information Services\Scan Users\"

# general variables 
$server = "Server"
$ADuser = "scan"
$ADpass = "password"
$scanUserList = @()

#look though each user in OU=STAFF,OU=USERS,DC=Organization,DC=org but not OU=STUDENTS who also has the group Organization - All Staff
foreach($user in  get-adgroupmember -Identity "Organization - All Staff" | Where distinguishedName -like '*OU=STAFF,OU=USERS,DC=Organization,DC=org' | Where objectclass -eq 'user' | Where distinguishedName -notlike '*OU=STUDENTS*' | Sort-Object Name | Select Name,samAccountName)
{
	#user specific variables 
	$firstLeter =  $user.Name[0]
	#sets sort letters based on first letter of name 
	Switch ($firstLeter) { 
		a {$sort = "Abc"}
		b {$sort = "Abc"}
		c {$sort = "Abc"}
		d {$sort = "Def"}
		e {$sort = "Def"}
		f {$sort = "Def"}
		g {$sort = "Ghi"}
		h {$sort = "Ghi"}
		i {$sort = "Ghi"}
		j {$sort = "Jkl"}
		k {$sort = "Jkl"}
		l {$sort = "Jkl"}
		m {$sort = "Mno"}
		n {$sort = "Mno"}
		o {$sort = "Mno"}
		p {$sort = "Pqrs"}
		q {$sort = "Pqrs"}
		r {$sort = "Pqrs"}
		s {$sort = "Pqrs"}
		t {$sort = "Tuv"}
		u {$sort = "Tuv"}
		v {$sort = "Tuv"}
		w {$sort = "Wxyz"}
		x {$sort = "Wxyz"}
		y {$sort = "Wxyz"}
		z {$sort = "Wxyz"}
	}
	$path = "scans\"+$user.samAccountName
	$dispayName = $user.Name
	#truncates dispayName if longer than 24 characters 
	If ($dispayName.Length -gt 24) {
        $dispayName = $dispayName.Substring(0,24)
    } 
	
	#formated output
	$line = $dispayName+","+$sort+","+$server+","+$path+","+$ADuser+","+$ADpass
	$scanUserList += $line
}

#write contents of array to file
Set-Content $dir"scanUserList.csv" $scanUserList