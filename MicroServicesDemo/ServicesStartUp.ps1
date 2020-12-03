#dapr stop

#start powershell "$PSScriptRoot\ServicesStartupTutorial.ps1"
#dapr run --dapr-http-port 3500
#start powershell "$PSScriptRoot\ListenerC.ps1"
start powershell "$PSScriptRoot\ServicesStartUpA.ps1"
start powershell "$PSScriptRoot\ServicesStartUpB.ps1"
