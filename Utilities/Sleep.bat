@echo off
cls
echo RUNNING SLEEP COMMAND
rundll32.exe powrprof.dll,SetSuspendState 0,1,0
