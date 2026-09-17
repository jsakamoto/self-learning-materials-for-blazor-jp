# This script updates the release notes of old releases on GitHub.

# This script requires "gh" command (GitHub CLI) is installed.
# "gh" command ... https://cli.github.com/

# Sign in with an account that has write access to this repository, by "gh auth login".
# If you have signed in with multiple accounts, switch the active account by "gh auth switch".

# The tag of the release that old releases should refer to. It is excluded from the update.
$latestRelease = "10.0.0"
$latestReleaseTag = "doc/$latestRelease"
$oldReleaseDoc = "### Blazor v.$latestRelease に対応した [$latestRelease](https://github.com/jsakamoto/self-learning-materials-for-blazor-jp/releases/tag/doc%2F$latestRelease) をリリースしています。そちらをご利用ください。"

$rootDir = Join-Path $PSScriptRoot ".." -Resolve
Push-Location $rootDir

$oldReleaseTags = gh release list -L 100 --json tagName --jq '.[].tagName' | Where-Object { $_ -ne $latestReleaseTag }

$oldReleaseTags | ForEach-Object {
    Write-Host -ForegroundColor Yellow ("Processing `"{0}`"..." -f $_)
    gh release edit $_ --notes $oldReleaseDoc
}

Pop-Location
