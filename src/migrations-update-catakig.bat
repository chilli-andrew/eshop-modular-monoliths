@echo off
SET TARGET_MIGRATION=%1

:: If a name is provided, we'll target that specific migration (useful for rollbacks)
if "%TARGET_MIGRATION%"=="" (
    echo [INFO] No migration specified. Updating to the latest migration...
) else (
    echo [INFO] Updating database to: %TARGET_MIGRATION%...
)

dotnet ef database update %TARGET_MIGRATION% ^
  -c CatalogDbContext ^
  -s .\Bootstrapper\Api\Api.csproj ^
  -p .\Modules\Catalog\Catalog\Catalog.csproj

if %ERRORLEVEL% EQU 0 (
    echo [SUCCESS] Database update completed successfully.
) else (
    echo [FAILURE] Database update failed. Check your connection string or build errors.
)