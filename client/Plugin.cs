using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using Newtonsoft.Json;

namespace Brainiac.WeekendCollections.Client
{
 [BepInPlugin("project.brainiac.weekendcollections.client", "Brainiac Weekend Collections Languages", "1.2.1")]
 [BepInDependency("com.20fpsguy.WeekendDrops")]
 public sealed class Plugin : BaseUnityPlugin
 {
  static readonly Dictionary<string, Dictionary<string,string>> translations = new Dictionary<string, Dictionary<string,string>>();
  static MethodInfo resolve; static PropertyInfo language; Harmony harmony;
  void Awake()
  {
   try
   {
    var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    foreach(var code in TranslationCatalog.Supported)
     translations[code] = JsonConvert.DeserializeObject<Dictionary<string,string>>(File.ReadAllText(Path.Combine(folder,"locales",code+".json")));
    var loc = AccessTools.TypeByName("WeekendDropsUI.Services.Loc");
    language = AccessTools.Property(loc,"Language");
    resolve = AccessTools.Method(loc,"T",new[]{typeof(string)});
    var lookup = AccessTools.Method(loc,"Or",new[]{typeof(string),typeof(string)});
    var draw = AccessTools.DeclaredMethod(AccessTools.TypeByName("WeekendDropsUI.UI.ChallengePanel"),"DrawCollectionSet");
    if(language==null || resolve==null || lookup==null || draw==null) throw new MissingMemberException("Weekend Drops localization API");
    harmony = new Harmony("project.brainiac.weekendcollections.client");
    harmony.Patch(lookup,postfix:new HarmonyMethod(typeof(Plugin),nameof(Localize)));
    harmony.Patch(draw,prefix:new HarmonyMethod(typeof(Plugin),nameof(TranslateSet)){priority=Priority.First});
    Logger.LogInfo("Brainiac collection translations loaded for all 17 supported Weekend language codes.");
   }
   catch(Exception error) { harmony?.UnpatchSelf(); Logger.LogError(error); }
  }
  static string Code()=>TranslationCatalog.Normalize((string)language.GetValue(null,null));
  static void Localize(string __0, ref string __result)
  {
   if(__0==null || !__0.StartsWith("collection.set_brainiac_ph_",StringComparison.Ordinal)) return;
   string text;
   if(translations[Code()].TryGetValue(__0,out text))__result=text;
  }
  static object Get(object value,string name)=>AccessTools.Property(value.GetType(),name).GetValue(value,null);
  static void Set(object value,string name,string text)=>AccessTools.Property(value.GetType(),name).SetValue(value,text,null);
  static void TranslateSet(object __0)
  {
   if(__0==null)return;
   var id=Get(__0,"Id") as string;
   if(id==null || !translations["en"].ContainsKey("collection."+id+".name"))return;
   resolve.Invoke(null,new object[]{"collection."+id+".name"});
   var texts=translations[Code()]; string prefix="collection."+id;
   Set(__0,"Name",texts[prefix+".name"]); Set(__0,"Description",texts[prefix+".desc"]);
   foreach(var milestone in (IEnumerable)Get(__0,"Milestones"))
   {
    string text;
    if(texts.TryGetValue(prefix+".milestone."+Get(milestone,"Required"),out text)) Set(milestone,"Description",text);
   }
  }
  void OnDestroy()=>harmony?.UnpatchSelf();
 }
}
