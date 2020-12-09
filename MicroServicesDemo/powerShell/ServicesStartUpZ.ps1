$newSize = $Host.UI.RawUI.WindowSize
$newSize.Height = 22
$Host.UI.RawUI.WindowSize= $newSize

$Host.UI.RawUI.WindowTitle = "MicroServiceZ | AppZ | Deep Layer"

cd "$PSScriptRoot\..\src\MicroServiceZ"
dapr run --app-id appz --app-port 5050 dotnet run