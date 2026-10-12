using Brainiac.WeekendCollections;
using WeekendDrops.Models;
var original=new CollectionSetDefinition{Id="existing",GpPerItem=123};
var current=new List<CollectionSetDefinition>{original};
var additions=new[]{new CollectionSetDefinition{Id="existing",GpPerItem=999},new CollectionSetDefinition{Id="new",GpPerItem=750}};
if(CollectionMerger.Merge(current,additions)!=1)throw new Exception("Quantidade de conjuntos adicionados incorreta.");
if(current.Count!=2||!ReferenceEquals(current[0],original)||original.GpPerItem!=123)throw new Exception("Configuração existente foi alterada.");
if(CollectionMerger.Merge(current,additions)!=0||current.Count!=2)throw new Exception("Reaplicação duplicou coleções.");
if(CollectionMerger.Merge(current,new[]{new CollectionSetDefinition{Id="third"},new CollectionSetDefinition{Id="third"}})!=1)throw new Exception("IDs duplicados no mesmo lote.");
Console.WriteLine("Coleções existentes preservadas; reaplicação sem duplicatas; lote repetido tratado.");

foreach(var pair in new[]{("en","en"),("ge","ge"),("de-DE","ge"),("ru","ru"),("ru-RU","ru"),("po","po"),("pt-BR","po"),("ch","ch"),("zh-CN","ch"),("fr","en")})
 if(Brainiac.WeekendCollections.Client.TranslationCatalog.Normalize(pair.Item1)!=pair.Item2)throw new Exception("Language selection failed: "+pair.Item1);
var root=System.IO.Path.GetFullPath(System.IO.Path.Combine(AppContext.BaseDirectory,"../../../../"));
foreach(var code in new[]{"en","ge","ru","po","ch"})
{
 var texts=System.Text.Json.JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(Path.Combine(root,"locales",code+".json")))!;
 if(texts.Count!=12 || texts.Values.Any(string.IsNullOrWhiteSpace))throw new Exception("Missing translations: "+code);
}
Console.WriteLine("Five language files and language aliases verified; unsupported languages fall back to English.");
