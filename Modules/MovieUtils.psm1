$Name = $null
$Genre = $null
$Actor = $null
$Director = $null
$narrow720 = $null
$narrow1080 = $null
$narrowDvd = $null
 
<#
.Synopsis
Script requires QBittorrent in order to download.
 
http://www.qbittorrent.org/
 
A quick and easy way to get information on Movies.
This Script also has the ability to download movies using the Download-Movie function.
The download function requires Qbittorrent to be installed on your computer.
As always, take care when downloading files from the internet. Please use a VPN service as needed.
 
.DESCRIPTION
Genre Options:
 
Action
Adventure
Animation
Biography
Comedy
Crime
Documentary
Drama
Family
Fantasy
History
Horror
Musical
Mystery
Romance
Sci_fi
Short
Sport
Thriller
War
Western
 
.EXAMPLE
    #####
   Get-Movie -Name Inception
.EXAMPLE
    #####
   Get-Movie Intersteller
.EXAMPLE
    #####
    Movies with a space in the name require the full name to be wrapped in single quotes. Get-Movie 'The Silence of the lambs'
.EXAMPLE
    #####
  Get-Movie -Genre Action
.EXAMPLE
    #####
   Movies with a space in the name require the full name to be wrapped in single quotes. Download-Movie 'Forrest Gump'
.FUNCTIONALITY
   This Cmdlet is used for gathering information about specific movies while also offering the ability to download any movie via bit torrent.
