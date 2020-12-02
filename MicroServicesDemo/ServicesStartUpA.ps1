Write-Host 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA'
cd C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\src\MicroServiceA
dapr run --app-id pubsub --app-port 5010 --dapr-http-port 3500 dotnet run

