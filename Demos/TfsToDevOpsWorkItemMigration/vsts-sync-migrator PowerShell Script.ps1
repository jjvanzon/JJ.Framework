# Install chocolatey
Get-ExecutionPolicy
Set-ExecutionPolicy AllSigned
Get-ExecutionPolicy
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install vsts-sync-migrator
choco install vsts-sync-migrator --force
$env:Path += ";C:\tools\VSTSSyncMigration"

# Initialize vsts-sync-migrator
cd "D:\Source\JJs Software\JJ.Framework\Demos\TfsToDevOpsWorkItemMigration"
migration init
# choco upgrade vsts-sync-migrator
# It gave an error access denied. Trying to restart windows
# I did see configuration.json appear so maybe things are OK.