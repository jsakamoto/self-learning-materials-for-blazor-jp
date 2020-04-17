# This script requires "hub" command is installed.
# "hub" command ... https://github.com/github/hub

$oldReleaseTags = (
    # "doc/3.2.0-preview4.20210.8",
    "doc/3.2.0-preview3.20168.3",
    "doc/3.2.0-preview1.20073.1b",
    "doc/3.2.0-preview1.20073.1",
    "doc/3.0.0-preview9.19457.4",
    "doc/3.0.0-preview9",
    "doc/3.0.0-preview8",
    "doc/3.0.0-preview7",
    "doc/3.0.0-preview6",
    "doc/3.0.0-preview5",
    "doc/3.0.0-preview4",
    "doc/0.9.0d",
    "doc/0.9.0",
    "doc/0.8.0",
    "doc/0.7.0",
    "doc/0.6.0",
    "doc/0.5.1",
    "doc/0.4.0",
    "doc/0.3.0-b-2",
    "0.3.0-b",
    "0.3.0")

$rootDir = Join-Path $PSScriptRoot ".." -Resolve
Push-Location $rootDir

$oldReleaseDoc = Get-Content .\src\old-release-document.md -Encoding UTF8
$utf8 = New-Object "System.Text.UTF8Encoding" -ArgumentList @($false)
$tmpPath = (Resolve-Path .\src).Path + "\~tmp.md"

$oldReleaseTags | ForEach-Object {
    Write-Host -ForegroundColor Yellow ("Processing `"{0}`"..." -f $_)
    $oldReleaseTag = $_
    $oldReleaseTitle = $oldReleaseTag -replace "^doc/", ""
    
    [IO.File]::WriteAllLines($tmpPath, ($oldReleaseTitle, "", $oldReleaseDoc), $utf8)
    
    hub release edit $oldReleaseTag -F $tmpPath
}

Remove-Item $tmpPath > $null

Pop-Location
