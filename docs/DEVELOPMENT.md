# Building and packaging

Requires .NET SDK 10, Python 3 and a local SPT 4.1.6 installation. The addon also requires WeekendDrops 1.0.7.

```sh
dotnet build src/WeekendCollections/WeekendCollections.csproj -c Release -p:SptRoot="PATH/SPT_Runtime"
dotnet run --project tests/CollectionMergeCheck.csproj -p:SptRoot="PATH/SPT_Runtime"
python tools/validate.py
python tools/package.py
```

You can also set the `SPT_ROOT` environment variable. Set WeekendRoot if Weekend is installed elsewhere. Building does not install anything into the game. Installation ZIPs and checksums are generated in `dist/` and excluded from Git.

For VS Code to resolve references, create `Directory.Build.local.props` in the repository root:

```xml
<Project>
  <PropertyGroup>
    <SptRoot>PATH/SPT_Runtime</SptRoot>
  </PropertyGroup>
</Project>
```

This file is ignored by Git. Reload the VS Code window after creating it.

SPT and third-party DLLs are local references and are not distributed.
