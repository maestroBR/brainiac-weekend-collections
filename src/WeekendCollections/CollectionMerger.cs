using WeekendDrops.Models;
namespace Brainiac.WeekendCollections;
public static class CollectionMerger
{
 public static int Merge(List<CollectionSetDefinition> current,IEnumerable<CollectionSetDefinition> additional)
 {
  var ids=current.Select(s=>s.Id).ToHashSet(StringComparer.Ordinal);
  int added=0;
  foreach(var definition in additional)
   if(ids.Add(definition.Id)){current.Add(definition);added++;}
  return added;
 }
}
