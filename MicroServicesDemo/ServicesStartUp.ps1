# cd C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\src\Tutorial
#dapr run --app-id pubsub --app-port 5000 --dapr-http-port 3500 dotnet run

#cd C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\src\MicroServiceA
#dapr run --app-id pubsub --app-port 5010  dotnet run
start powershell "C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\ServicesStartupTutorial.ps1"
start powershell "C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\ServicesStartUpA.ps1"
start powershell "C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\ServicesStartUpB.ps1"
#invoke-expression 'cmd /K start powershell -Command { `
    #cd C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\src\MicroServiceB `
    #dapr run --app-id pubsub --app-port 5020 dotnet run `
    #}'

#cd C:\Users\gregory.mertens\source\repos\Publix\MicroServicesDemo\src\MicroServiceB
#dapr run --app-id pubsub --app-port 5020 dotnet run

