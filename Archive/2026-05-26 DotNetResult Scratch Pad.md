
```cs        
        Text = Join(NewLine,
                    HasExitCode   ? $"Exit Code = {exitCode}" : "",
                    HasErrorText  ? $"Error = {errorText}" : "",
                    HasOutputText ? $"Output = {outputText}" : "");

        throw new Exception(
            $"dotnet {Args} failed " +
            $"{new { HasExitCode, HasErrorText, HasErrorInOutput, HasTimeOut, Args.FullArgs }}: " +
            $"{TimeOutMessage} " +
            $"Exit code {ExitCode} {ErrorText} {OutputText}");
```