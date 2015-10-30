# this file defines the UI elements that should be visible for a given scenario.

# You can create as many of these configuration files as you need.
# For example, create a "beginners" level UI, or a specialized UI appearance 
# with only a subset of available features.

# To be accessible to ISESteroids, place this file in the "Level" subfolder inside
# of the ISESteroids program folder.

# All files that you place there will appear in the menu "Level". 
# The menu picks up the file name, so be sure to apply a meaningful name to your 
# configuration files.

# In the menu "Level", you can choose which file you would like to apply.

@{
	Tooltip = @"
Focuses on the basic features. Perfect for PowerShell beginners.
"@
	WelcomeMessage = @"
Focuses on the most important features.
Here are some hints to get you started: 

Click any command or language element. The help panel will explain it to you.

Press CTRL+J in the editor to open your code snippet selector. 
It provides many useful examples.

Once you are hungry for more, open the menu "Level" (it is blinking right now), 
and choose a higher level for more features.
"@
	Difficulty = 1
	MinimumDifficultyForSnippets = 1
	MaximumDifficultyForSnippets = 3
	ToggleButtonNavigationBar = $false
	AddOnVariableMonitor = $true
	AddOnVariableMonitorShowCallStack = $false
	AddOnCompletionText = $false
	AddOnScriptFixer = $false
	AddOnVersionControl = $false
	ToolBlankScriptFromTemplate = $false
	ToolCodeIndent = $true
	ToolNoLineMarker = $false
	ToolSimpleLineMarker = $false
	ToolAdvancedLineMarker = $false
	ToolTrackerMargin = $false
	ToolAutoIndent = $false
	ToolVisibleWhitespace = $false
	ToolLineWrap = $false
	ToolIntelliSelect = $false
	ToolDuplicateLine = $false
	ToolMoveLineUp = $false
	ToolMoveLineDown = $false
	ToolExpandOutlining = $false
	ToolToggleOutliningLevel1 = $false
	ToolToggleOutliningLevel2 = $false
	ToolToggleOutliningCurrentRegion = $false
	ToolOutliningToggleComments = $false
	ToolCreateNewSnippet = $false
	ToolOpenProfileScript = $true
	ToolShowBookmarks = $false
	ToolToggleLiteralView = $false
	ToolPrint = $true
	ToolCreateXPSDocument = $false
	ToolHelp = $true
	ToolToggleBlockComment = $false
	ToolSelectTheme = $true
	ToolRestartISE = $false
	ToolShowSettings = $false
	ToolToggleScriptMap = $false
	ToolCreateApplication = $false
	MenuMyCommands = $false
	MenuDebug = $false
	MenuAddOns = $false
	MenuFile = $false
	ContextMenuCloneView = $false
	ContextMenuDebuggerBreakpoints = $false
	ContextMenuProfiling = $false
	ContextMenuCustomCommandOnTokenLevel = $false
	AdvancedFeatureDecompile = $false
	AdvancedFeatureExportFunctionToModule = $false
	AdvancedFeatureNewUntitledDocument = $false
	AdvancedFeatureFunctionFromSelection = $false
	AdvancedFeatureEnableThemeAdjustment = $false
	AdvancedFeatureMultipleVariableRename = $false
	CustomFileTypes = $false
	FunctionReferences = $false
	FunctionGap = $false
	DebuggerMargin = $false
	CommunityPane = $false
	RiskAssessment = $false
	DigitalSigning = $false
	SourceCodeTools = $false
	PowerShellTestModes = $false
	CreateCodeSnippets = $false
	EditCodeSnippets = $false
	HideNonMatchingResults = $false
	SaveWorkstateOnExit = $false
	PowerShellXRay = $false
	AdvancedDebuggingTools = $false
	CompatAware = $false
}