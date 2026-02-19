@echo off
SET MIGRATION_NAME=%1

:: Check if the migration name was provided
if "%MIGRATION_NAME%"=="" (
    echo [ERROR] Missing migration name.
    echo Usage: migrations-add-catalog.bat MyMigrationName
    exit /b 1
)

echo Starting EF Migration: %MIGRATION_NAME%...

dotnet ef migrations add %MIGRATION_NAME% ^
  -c CatalogDbContext ^
  -s .\Bootstrapper\Api\Api.csproj ^
  -p .\Modules\Catalog\Catalog\Catalog.csproj

if %ERRORLEVEL% EQU 0 (
    echo [SUCCESS] Migration '%MIGRATION_NAME%' created successfully.
) else (
    echo [FAILURE] There was an error creating the migration.
)