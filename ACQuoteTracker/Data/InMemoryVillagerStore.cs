using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACQuoteTracker.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACQuoteTracker.Data
{
    public class InMemoryVillagerStore : IVillagerData
    {
        private List<Villager> villagers;

        public static List<Villager> ReadInVillagers()
        {
            List<Villager> villagers = new List<Villager>();

            string path = @"./Data/villagers.json";
                
            using (StreamReader reader = File.OpenText(path))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                var jArray = o["villagers"];
                var json = JArray.FromObject(jArray);


                int ID = 1;
                foreach (var villagerRecordJson in json)
                {
                    string name = villagerRecordJson["name"].ToObject<string>();
                    string imgUrl = villagerRecordJson["img"].ToObject<string>();

                    Villager v = new Villager()
                    {
                        VillagerId = ID,
                        ImageUrl = imgUrl,
                        name = name
                    };
                            
                    villagers.Add(v);
                    ID++;
                }
            }

            return villagers;
        }
        
        
        public InMemoryVillagerStore()
        {
            villagers = new List<Villager>();

            var seededVillagers = ReadInVillagers();

            villagers.AddRange(seededVillagers);
        }
        
        public IEnumerable<Villager> GetVillagers()
        {
            return villagers;
        }

        public Villager FindById(int ID)
        {
            Villager foundVillager = villagers.FirstOrDefault(v => v.VillagerId == ID);
            return foundVillager;
        }

        public Villager AddVillager(Villager newVillager)
        {
            newVillager.VillagerId = 1;

            if (villagers.Count > 0)
            {
                newVillager.VillagerId = villagers.Max(v => v.VillagerId) + 1;
            }
            villagers.Add(newVillager);
            return newVillager;
        }

        public void CommitChanges()
        {
            throw new NotImplementedException();
        }
    }
}