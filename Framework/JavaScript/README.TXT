Add this to your post build events:

copy "$(TargetDir)*.js" "$(ProjectDir)Scripts"

-----


JJ.Framework.JavaScript contains helper funcions for working with URL's, which contains bugs... I should fix that eventually. It also contains helpers for working with cookies. Also there are JJ.Framework.Assert and JJ.Framework.Check which should allow you to make your JavaScript more type-safe, but I bet using TypeScript instead is a better plan.