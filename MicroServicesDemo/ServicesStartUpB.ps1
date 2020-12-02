Write-Host 'BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB'
cd C:\projects\Publix\MicroServicesDemo\src\MicroServiceB
dapr run --app-id pubsubB --app-port 5020 --dapr-http-port 3500 dotnet run

