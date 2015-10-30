@{
 Description = 'Replaces text that equals to a defined environment variable with that environment variable'
 IgnoreSyntaxErrors = $false
 Tooltip = @'
To make a script portable, it is discouraged to hard code path names.
Path names such as the path to a user profile or the windows folder may change.
Instead, system locations should be referred to by environment variables.
This script:
- searches for literal strings
- checks to see if the string content starts with a predefined environment variable
- replaces the literal string that matches the environment variable with the environment variable
'@
 #Icon = 'image.png'
 Script = 'ConvertTextToEnvironmentVariable.ps1'
 RecommendedOrder = 1
 GUID = 'd478a60f-4f37-4d56-9d14-8422eb535cee'
 GroupGUID = 'a6c72f01-53dc-4324-bba5-765f0e3827a4'

}