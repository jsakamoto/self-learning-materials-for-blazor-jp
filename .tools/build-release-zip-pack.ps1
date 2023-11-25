# Get latest branch name which starts with "v.x.x..."
$baseBranch = "v.8.0.0"

$rootDir = Join-Path $PSScriptRoot ".." -Resolve
Push-Location $rootDir
$baseDir = Join-Path $rootDir "dist" | Join-Path -ChildPath $baseBranch
$sourceCodeDir = Join-Path $baseDir "SourceCode"
if (-not (Test-Path $sourceCodeDir)) { mkdir $sourceCodeDir > $null }

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

git checkout $baseBranch
$stepDirs | Sort-Object -Descending | ForEach-Object {
    $stepDir = $_
    $outDir = (Join-Path $sourceCodeDir $stepDir) + "\"
    if ( -not (Test-Path $outDir -PathType Container)) { 
        Write-Output ("NOT EXISTS: " + $outDir)
        mkdir $outDir > $null
    }

    # Write-Output $outDir
    # Write-Output $branch
    # Write-Output "$outDir\$stepDir"
    git checkout-index -a --prefix $outDir
    git checkout HEAD^
}

git checkout master

Push-Location $baseDir
Get-ChildItem .git* -Recurse | Remove-Item
Pop-Location

# Create Bolerplate Zip file.
$boilerplateSrcPath = Join-Path $sourceCodeDir $stepDirs[0] | Join-Path -ChildPath "*"
$boilerplateZipPath = Join-Path $baseDir "BlazorWorldClock-Step01-Boilerplate.zip"
Compress-Archive $boilerplateSrcPath $boilerplateZipPath -Force

# Create Release Package Zip file.
$releasePackSrcPath = @($sourceCodeDir, "LICENSE", "Blazorアプリケーションプログラミング自習書-$baseBranch.pdf")
$releasePackZipPath = Join-Path $baseDir "Self-Learning-Materials-for-Blazor-JP-$baseBranch.zip"
Compress-Archive $releasePackSrcPath $releasePackZipPath -Force

Pop-Location