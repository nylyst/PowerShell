function Search-TFS
{
	[CmdletBinding()]
	Param(
		[Parameter(Mandatory=$true)]
		[string] $searchTerm
	)
	Process
	{
		write-host ("Hello " + $searchTerm + "!")
	}
}