# Fix all Designer.cs files - Add missing using statements

Write-Host "Fixing all Designer.cs files..." -ForegroundColor Green

$designerFiles = Get-ChildItem -Path "QLNhaSach" -Filter "*.Designer.cs" -Recurse

foreach ($file in $designerFiles) {
    Write-Host "Processing: $($file.Name)" -ForegroundColor Yellow
    
    $content = Get-Content $file.FullName -Raw
    
    # Check if using statements already exist
    if ($content -notmatch "using System.Windows.Forms;") {
        # Add using statements at the beginning
        $usingStatements = @"
using System;
using System.Drawing;
using System.Windows.Forms;

"@
        $content = $usingStatements + $content
        Set-Content -Path $file.FullName -Value $content -Encoding UTF8
        Write-Host "  Fixed: $($file.Name)" -ForegroundColor Cyan
    } else {
        Write-Host "  Skipped (already has using statements): $($file.Name)" -ForegroundColor Gray
    }
}

Write-Host "`nAll Designer files have been fixed!" -ForegroundColor Green
Write-Host "Now run: dotnet build" -ForegroundColor Yellow
