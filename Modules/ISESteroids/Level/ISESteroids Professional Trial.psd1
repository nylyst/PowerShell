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
Enables the features in ISESteroids 2.0 Professional.
Use this item to test-drive the ISESteroids 2.0 Professional Feature Set.
ISESteroids 2.0 Professional contains a feature subset of ISESteroids 2.0 Enterprise.
"@
	WelcomeMessage = @"
Enables the features in ISESteroids 2.0 Professional.
Use this item to test-drive the ISESteroids 2.0 Professional Feature Set.
ISESteroids 2.0 Professional contains a feature subset of ISESteroids 2.0 Enterprise.
"@
	Difficulty = 9
	MinimumDifficultyForSnippets = 1
	MaximumDifficultyForSnippets = 9
	AddOnScriptFixer = $false
	AddOnVersionControl = $false
	AddOnVariableMonitorShowCallStack = $false
	ToolCreateNewSnippet = $false
	ToolToggleScriptMap = $false
	MenuMyCommands = $false
	ContextMenuCloneView = $false
	ContextMenuDebuggerBreakpoints = $false
	ContextMenuProfiling = $false
	ContextMenuCustomCommandOnTokenLevel = $false
	AdvancedFeatureDecompile = $false
	AdvancedFeatureExportFunctionToModule = $false
	AdvancedFeatureNewUntitledDocument = $false
	AdvancedFeatureFunctionFromSelection = $false
	AdvancedFeatureMultipleVariableRename = $false
	CustomFileTypes = $false
	FunctionReferences = $false
	FunctionGap = $false
	
	DigitalSigning = $false
	SourceCodeTools = $false
	PowerShellTestModes = $false
	
	DebuggerMargin = $false
	HideNonMatchingResults = $false
	SaveWorkstateOnExit = $false
	PowerShellXRay = $false
	AdvancedDebuggingTools = $false
	CompatAware = $false
	WPFDesign = $false
}