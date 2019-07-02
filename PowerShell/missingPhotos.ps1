#script to find uses who are missing a photo and try to upload a photo for them 

Function uploadPhoto{
	
	Import-Module C:\NewEmployeePhotoUpload\Resize-Image.psm1
	Import-Module ActiveDirectory

	$uname = $env:UserName + "@Organization.org" #-Credential $uname
	$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri https://outlook.office365.com/powershell-liveid/?proxyMethod=RPS -Credential $uname -Authentication Basic -AllowRedirection 
	Import-PSSession $Session -ErrorAction Stop

	$path1 = resolve-path C:\NewEmployeePhotoUpload\SquarePhoto\
	$path2 = resolve-path C:\NewEmployeePhotoUpload\ShrunkPhoto\
	write-host Local paths have been resolved. Path 1 = $path1 and Path 2 = $path2

	$files=get-childitem $Path1 *.jpg
	write-host Retrieved $files.count pictures to upload

	foreach ($file in $files){
		$userName = $file.Basename + '@Organization.org'
		
		write-host Beginning to work on $file
		Resize-Image -Inputfile $file.FullName -OutputFile $path2$file -Width 500 -Height 500
		
		write-host Sending 500px square photo to O365
		$fileString = "$path2$file"
		Set-UserPhoto -Identity $userName -PictureData ([System.IO.File]::ReadAllBytes($fileString)) -Confirm:$false
		write-host $username O365 photo has been set
		
		Remove-Item $path2$file #remove resized photo after setting user photo
		
		Resize-Image -Inputfile $file.FullName -OutputFile $path2$file -Width 92 -Height 92
		write-host $file has been resized for Active Directory and will now be set
		
		Set-ADUser $file.BaseName -Replace @{thumbnailPhoto=([byte[]](Get-Content $path2$file -Encoding byte))} -ErrorAction Stop
		write-host $username AD thumbnail has been set
		
		Remove-Item $path2$file #remove resized photo after setting user thumbnail 
		Remove-Item $path1$file #remove orginal photo
	}
}

uploadPhoto

#directory to store files 
$dir = "\\Server\Information Services\Employee Photos\"
$photoDestination = 'C:\NewEmployeePhotoUpload\SquarePhoto'

#find users without photos 
$usersWithoutPhoto = Get-ADUser -Filter * -SearchBase "OU=STAFF,OU=USERS,DC=Organization,DC=org" -SearchScope 1 -properties thumbnailPhoto,Description,Office | ? {!$_.thumbnailPhoto} | where Description -notLike "MAP Volunteer" | where Description -notLike "Lab Corp Phlebotomist" | where Description -notLike "Test Account"| Select Name,samAccountName,Description,Office 

if ($usersWithoutPhoto.count -gt 0){ #only procead if some AD users are missing photos

	$usersMissingPhoto = @() #array for uses who's picture we need to collect
	$anyPhotosAval = $false #create flag to mark if we have a any photos to upload
	
	foreach ($user in $usersWithoutPhoto){#for each user found 
	
		$photoLocation = $dir+'Cropped-and-1000px-square\'+$user.samAccountName+'.jpg'
		#define where to look for a photo
		
		if (Test-Path $photoLocation -PathType Leaf) { 
			#check if we aleady have a photo for the user
			copy-item $photoLocation -destination $photoDestination
			# if so copy it to be uploaded
			$anyPhotosAval = $true #set flag
		}else {$usersMissingPhoto += $user} #if we are missing photo add user to list
	}

	if ($anyPhotosAval) { #if flag was set
	Write-Host 'uploading photos'
	uploadPhoto #upload photos
	}
	
	if ($usersMissingPhoto.count -gt 0){ #if any users are in the list of photos we need to collect
		$usersMissingPhoto | export-csv -notypeinformation $dir"staffWithoutPhotos.csv"
		#write it to a file
	}
}