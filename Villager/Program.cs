using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ACQuoteTracker.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VillagerScraper
{
    class Program
    {
        static List<Villager> ReadInVillagers()
        {
            List<Villager> villagers = new List<Villager>();

            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    string path = directoryInfo.FullName +
                                  "/villagers.json";
                
                    using (StreamReader reader = File.OpenText(path))
                    {
                        JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                        var jArray = o["villagers"];
                        var json = JArray.FromObject(jArray);

                        foreach (var villagerRecordJson in json)
                        {
                            string name = villagerRecordJson["name"].ToObject<string>();
                            string imgUrl = villagerRecordJson["img"].ToObject<string>();

                            Villager v = new Villager()
                            {
                                ID = 0,
                                ImageUrl = imgUrl,
                                name = name
                            };
                            
                            villagers.Add(v);
                        }
                    }
                }
            }

            return villagers;
        }
        
        static void Main(string[] args)
        {
            Program.ReadInVillagers();
        }
    }
}