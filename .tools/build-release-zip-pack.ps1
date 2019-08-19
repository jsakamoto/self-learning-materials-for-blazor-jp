# Get latest branch name which starts with "v.x.x..."
$baseBranch = "v.3.0.0-preview8"

$rootDir = Join-Path $PSScriptRoot ".." -Resolve
pushd $rootDir
$baseDir = Join-Path $rootDir "dist" | Join-Path -ChildPath $baseBranch
$sourceCodeDir = Join-Path $baseDir "SourceCode"
if (-not (Test-Path $sourceCodeDir)) { mkdir $sourceCodeDir > $null }

$stepDirs = (
    "step-01-boilerplate",
    "step-02-define-styles",                
    "step-03-change-title",                 
    "step-04-add-model",                    
    "step-05-add-devices-component",
    "step-06-embed-devices-coponent-in-app",
    "step-07-make-device-list",
    "step-08-add-deviceservice",            
    "step-09-be-async",
    "step-10-add-addnewdevice-form",
    "step-11-validate-input",
    "step-12-enable-routing",
    "step-13-page-naviation",
    "step-14-bind-child-component",
    "step-15-url-parameter",
    "step-16-edit-device",
    "step-17-layout",
    "step-18-serverside-webapi",
    "step-19-httpclient",
    "step-20-javascript-interop",
    "step-21-wol"
)

git checkout $baseBranch
$stepDirs | sort -Descending | % {
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

pushd $baseDir
ls .git* -Recurse | del
popd

# Create Bolerplate Zip file.
$boilerplateSrcPath = Join-Path $sourceCodeDir $stepDirs[0] | Join-Path -ChildPath "*.*"
$boilerplateZipPath = Join-Path $baseDir "BlazorWOL-Step01-Boilerplate.zip"
Compress-Archive $boilerplateSrcPath $boilerplateZipPath -Force

# Create Release Package Zip file.
$releasePackSrcPath = @($sourceCodeDir, "README.md", "LICENSE", "Blazorアプリケーションプログラミング自習書-$baseBranch.pdf")
$releasePackZipPath = Join-Path $baseDir "Self-Learning-Materials-for-Blazor-JP-$baseBranch.zip"
Compress-Archive $releasePackSrcPath $releasePackZipPath -Force

popd