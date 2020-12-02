Write-Host 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA'
cd C:\projects\Publix\MicroServicesDemo\src\MicroServiceA
dapr run --app-id pubsubA --app-port 5010 --dapr-http-port 3500 dotnet run

