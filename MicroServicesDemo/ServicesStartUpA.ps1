Write-Host 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA'
cd "$PSScriptRoot\src\MicroServiceA"
dapr run --app-id pubsubA --app-port 5010 --dapr-http-port 3500 dotnet run

