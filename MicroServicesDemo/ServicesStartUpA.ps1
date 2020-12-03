Write-Host 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA'
cd "$PSScriptRoot\src\MicroServiceA"
dapr run --app-id pubsuba --app-port 5010 dotnet run

