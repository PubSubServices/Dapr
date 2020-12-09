$newSize = $Host.UI.RawUI.WindowSize
$newSize.Height = 22
$Host.UI.RawUI.WindowSize= $newSize

$Host.UI.RawUI.WindowTitle = "MicroServiceA | AppA | Middle Layer"


cd "$PSScriptRoot\..\src\MicroServiceA"
dapr run --app-id appa --app-port 5010 dotnet run

