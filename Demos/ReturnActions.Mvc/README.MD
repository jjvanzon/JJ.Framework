Reference this project and add this to the post-build event of your own MVC project:

"$(TargetDir)CopyFiles.bat"

This will copy the content files from this project to your own project.
Beware that it will overwrite files if they were already there.