# Compilar o addon

.NET SDK 10 e Python 3. As DLLs do SPT e Weekend são referências locais e não são distribuídas.

```sh
dotnet build src/WeekendCollections/WeekendCollections.csproj -c Release -p:SptRoot="CAMINHO/SPT_Runtime"
dotnet run --project tests/CollectionMergeCheck.csproj -p:SptRoot="CAMINHO/SPT_Runtime"
python tools/validate.py
python tools/package.py
```


Para o VS Code resolver as referências sem argumentos de terminal, crie `Directory.Build.local.props` na raiz:

```xml
<Project>
  <PropertyGroup>
    <SptRoot>CAMINHO/SPT_Runtime</SptRoot>
  </PropertyGroup>
</Project>
```

Esse arquivo é ignorado pelo Git e guarda apenas sua configuração local. Depois recarregue a janela do VS Code.
