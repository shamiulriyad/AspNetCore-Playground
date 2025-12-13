Write-Host "Fixing build errors..." -ForegroundColor Yellow

# Step 1: Remove extra Program.cs files
Write-Host "1. Removing extra Program.cs files..." -ForegroundColor Cyan
Get-ChildItem -Path . -Filter "Program.cs" -Recurse | 
    Where-Object { $_.Directory.Name -notin @('', 'FreshBox') } | 
    ForEach-Object { 
        Write-Host "  Removing: $($_.FullName)" -ForegroundColor Gray
        Remove-Item $_ -Force 
    }

# Step 2: Remove migrations
Write-Host "2. Removing old migrations..." -ForegroundColor Cyan
if (Test-Path "Migrations") {
    Remove-Item "Migrations" -Recurse -Force
    Write-Host "  ✓ Migrations removed" -ForegroundColor Green
}

# Step 3: Clean build artifacts
Write-Host "3. Cleaning build artifacts..." -ForegroundColor Cyan
dotnet clean
Remove-Item "bin" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item "obj" -Recurse -Force -ErrorAction SilentlyContinue

# Step 4: Ensure SQL Server package
Write-Host "4. Adding SQL Server package..." -ForegroundColor Cyan
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0

# Step 5: Restore packages
Write-Host "5. Restoring packages..." -ForegroundColor Cyan
dotnet restore

# Step 6: Build
Write-Host "6. Building project..." -ForegroundColor Cyan
dotnet build

if ($LASTEXITCODE -eq 0) {
    Write-Host "✓ Build successful!" -ForegroundColor Green
} else {
    Write-Host "✗ Build failed. Check errors above." -ForegroundColor Red
}