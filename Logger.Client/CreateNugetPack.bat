"../.nuget/nuget.exe" pack Logger.Client.csproj -Prop Configuration=Release
"../.nuget/nuget.exe" setapikey dda4b1b9-656b-4325-83ec-d5fe84aa2830
"../.nuget/nuget.exe" push Logger.Client.2.0.0.0.nupkg