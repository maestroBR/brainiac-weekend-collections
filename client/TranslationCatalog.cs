using System;
namespace Brainiac.WeekendCollections.Client
{
 public static class TranslationCatalog
 {
  public static readonly string[] Supported = { "en", "ge", "ru", "po", "ch", "fr", "es", "es-mx", "jp", "kr", "pl", "cz", "it", "hu", "ro", "sk", "tu" };
  public static string Normalize(string language)
  {
   var code=(language??"en").Trim().Replace('_','-').ToLowerInvariant();
   if(code=="es-mx" || code.StartsWith("es-mx-")) return "es-mx";
   var primary=code.Split('-')[0];
   switch(primary)
   {
    case "de": return "ge";
    case "pt": return "po";
    case "zh": return "ch";
    case "ja": return "jp";
    case "ko": return "kr";
    case "cs": return "cz";
    case "tr": return "tu";
   }
   foreach(var supported in Supported) if(primary==supported) return supported;
   return "en";
  }
 }
}
