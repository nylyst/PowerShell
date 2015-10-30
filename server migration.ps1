# Server Migration second file
# pulls which servers to work on from file.
# Created by David Lipps
 
# logs everything performed
$date = Get-Date
Start-Transcript -Path C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt
 
#Gets the username and password for remote access.
$cred = Get-Credential -Message "Please use proper domain\username_admin format"
 
#Imports file filled with the information in the header fields. File itself will not contain any headers.
$file = Import-Csv -Path C:\ServerMigration\file2.csv -Header "Server","IP6Address","IP6Subnet","IP6DFGateway","IP4Address","IP4Subnet","IP4DFGateway","IP4mask","DNSSecondary"
 
#creates hashtable keys
$file.Keys
 
#for easy lookup of information based on server name
$lookup = $file | Group-Object -AsHashTable -AsString -Property server
 
New-PSSessionOption -OpenTimeout 2 -CancelTimeout 2 -MaxConnectionRetryCount 2 -OperationTimeout 2 -MaximumRedirection 2 -IdleTimeout 2
 
Start-Sleep 20
 
#Loop through Hash table based on Server
foreach ($server in $file.server)
{
#Writes which server is being worked on for the log file.
$server | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
 
#Working Code for next migration file parts figured out how to use it in this file::: $lookup[$server] | select -ExpandProperty ip4address
 
 
# Determine if virtual or physical. Virtual servers will be more complicated to deal with since they will utilize multiple adapters with different vendors.
$manufacturer=gwmi win32_computersystem -ComputerName $server | select -ExpandProperty manufacturer
If($manufacturer -match "VMware")
    {
        # First step figure out which version of Windows is being used. This should normally be a switch but theoretically we are only using this on 2008/2012 machines.
        $osversion = gwmi win32_operatingsystem -ComputerName $server | select -expandproperty caption
 
        If($osversion -match "server 2012")
            {
 
                # Logic to determine which course of action to take. This should find only adapters that are connected through static or dhcp address.
                $networkadapter = Get-WmiObject win32_networkadapter -ComputerName $server -Filter "netconnectionstatus = 2" | select name,interfaceindex
                if($networkadapter -match "intel")
                    {
                        if ($networkadapter -match "vmxnet3")
                            {
                                $netswitch = 1
                            }
                        Else
                            {
                                $netswitch = 2
                            }
                    }
                Else
                    {
                        if ($networkadapter -match "vmxnet3")
                            {
                                $netswitch = 3
                            }
                        Else
                            {
                                $netswitch = 4
                            }
                    }
 
            # Create hash table to easily work with network adapters based on name
            $nethashtable = $null
            $nethashtable = @{}
            foreach($n in $networkadapter)
                {
                    $nethashtable.add($n.name,$n.interfaceindex)
                }
 
            #storing information in easy to access variable names.
            $servip4add = $lookup[$server] | select -ExpandProperty ip4address
            $servip4prefix = $lookup[$server] | select -ExpandProperty ip4subnet
            $servip6add = $lookup[$server] | select -ExpandProperty ip6address
            $servip4dfg = $lookup[$server] | select -ExpandProperty ip4dfgateway
            $servip6dfg = $lookup[$server] | select -ExpandProperty ip6dfgateway
 
   
            Write-Host $netswitch #troubleshooting information please ignore this line.
       
            # Action to take based on logic from above.
            Switch ($netswitch)
                {
 
                # Action 1 VMXNet3 & Intel Adapter
                1
                    {
                        $netvalue = $nethashtable.GetEnumerator() | where {$_.key -like 'vmxnet3*'}
                        [int]$netindex = $netvalue | select -ExpandProperty value
                        $othernetindex = $netindex - 1
                        $oldipinfo = gwmi win32_networkadapterconfiguration -computername $server -filter "index = '$othernetindex'" | select index,ipaddress,defaultipgateway
                        #write-host $oldipinfo
                        $oldip = $oldipinfo | select -ExpandProperty ipaddress
                        $oldip = $oldip | select -First 1
                        $oldgw = $oldipinfo | select -ExpandProperty defaultipgateway
                        $oldgw = $oldgw | select -First 1
                        #Write-Host "old ip is"
                        #write-host $oldip
                        #write-host "old gw is"
                        #write-host $oldgw
                       
                        Write-Host "Changing $server IPv6 information and setting DNS information" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { set-netipinterface -interfaceindex $using:netindex -addressfamily ipv4 -dhcp disabled ; set-netipinterface -interfaceindex $using:netindex -addressfamily ipv6 -dhcp disabled ; new-netroute -interfaceindex $using:netindex -addressfamily ipv6 -nexthop $using:servip6dfg -destinationprefix ::/0 ; new-netroute -interfaceindex $using:netindex -addressfamily ipv4 -nexthop $using:servip4dfg -destinationprefix 0.0.0.0/0 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv6 -ipaddress $using:servip6add -prefixlength 64 ; set-DnsClientServerAddress -InterfaceIndex $using:netindex -ServerAddresses $dns1,$dns2 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv4 -ipaddress $using:servip4add -prefixlength $using:servip4prefix ; start-sleep 5 }
                        write-host "Removing Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-Command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netroute -interfaceindex $using:netindex -nexthop $using:oldgw }
                        write-host "removing old IPv4 address. May take up to 4 minutes to disregard session"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        invoke-command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netipaddress -interfaceindex $using:netindex -ipaddress $using:oldip }
                       
                       
                        Write-Host "Don't forget to make sure the vlan is set to" $servip6add.Substring(14,4) "for server" $server ". Also remove the old E1000 adapter. Please set jumbo frames back to 9000"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
 
 
 
                        ;break # Exit switch statement.
                 }
 
               # Action 2 only VMXNet3 Adapter
              2
                 {
                        $netvalue = $nethashtable.GetEnumerator() | where {$_.key -like 'vmxnet3*'}
                        [int]$netindex = $netvalue | select -ExpandProperty value
                        $othernetindex = $netindex - 1
                        $oldipinfo = gwmi win32_networkadapterconfiguration -computername $server -filter "index = '$othernetindex'" | select index,ipaddress,defaultipgateway
                        #write-host $oldipinfo
                        $oldip = $oldipinfo | select -ExpandProperty ipaddress
                        $oldip = $oldip | select -First 1
                        $oldgw = $oldipinfo | select -ExpandProperty defaultipgateway
                        $oldgw = $oldgw | select -First 1
                        #Write-Host "old ip is"
                        #write-host $oldip
                        #write-host "old gw is"
                        #write-host $oldgw
                       
                        Write-Host "Changing $server IPv6 information and setting DNS information" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { set-netipinterface -interfaceindex $using:netindex -addressfamily ipv4 -dhcp disabled ; set-netipinterface -interfaceindex $using:netindex -addressfamily ipv6 -dhcp disabled ; new-netroute -interfaceindex $using:netindex -addressfamily ipv6 -nexthop $using:servip6dfg -destinationprefix ::/0 ; new-netroute -interfaceindex $using:netindex -addressfamily ipv4 -nexthop $using:servip4dfg -destinationprefix 0.0.0.0/0 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv6 -ipaddress $using:servip6add -prefixlength 64 ; set-DnsClientServerAddress -InterfaceIndex $using:netindex -ServerAddresses $dns1,$dns2 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv4 -ipaddress $using:servip4add -prefixlength $using:servip4prefix ; start-sleep 5 }
                        write-host "Removing Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-Command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netroute -interfaceindex $using:netindex -nexthop $using:oldgw }
                        write-host "removing old IPv4 address. May take up to 4 minutes to disregard session"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        invoke-command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netipaddress -interfaceindex $using:netindex -ipaddress $using:oldip }
                       
                       
                        Write-Host "Don't forget to make sure the vlan is set to" $servip6add.Substring(14,4) "for server" $server "and change Jumbo Packets to 9000."  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
 
 
 
                        ;break # Exit switch statement.
                   
                    }
            # Action 3
            3
                   {
                        $netvalue = $nethashtable.GetEnumerator() | where {$_.key -like 'vmxnet3*'}
                        [int]$netindex = $netvalue | select -ExpandProperty value
                        $othernetindex = $netindex - 1
                        $oldipinfo = gwmi win32_networkadapterconfiguration -computername $server -filter "index = '$othernetindex'" | select index,ipaddress,defaultipgateway
                        #write-host $oldipinfo
                        $oldip = $oldipinfo | select -ExpandProperty ipaddress
                        $oldip = $oldip | select -First 1
                        $oldgw = $oldipinfo | select -ExpandProperty defaultipgateway
                        $oldgw = $oldgw | select -First 1
                        #Write-Host "old ip is"
                        #write-host $oldip
                        #write-host "old gw is"
                        #write-host $oldgw
                       
                        Write-Host "Changing $server IPv6 information and setting DNS information" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { set-netipinterface -interfaceindex $using:netindex -addressfamily ipv4 -dhcp disabled ; set-netipinterface -interfaceindex $using:netindex -addressfamily ipv6 -dhcp disabled ; new-netroute -interfaceindex $using:netindex -addressfamily ipv6 -nexthop $using:servip6dfg -destinationprefix ::/0 ; new-netroute -interfaceindex $using:netindex -addressfamily ipv4 -nexthop $using:servip4dfg -destinationprefix 0.0.0.0/0 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv6 -ipaddress $using:servip6add -prefixlength 64 ; set-DnsClientServerAddress -InterfaceIndex $using:netindex -ServerAddresses $dns1,$dns2 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv4 -ipaddress $using:servip4add -prefixlength $using:servip4prefix ; start-sleep 5 }
                        write-host "Removing Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-Command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netroute -interfaceindex $using:netindex -nexthop $using:oldgw }
                        write-host "removing old IPv4 address. May take up to 4 minutes to disregard session"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                        Invoke-command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netipaddress -interfaceindex $using:netindex -ipaddress $using:oldip }
                       
                       
                        Write-Host "Don't forget to make sure the vlan is set to" $servip6add.Substring(14,4) "for server" $server "and set Jumbo Packets to 9000"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
 
 
 
                        ;break # Exit switch statement.
                   
                   }
 
 
            # Action 4 doesn't have either adapter
            4
                   {
                        Write-Host "Problem occured Host doesn't contain VMXnet3 adapter. Does '$server' have the right adapter installed?"
                        ;break # Exit switch statement.
                   }
 
            } # End of switch.
 
           
           
 
 
       } # This bracket is end of Virtual server 2012 config
       
   Else
       {
           # Logic to determine which course of action to take. This should find only adapters that are connected through static or dhcp address.
           $networkadapter = Get-WmiObject win32_networkadapter -ComputerName $server -Filter "netconnectionstatus = 2" | select name,interfaceindex
           if($networkadapter -match "intel")
               {
                   if ($networkadapter -match "vmxnet3")
                       {
                           $netswitch = 1
                       }
                   Else
                       {
                           $netswitch = 2
                       }
               }
           Else
               {
                   if ($networkadapter -match "vmxnet3")
                      {
                           $netswitch = 3
                      }
                   Else
                      {
                           $netswitch = 4
                      }
               }
 
 
 
           # Create hash table to easily work with network adapters based on name
           $nethashtable = $null
           $nethashtable = @{}
           foreach($n in $networkadapter)
               {
                   $nethashtable.add($n.name,$n.interfaceindex)
               }
 
            #storing information in easy to access variable names.
            $servip4add = $lookup[$server] | select -ExpandProperty ip4address
            $servip4prefix = $lookup[$server] | select -ExpandProperty ip4subnet
            $servip6add = $lookup[$server] | select -ExpandProperty ip6address
            $servip4dfg = $lookup[$server] | select -ExpandProperty ip4dfgateway
            $servip6dfg = $lookup[$server] | select -ExpandProperty ip6dfgateway
            $servip4mask = $lookup[$server] | select -ExpandProperty ip4mask
           
            $netvalue = $nethashtable.GetEnumerator() | where {$_.key -like 'vmxnet3*'}
            [int]$netindex = $netvalue | select -ExpandProperty value
   
            Write-Host $netswitch #troubleshooting information please ignore this line.
       
            # Action to take based on logic from above.
            Switch ($netswitch)
            {
 
                # Action 1 VMXNet3 & Intel Adapter
                1
                    {
                         Write-Host "Changing $server DNS Primary address"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set dns $using:netindex static "$dns1" } #good working code
                         Write-Host "Changing Secondary DNS"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 add dns $using:netindex "$dns2" index=2 } #good working code
                         Write-Host "Adding IPV6 Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add route ::/0 $using:netindex " " $using:servip6dfg } #good working code
                         Write-Host "Adding IPV6 Address"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add address $using:netindex " " $using:servip6add } #good working code
                         Write-Host "Removing old IPV4 Address. It may take up to 4 minutes to disregard connection"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set address $using:netindex static $using:servip4add $using:servip4mask $using:servip4dfg }
                         Write-Host "Don't forget to uninstall the old E1000 adapter on '$server' and set the vlan for the VMXNet3 Adapter to "$servip6add.Substring(14,4) "Please set Jumbo Packets to 9000"   | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         ;break
                    }
 
                # Action 2 Action 2 only intel
                2
                    {
                         #Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set dns $using:netindex static "$dns1" } #good working code
                         #Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 add dns $using:netindex "$dns2" index=2 } #good working code
                         #Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add route ::/0 $using:netindex " " $using:servip6dfg } #good working code
                         #Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add address $using:netindex " " $using:servip6add } #good working code
                         #Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set address $using:netindex static $using:servip4add $using:servip4mask $using:servip4dfg }
                         write-host "Server $server only has old adapter installed please install new VMXnet3 adapter and set the vlan to "$servip6add.Substring(14,4)  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         ;break
                    }
                # Action 3 only vmxnet 3 adapter
                3
                    {
                         Write-Host "Changing $server DNS Primary address"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set dns $using:netindex static "$dns1" } #good working code
                         Write-Host "Changing Secondary DNS"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 add dns $using:netindex "$dns2" index=2 } #good working code
                         Write-Host "Adding IPV6 Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add route ::/0 $using:netindex " " $using:servip6dfg } #good working code
                         Write-Host "Adding IPV6 Address"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add address $using:netindex " " $using:servip6add } #good working code
                         Write-Host "Removing old IPV4 Address. It may take up to 4 minutes to disregard connection"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set address $using:netindex static $using:servip4add $using:servip4mask $using:servip4dfg }
                         Write-Host "Don't forget to change the vlan to "$servip6add.Substring(14,4) "on server " $server "Please set Jumbo Packets to 9000" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                         ;break
                    }
                # Action 4 neither adapter
                4
                    {
                        ;break
                    }
            } # End of switch
 
 
 
       } # This bracket is end of virtual server 2008 config
           
 
 
 
} # This bracket is end of virtual server configuration
 
