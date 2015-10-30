@{
 GroupName = 'Code Quality Improvement'
 Name = 'Add/Update #requires Statement'
 Description = 'Adds or updates a #requires statement, indicating the necessary PowerShell version and required modules.'
 Tooltip = @'
A properly defined #requires statement defines the PowerShell version and additional PowerShell modules required by this script.
PowerShell will enforce the requirements, load required modules, or emit an exception if the requirements are not met.
'@
 Icon = 'image.png'
 Script = 'AddRequirements.ps1'
 RecommendedOrder = 1000
 GUID = 'ad95b5dd-20f4-49f4-909f-205b93877123'
 GroupGUID = '40d484c7-8c8b-432f-883b-b06ff542ab3d'
}