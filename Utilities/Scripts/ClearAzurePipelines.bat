@echo off

echo Clears miscellaneous caches and temp folders

echo Deleting "C:\Windows\ServiceProfiles\NetworkService\.nuget"
rmdir /s /q "C:\Windows\ServiceProfiles\NetworkService\.nuget"

echo Deleting "C:\Windows\ServiceProfiles\NetworkService\AppData\Local\Temp"
rmdir /s /q "C:\Windows\ServiceProfiles\NetworkService\AppData\Local\Temp"

echo Deleting "D:\AzurePipelines\Agent1\_work"
rmdir /s /q "D:\AzurePipelines\Agent1\_work"

echo Deleting "D:\AzurePipelines\Agent2\_work"
rmdir /s /q "D:\AzurePipelines\Agent2\_work"

echo Deleting "D:\AzurePipelines\Agent3\_work"
rmdir /s /q "D:\AzurePipelines\Agent3\_work"

echo Deleting "D:\AzurePipelines\Agent4\_work"
rmdir /s /q "D:\AzurePipelines\Agent4\_work"

echo Done.