#This area for physical servers
Else
    {
 
        # First step figure out which version of Windows is being used. This should normally be a switch but theoretically we are only using this on 2008/2012 machines.
        $osversion = gwmi win32_operatingsystem | select -expandproperty caption
 
        # Server 2012 Physical machine
        If($osversion -match "server 2012")
            {
                $netindex = Get-WmiObject win32_networkadapter -Filter "netconnectionstatus = 2" | select name,interfaceindex
               
                               
                #storing information in easy to access variable names.
                $servip4add = $lookup[$server] | select -ExpandProperty ip4address
                $servip4prefix = $lookup[$server] | select -ExpandProperty ip4subnet
                $servip6add = $lookup[$server] | select -ExpandProperty ip6address
                $servip4dfg = $lookup[$server] | select -ExpandProperty ip4dfgateway
                $servip6dfg = $lookup[$server] | select -ExpandProperty ip6dfgateway
                $servip4mask = $lookup[$server] | select -ExpandProperty ip4mask
 
                $netvalue = $nethashtable.GetEnumerator() #| where {$_.key -like 'vmxnet3*'}
                [int]$netindex = $netvalue | select -ExpandProperty value
                $othernetindex = $netindex - 1
                $oldipinfo = gwmi win32_networkadapterconfiguration -computername $server -filter "index = '$othernetindex'" | select index,ipaddress,defaultipgateway
                #write-host $oldipinfo
                $oldip = $oldipinfo | select -ExpandProperty ipaddress
                $oldip = $oldip | select -First 1
                $oldgw = $oldipinfo | select -ExpandProperty defaultipgateway
                $oldgw = $oldgw | select -First 1
                #Write-Host "old ip is"
                #write-host $oldip
                #write-host "old gw is"
                #write-host $oldgw
                       
                Write-Host "Changing $server IPv6 information and setting DNS information" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { set-netipinterface -interfaceindex $using:netindex -addressfamily ipv4 -dhcp disabled ; set-netipinterface -interfaceindex $using:netindex -addressfamily ipv6 -dhcp disabled ; new-netroute -interfaceindex $using:netindex -addressfamily ipv6 -nexthop $using:servip6dfg -destinationprefix ::/0 ; new-netroute -interfaceindex $using:netindex -addressfamily ipv4 -nexthop $using:servip4dfg -destinationprefix 0.0.0.0/0 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv6 -ipaddress $using:servip6add -prefixlength 64 ; set-DnsClientServerAddress -InterfaceIndex $using:netindex -ServerAddresses $dns1,$dns2 ; new-netipaddress -interfaceindex $using:netindex -addressfamily ipv4 -ipaddress $using:servip4add -prefixlength $using:servip4prefix ; start-sleep 5 }
                write-host "Removing Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netroute -interfaceindex $using:netindex -nexthop $using:oldgw }
                write-host "removing old IPv4 address. May take up to 4 minutes to disregard session"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-command -computername $server -credential $cred -verbose -Authentication Negotiate -scriptblock {remove-netipaddress -interfaceindex $using:netindex -ipaddress $using:oldip }
                       
                       
                Write-Host "Don't forget to make sure the vlan is set to" $servip6add.Substring(14,4) "for server" $server "Also, change Jumbo Packets to 9000" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
 
 
 
                       
                   
 
            } # End 2012 Physical machine block
 
       
        Else
        #This block for Server 2008 Physicals
        {
            $netindex = Get-WmiObject win32_networkadapter -Filter "netconnectionstatus = 2" | select name,interfaceindex              
            #storing information in easy to access variable names.
            $servip4add = $lookup[$server] | select -ExpandProperty ip4address
            $servip4prefix = $lookup[$server] | select -ExpandProperty ip4subnet
            $servip6add = $lookup[$server] | select -ExpandProperty ip6address
            $servip4dfg = $lookup[$server] | select -ExpandProperty ip4dfgateway
            $servip6dfg = $lookup[$server] | select -ExpandProperty ip6dfgateway
            $servip4mask = $lookup[$server] | select -ExpandProperty ip4mask
 
            $netvalue = $nethashtable.GetEnumerator() #| where {$_.key -like 'vmxnet3*'}
                [int]$netindex = $netvalue | select -ExpandProperty value
                $othernetindex = $netindex - 1
                $oldipinfo = gwmi win32_networkadapterconfiguration -computername $server -filter "index = '$othernetindex'" | select index,ipaddress,defaultipgateway
                #write-host $oldipinfo
                $oldip = $oldipinfo | select -ExpandProperty ipaddress
                $oldip = $oldip | select -First 1
                $oldgw = $oldipinfo | select -ExpandProperty defaultipgateway
                $oldgw = $oldgw | select -First 1
                #Write-Host "old ip is"
                #write-host $oldip
                #write-host "old gw is"
                #write-host $oldgw
 
                Write-Host "Changing $server DNS Primary address"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set dns $using:netindex static "$dns1" } #good working code
                Write-Host "Changing Secondary DNS"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 add dns $using:netindex "$dns2" index=2 } #good working code
                Write-Host "Adding IPV6 Default Gateway"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add route ::/0 $using:netindex " " $using:servip6dfg } #good working code
                Write-Host "Adding IPV6 Address"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv6 add address $using:netindex " " $using:servip6add } #good working code
                Write-Host "Removing old IPV4 Address. It may take up to 4 minutes to disregard connection"  | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
                Invoke-Command -ComputerName $server -Credential $cred -Verbose -ScriptBlock { netsh interface ipv4 set address $using:netindex static $using:servip4add $using:servip4mask $using:servip4dfg }
                Write-Host "Don't forget to change the vlan to "$servip6add.Substring(14,4) "on server " $server "and set Jumbo Packets to 9000" | Out-File -FilePath C:\ServerMigration\transcriptpart1date$(get-date -Format ddmmyyyy).txt -Append
 
 
 
        } # End block for server 2008 physicals
 
 
 
    } # This bracket is end of physical server configuration
 
 
 
} # End of For Each loop
 
#Stops Logging at EoF.
write-host "End of Migration Part 2"
Stop-Transcript