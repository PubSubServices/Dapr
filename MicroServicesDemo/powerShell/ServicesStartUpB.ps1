$newSize = $Host.UI.RawUI.WindowSize
$newSize.Height = 22
$Host.UI.RawUI.WindowSize= $newSize

$Host.UI.RawUI.WindowTitle = "MicroServiceB | AppB | Public Facing Layer"
cd "$PSScriptRoot\..\src\MicroServiceB"
dapr run --app-id appb --app-port 5030 dotnet run

