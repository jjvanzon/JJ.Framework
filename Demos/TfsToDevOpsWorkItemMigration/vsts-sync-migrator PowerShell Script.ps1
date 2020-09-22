# Change security setting
Get-ExecutionPolicy
Set-ExecutionPolicy AllSigned
Get-ExecutionPolicy

# Install chocolatey
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install vsts-sync-migrator
choco install vsts-sync-migrator --force

# Set some paths
$env:Path += ";C:\tools\VSTSSyncMigration"
Set-Location "D:\Source\JJs Software\JJ.Framework\Demos\TfsToDevOpsWorkItemMigration"

# Initialize vsts-sync-migrator
migration init

# Try Upgrading vsts-sync-migrator
# choco upgrade vsts-sync-migrator
# It gave an error access denied. Trying to restart windows
# I did see configuration.json appear so maybe things are OK.

# Run vsts-sync-migrator
migration execute -c configuration.json