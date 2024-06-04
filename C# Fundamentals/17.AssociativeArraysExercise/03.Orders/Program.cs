using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split(' ');
            Dictionary<string, double> keyMaterials = new Dictionary<string, double>() 
            {
                {"shards", 0 }, {"fragments", 0}, {"motes", 0}
            };

            Dictionary<string, double> junkMaterials = new Dictionary<string, double>();

            string winMaterial = string.Empty;
            string winItem = string.Empty;
            bool isFind = false;
            for (int i = 0; i < inputData.Length; i = i + 2)
            {
                double quantity = double.Parse(inputData[i]);
                string material = inputData[i + 1].ToLower();

                if (keyMaterials.ContainsKey(material))
                {
                    keyMaterials[material] += quantity;
                }
                else if (junkMaterials.ContainsKey(material) == false)
                {
                    junkMaterials.Add(material, quantity);
                }
                else
                {
                    junkMaterials[material] += quantity;
                }

                if (isFind == false)
                {
                    foreach (KeyValuePair<string, double> specialMaterial in keyMaterials)
                    {
                        if (specialMaterial.Value >= 250 && specialMaterial.Key == "shard")
                        {
                            winItem = "Shadowmourne";
                            winMaterial = specialMaterial.Key;
                            isFind = true;
                            break;
                        }
                        else if (specialMaterial.Value >= 250 && specialMaterial.Key == "fragments")
                        {
                            winItem = "Valanyr";
                            winMaterial = specialMaterial.Key;
                            isFind = true;
                            break;
                        }
                        else if (specialMaterial.Value >= 250 && specialMaterial.Key == "motes")
                        {
                            winItem = "Dragonwrath";
                            winMaterial = specialMaterial.Key;
                            isFind = true;
                            break;
                        }
                    }
                }
            }

            keyMaterials[winMaterial] -= 250;
            keyMaterials = keyMaterials.OrderByDescending(v => v.Value)
                                        .ThenBy(k => k.Key)
                                        .ToDictionary(k => k.Key, v => v.Value);

            junkMaterials = junkMaterials.OrderBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"{winItem} obtained!");
            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}