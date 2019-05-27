using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemListPatcher
{
  internal class Program
  {
    private const string DATA_FILE = "itemList.itl";
    private const string DATA_BACKUP = "itemList.itl.bak";
    private const string JSON_OUTPUT = "itemList.txt";
    private const string JSON_BACKUP = "itemList.txt.bak";

    private const int ITEM_COUNT = 1901;

    private static string file = "";
    private static Dictionary<int, Item> items = new Dictionary<int, Item>();

    private static void Main(string[] args)
    {
      Names.Load();
      LoadItems(DATA_FILE);

      if (args.Length > 0)
      {
        file = args[0];
      }

      if (file.EndsWith(".txt") || file.EndsWith(".json"))
      {
        Console.WriteLine("Loading data from " + file);
        File.Copy(DATA_FILE, DATA_BACKUP, true);
        LoadJSON(file);
        SaveItems(DATA_FILE);
      }
      else
      {
        Console.WriteLine("Saving data to " + JSON_OUTPUT);

        if (File.Exists(JSON_OUTPUT))
        {
          File.Copy(JSON_OUTPUT, JSON_BACKUP, true);
        }

        SaveJSON(JSON_OUTPUT);
      }
    }

    private static void LoadItems(string dataInput)
    {
      FileStream fileStream = new FileStream(dataInput, FileMode.Open);
      BinaryReader reader = new BinaryReader(fileStream);

      for (int k = 0; k < ITEM_COUNT; k++)
      {
        items[k] = new Item(k);
        items[k].ReadData(reader);
      }

      reader.Close();
      fileStream.Close();
    }

    private static void SaveItems(string dataOutput)
    {
      FileStream fileStream = new FileStream(dataOutput, FileMode.OpenOrCreate);
      BinaryWriter writer = new BinaryWriter(fileStream);

      for (int k = 0; k < ITEM_COUNT; k++)
      {
        items[k].WriteData(writer);
      }

      writer.Close();
      fileStream.Close();
    }

    private static void LoadJSON(string jsonInput)
    {
      JObject oldItems = JObject.FromObject(items);
      JObject newItems;

      using (StreamReader input = new StreamReader(jsonInput))
      {
        newItems = JObject.Parse(input.ReadToEnd());
      }

      oldItems.Merge(newItems, new JsonMergeSettings
      {
        MergeArrayHandling = MergeArrayHandling.Union
      });

      items = oldItems.ToObject<Dictionary<int, Item>>();
    }

    private static void SaveJSON(string jsonOutput)
    {
      string json = JsonConvert.SerializeObject(items, Formatting.Indented);

      using (StreamWriter output = new StreamWriter(jsonOutput))
      {
        output.WriteLine(json);
      }
    }
  }
}
