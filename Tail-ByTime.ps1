<#
.SYNOPSIS
Svendsen Tech's generic script for removing empty directories from a
directory tree structure.

Finds or removes/deletes empty directories recursively from the drive or
directory you specify.

You will need to use the -VerifyNoEmpty parameter or multiple
runs to get rid of nested empty directories. See the -VerifyNoEmpty parameter's
description for further details.

This isn't the most efficient approach as the ones I can think of seem to
increase the script's complexity considerably. It should be useful for a
multitude of use cases.

Author: Joakim Svendsen

.PARAMETER Path
Required. Base root path to iterate recursively.
.PARAMETER Find
Default behaviour where it just prints. Overrides -Remove if both are specified.
.PARAMETER Remove
Removes all empty dirs (as in actually deletes them with Remove-Item).
.PARAMETER VerifyNoEmpty
Makes the script run until no empty directories are found. This is in order
to handle nested empty directories, as in a directory that currently only
contains an empty directory would be empty after the first run/iteration and
need to be remove in a subsequent run. Specifying this parameter causes the
script to run until it's done a complete run without finding a single empty
directory. This might be time-consuming depending on the size of the directory
tree structure.

If there is an error while deleting a directory, it will not run again, to
avoid an infinite loop.
#>

param(
    [Parameter(Mandatory=$true)][string] $Path,
    [switch] $Find,
    [switch] $Remove,
    [switch] $VerifyNoEmpty
    )

Set-StrictMode -Version 2.0
$ErrorLog   = 'Tail-ByTime-error.log'

######## START OF FUNCTIONS ########

    
} # end of function Iterate-And-Remove-Empty-Dirs

######## END OF FUNCTIONS ########
