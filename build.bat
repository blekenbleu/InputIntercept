dotnet restore
msbuild -t:pack InputInterceptor\InputIntercept.csproj -p:NuspecFile=..\Package.nuspec -p:Configuration=Release
