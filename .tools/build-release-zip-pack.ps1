# Get latest branch name which starts with "v.x.x..."
$remote = "origin"
$baseBranch = "v.10.0.0"

# Fetch the latest changes from the remote repository.
git fetch $remote

# Set up the working directories.
$rootDir = Join-Path $PSScriptRoot ".." -Resolve
Push-Location $rootDir
$baseDir = Join-Path $rootDir "dist" | Join-Path -ChildPath $baseBranch # ./dist/{v.x.x...}
$sourceCodeDir = Join-Path $baseDir "SourceCode" # ./dist/{v.x.x...}/SourceCode

$stepDirs = (
    "step-01-boilerplate",
    "step-02-define-styles",                
    "step-03-change-title",                 
    "step-04-add-model",                    
    "step-05-add-clocklist-component",
    "step-06-embed-clocklist-component-in-app",
    "step-07-make-clock-list",
    "step-08-add-clockservice",            
    "step-09-be-async",
    "step-10-add-addnewclock-form",
    "step-11-validate-input",
    "step-12-enable-routing",
    "step-13-page-naviation",
    "step-14-bind-child-component",
    "step-15-url-parameter",
    "step-16-edit-clock",
    "step-17-layout",
    "step-18-serverside-webapi",
    "step-19-httpclient",
    "step-20-javascript-interop",
    "step-21-auto-refresh-by-timer"
)
$outDirs = $stepDirs | ForEach-Object { Join-Path $sourceCodeDir $_ }

# Extract each step from the git history as separate git worktrees.
$step = 0
$outDirs | Sort-Object -Descending | ForEach-Object { 
    git worktree add $_ "$remote/$baseBranch~$step"
    $step++
}

# Remove .gitignore files in the SourceCode directory before creating the zip files.
Push-Location $baseDir
Get-ChildItem .gitignore -Recurse | Remove-Item
Pop-Location

# Create Boilerplate Zip file.
$boilerplateSrcPath = Join-Path $outDirs[0] "*"
$boilerplateZipPath = Join-Path $baseDir "BlazorWorldClock-Step01-Boilerplate.zip"
Compress-Archive $boilerplateSrcPath $boilerplateZipPath -Force

# Create Release Package Zip file.
$releasePackSrcPath = @($sourceCodeDir, "LICENSE", "Blazorアプリケーションプログラミング自習書-$baseBranch.pdf")
$releasePackZipPath = Join-Path $baseDir "Self-Learning-Materials-for-Blazor-JP-$baseBranch.zip"
Compress-Archive $releasePackSrcPath $releasePackZipPath -Force

# Clean up: Remove the git worktrees after creating the zip files.
$outDirs | ForEach-Object { git worktree remove $_ --force }

Pop-Location
