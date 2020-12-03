Write-Host 'BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB'
cd "$PSScriptRoot\src\MicroServiceB"
dapr run --app-id pubsubb --app-port 5030 dotnet run

