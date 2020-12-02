Write-Host 'BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB'
cd C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\src\MicroServiceB
dapr run --app-id pubsub --app-port 5020 --dapr-http-port 3500 dotnet run