#>
function Get-Movie
{
    [CmdletBinding()]
    Param
    (
       
             [string]$Name,
       [string][ValidateSet("Action",
                    "Adventure",
                    "Animation",
                    "Biography",
                    "Comedy",
                    "Crime",
                    "Documentary",
                    "Drama",
                    "Family",
                    "Fantasy",
                    "History",
                    "Horror",
                    "Musical",
                    "Mystery",
                    "Romance",
                    "Sci_fi",
                    "Short",
                    "Sport",
                    "Thriller",
                    "War",
                    "Western")]$Genre
                   
 
    )
 
 
 
 
$RootWeb = 'http://www.imdb.com'
 
 
 
#Filter for genre param
if($PSBoundParameters.ContainsKey('Genre')){
        $Genre = $Genre.ToLower()
        $GenreNav = Invoke-WebRequest "http://www.imdb.com/search/title?genres=$($Genre)&title_type=feature&sort=moviemeter,asc"
       
                       
        Start-Sleep -seconds 2    
        $Filter = $GenreNav.links | select title
        Start-Sleep -seconds 1    
 
        Switch($Genre) {
       
               Action {$filter -match '\d{4}'}
               Adventure {$filter -match '\d{4}'}
               Animation {$filter -match '\d{4}'}
               Biography {$filter -match '\d{4}'}
               Comedy {$filter -match '\d{4}'}
               Crime {$filter -match '\d{4}'}
               Documentary {$filter -match '\d{4}'}
               Drama {$filter -match '\d{4}'}
               Family {$filter -match '\d{4}'}
               Fantasy {$filter -match '\d{4}'}
               History {$filter -match '\d{4}'}
               Horror {$filter -match '\d{4}'}
               Musical {$filter -match '\d{4}'}
               Mystery {$filter -match '\d{4}'}
               Romance {$filter -match '\d{4}'}
               Sci_fi {$filter -match '\d{4}'}
               Short {$filter -match '\d{4}'}
               Sport {$filter -match '\d{4}'}
               Thriller {$filter -match '\d{4}'}
               War {$filter -match '\d{4}'}
               Western {$filter -match '\d{4}'}
               Default {Write-Host "No such genre exists"}
 
            }
        }    
     
#single movie search
if($PSBoundParameters.ContainsKey('Name')){
 
 
        $singlesearch = Invoke-WebRequest "http://www.imdb.com/find?ref_=nv_sr_fn&q=$($name)&s=all"
        $SelectMovie = $singlesearch.links.href -match '/title/tt' | select -First 1
        $movieinfo = Invoke-WebRequest "$rootweb$($SelectMovie)"
 
        $rating = $movieinfo.RawContent -match 'Users rated this \d{1}.+?(?=10)10'
        $ratingmatched = $matches[0]
        $about = $movieinfo.RawContent -match 'Directed by.+?(?=/>)' | select -First 1
        $aboutmatched = $matches[0]
 
Write-Host "$aboutmatched" -ForegroundColor DarkCyan
Write-Host "$ratingmatched" -ForegroundColor Yellow
 
 
        }
}
 
 
Function Download-Movie {
 
Param(
 
[Parameter(Mandatory=$true,
                   ValueFromPipeline=$true,
                   ValueFromPipelineByPropertyName=$true,
                   ValueFromRemainingArguments=$false,
                   Position=0)]
 
        $Name
 
)
 
 
 
$RootTPB = 'https://thepiratebay.mn'
 
Write-Host "If you use a VPN Service, please connect now." -ForegroundColor DarkRed
 
$TPB = Invoke-WebRequest "https://thepiratebay.mn/search/$($Name)/0/99/200" -DisableKeepAlive
 
 
$narrow720 = $TPB.Links.Href -match '720p' | select -First 1
$narrow1080 = $TPB.Links.Href -match '1080p' | select -First 1
$narrowDvd = $TPB.Links.Href -match 'DvDrip' | select -First 1
 
$720split = $narrow720 -split '/'
$1080split = $narrow1080 -split '/'
$dvdsplit = $narrowDvd -split '/'
 
 
    if($narrow720 -eq $null){Write-Host "Nothing could be found for $name in 720p" -ForegroundColor Red }
              Else {Write-Host "We managed to find $Name in 720p, the filename for this is download is $($720split[3])" -ForegroundColor Yellow}
 
 
    if($narrow1080 -eq $null){Write-Host "Nothing could be found for $name in 1080p" -ForegroundColor Red}
              Else {Write-Host "We managed to find $Name in 1080p, the filename for this is download is $($1080split[3])" -ForegroundColor Yellow}
 
 
    if($narrowDvd -eq $null){Write-Host "Nothing could be found for $name in DVD rip" -ForegroundColor Red}
              Else {Write-Host "We managed to find $Name in DVDRip, the filename for this download is $($dvdsplit[3])" -ForegroundColor Yellow}
                     if ($narrow720 -and $narrow1080 -and $narrowDvd -eq $null){
                       Write-Host "Sorry, nothing could be found with the name $name"
                                                                                break
}
 
 
[string][ValidateSet("1080", "720", "DVD", "None")]$Continue = Read-host "Which of these would you like to download? (1080/720/DVD/None)"
 
    switch($Continue){
        '1080' {Write-Host "Fetching download link for 1080p download" -ForegroundColor Yellow}
        '720'  {Write-Host "Fetching download link for 720p download" -ForegroundColor Yellow}
        'DVD'  {Write-Host "Fetching download link for DVD Rip download" -ForegroundColor Yellow}
        'None' {break }
        default { break }
            }
if ($Continue -ne 'None'){
    switch ($Continue){
 
    '1080' { $download = Invoke-WebRequest "$RootTPB$($narrow1080)" -DisableKeepAlive
    $tor = $download.links.href -match 'magnet' | select -First 1}
 
    '720'  {$download = Invoke-WebRequest "$RootTPB$($narrow720)" -DisableKeepAlive
    $tor = $download.links.href -match 'magnet' | select -First 1}
 
    'DVD'  {$download = Invoke-WebRequest "$RootTPB$($narrowDvd)" -DisableKeepAlive
    $tor = $download.links.href -match 'magnet' | select -First 1}
 
 
        }
 }
 
if ($Continue -ne 'None'){
$WorkingDIr = (Get-Item HKLM:\SOFTWARE\Wow6432Node\qBittorrent).GetValue(‘InstallLocation’)
    if ($WorkingDIr -eq $null){
 
      Write-Error "Error: Cannot find QBittorrent on your Computer, please head over http://www.qbittorrent.org/ to download." -ForegroundColor Red
    }
    Else {Set-Location $WorkingDIr
    .\qbittorrent.exe $tor}
    }
 
}