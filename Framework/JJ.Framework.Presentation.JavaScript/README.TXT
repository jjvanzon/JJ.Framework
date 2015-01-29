Add this to your post build events:

copy "$(TargetDir)*.js" "$(ProjectDir)Scripts"