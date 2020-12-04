Write-Host 'ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ'
cd "$PSScriptRoot\..\src\MicroServiceZ"
dapr run --app-id appz --app-port 5050 dotnet run

