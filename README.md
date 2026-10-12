# Brainiac Weekend Collections

Addon opcional para o WeekendDrops: adiciona três coleções com os 30 itens do Brainiac Collectibles.

## Requisitos

SPT 4.1.6, Brainiac Collectibles 1.2.0 e WeekendDrops 1.0.7. O mod de itens é distribuído em um projeto separado: [Brainiac Collectibles](https://github.com/maestroBR/brainiac-collectibles).

[Baixar a versão mais recente](https://github.com/maestroBR/brainiac-weekend-collections/releases/latest).

## Instalação

Feche o servidor e extraia o ZIP na pasta do SPT. A pasta resultante é `SPT_Runtime/user/mods/Brainiac-WeekendCollections/`. Reinicie servidor e cliente.

O addon acrescenta coleções em memória, preserva configurações existentes e evita duplicatas nas recargas. Não inclui modelos, texturas ou bundles.

## Coleções e recompensas

Tecnologia Esquecida, Relíquias de Campo e Arquivo Brainiac: dez itens por coleção. Cada entrega concede 750 GP; os marcos de cinco e dez itens concedem 3750 e 9750 GP. Cada coleção concluída concede +2% permanente de GP, totalizando +6%. O Weekend controla cálculo e persistência. Coleções já existentes mantêm suas recompensas configuradas.

## Desenvolvimento

.NET SDK 10 e Python 3. As DLLs do SPT e Weekend são referências locais e não são distribuídas.

```sh
dotnet build src/WeekendCollections/WeekendCollections.csproj -c Release -p:SptRoot="CAMINHO/SPT_Runtime"
dotnet run --project tests/CollectionMergeCheck.csproj -p:SptRoot="CAMINHO/SPT_Runtime"
python tools/validate.py
python tools/package.py
```

A compilação e a mesclagem isolada foram verificadas. Startup, entregas e gameplay Fika da distribuição separada permanecem pendentes. Retirar o addon remove suas coleções da interface após reinício, mantendo o progresso salvo pelo Weekend.

GUID: `project.brainiac.weekendcollections`. Código sob licença MIT, Project Brainiac.

Para o VS Code resolver as referências sem argumentos de terminal, crie `Directory.Build.local.props` na raiz:

```xml
<Project>
  <PropertyGroup>
    <SptRoot>CAMINHO/SPT_Runtime</SptRoot>
  </PropertyGroup>
</Project>
```

Esse arquivo é ignorado pelo Git e guarda apenas sua configuração local. Depois recarregue a janela do VS Code.
