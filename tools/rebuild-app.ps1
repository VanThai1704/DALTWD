# Script ?? ?óng QLNhaSach.exe và rebuild project

Write-Host "=== ?óng ?ng d?ng QLNhaSach ?ang ch?y ===" -ForegroundColor Yellow

# Tìm và kill process QLNhaSach
$processes = Get-Process -Name "QLNhaSach" -ErrorAction SilentlyContinue

if ($processes) {
    Write-Host "Tìm th?y $($processes.Count) process QLNhaSach ?ang ch?y..." -ForegroundColor Cyan
    foreach ($proc in $processes) {
        Write-Host "  ?óng PID: $($proc.Id)" -ForegroundColor Gray
        Stop-Process -Id $proc.Id -Force
    }
    Start-Sleep -Seconds 1
    Write-Host "? ?ã ?óng t?t c? process" -ForegroundColor Green
} else {
    Write-Host "Không có process QLNhaSach ?ang ch?y" -ForegroundColor Green
}

Write-Host ""
Write-Host "=== Rebuild project ===" -ForegroundColor Yellow

# Tìm ???ng d?n solution
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$solutionPath = Join-Path $scriptPath "..\QLNhaSach\QLNhaSach.csproj"

if (Test-Path $solutionPath) {
    Write-Host "Build project: $solutionPath" -ForegroundColor Cyan
    
    # Clean
    Write-Host "  Cleaning..." -ForegroundColor Gray
    dotnet clean $solutionPath --configuration Debug | Out-Null
    
    # Build
    Write-Host "  Building..." -ForegroundColor Gray
    $buildResult = dotnet build $solutionPath --configuration Debug 2>&1
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "? Build thành công!" -ForegroundColor Green
        Write-Host ""
        Write-Host "=== Ch?y ?ng d?ng ===" -ForegroundColor Yellow
        Write-Host "Nh?n F5 trong Visual Studio ho?c ch?y:" -ForegroundColor Cyan
        $exePath = Join-Path (Split-Path -Parent $solutionPath) "bin\Debug\net8.0-windows\QLNhaSach.exe"
        Write-Host "  $exePath" -ForegroundColor White
    } else {
        Write-Host "? Build th?t b?i!" -ForegroundColor Red
        Write-Host $buildResult
    }
} else {
    Write-Host "Không tìm th?y project t?i: $solutionPath" -ForegroundColor Red
}

Write-Host ""
Write-Host "=== H??ng d?n test ===" -ForegroundColor Yellow
Write-Host "1. ??ng nh?p v?i:" -ForegroundColor Cyan
Write-Host "   Username: admin" -ForegroundColor White
Write-Host "   Password: admin123" -ForegroundColor White
Write-Host "2. Ki?m tra menu bar ph?i có: 'Qu?n lý ng??i dùng'" -ForegroundColor Cyan
Write-Host ""
