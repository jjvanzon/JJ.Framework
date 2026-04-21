
``xml
    <!--<MSBuild Condition="'$(IsNCrunch)'=='True' And ($(IsNet6) Or $(IsNet7))" Targets="Publish" 
             Projects="$(MSBuildProjectFile)" Properties="NoBuild=true;RuntimeIdentifier=win-x64;SelfContained=true;PublishTrimmed=true;PublishSingleFile=true;PublishReadyToRun=true" />

    <MSBuild Condition="'$(IsNCrunch)'=='True' And $(IsNet5)" Targets="Publish" 
             Projects="$(MSBuildProjectFile)" Properties="NoBuild=true;RuntimeIdentifier=win-x64;SelfContained=true;PublishSingleFile=true;PublishReadyToRun=false" />-->

    <!--<Message Text="$(MSBuildProjectName) > EXCEPTION TEXT NOT EXTRACTED!" Condition="$(TrimRunHasError) And '$(TrimRunException)'==''" Importance="High" />-->
    <!--<Message Text="$(MSBuildProjectName) > OutputJoined = $(TrimRunOutputJoined)" Importance="High" />-->
```