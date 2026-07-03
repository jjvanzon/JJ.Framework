Azure Pipelines Clear Retain Flags
==================================

*JJ van Zon, 2026-06-11*

Executed inside a Release Pipeline in an Inline PowerShell task, to bulk-clear its retain indefinitely flags.

Background
----------

This script bulk-unlocks the "Retain indefinitely" flag on old Azure DevOps releases because the UI doesn't provide a batch option. Removing these flags lets the daily cleanup process delete old artifacts and free up the 2 GB storage quota blocking the pipeline. It is best used when the vast majority of runs (like automated dev builds) don't need saving, allowing a few important production releases to be manually re-locked afterward.

Scripts
-------

### Clear first 100 using CLI API

```ps1
$env:AZURE_DEVOPS_EXT_PAT = "$(System.AccessToken)"

# Added the missing `$top=2000` parameter cleanly
$ids = az devops invoke --http-method GET --area release --resource releases --organization=https://dev.azure.com/jjvanzon --route-parameters project=$env:SYSTEM_TEAMPROJECT --query-parameters definitionId=$env:RELEASE_DEFINITIONID `$top=2000 --query "value[].id" | ConvertFrom-Json

# Create the temp file for the payload
$tempFile = "$env:TEMP\unlock.json"
'{"keepForever":false}' | Out-File -FilePath $tempFile -Force -Encoding ascii

foreach ($id in $ids) {
    Write-Host "Lift lock on Release ID: $id"
    az devops invoke --http-method PATCH --area release --resource releases --organization=https://dev.azure.com/jjvanzon --route-parameters project=$env:SYSTEM_TEAMPROJECT releaseId=$id --in-file $tempFile | Out-Null
}
```

### Clear all using REST API

```ps1
$env:AZURE_DEVOPS_EXT_PAT = "$(System.AccessToken)"

az devops configure --defaults organization=https://dev.azure.com/jjvanzon project=$env:SYSTEM_TEAMPROJECT

# Create the temp file for the payload
$tempFile = "$env:TEMP\unlock.json"
'{"keepForever":false}' | Out-File -FilePath $tempFile -Force -Encoding ascii

$maxTime = $null
$i = 0

do {
    # Build query
    $query = @("definitionId=$env:RELEASE_DEFINITIONID", "`$top=100")
    if ($maxTime) { $query += "maxCreatedTime=$maxTime" }

    # Get list
    $releases = az devops invoke --http-method GET --area release --resource releases --query-parameters $query | ConvertFrom-Json

    if (-not $releases.value) { break }

    foreach ($r in ($releases.value | Where-Object { $_.keepForever })) {
        
        Write-Host "Lift lock on Release ID: $($r.id)"
        az devops invoke --http-method PATCH --area release --resource releases --organization=https://dev.azure.com/jjvanzon --route-parameters project=$env:SYSTEM_TEAMPROJECT releaseId=$($r.id) --in-file $tempFile | Out-Null
    }

    $maxTime = $releases.value[-1].createdOn

} while ($releases.value.Count -eq 100 -and ++$i -lt 50)
```