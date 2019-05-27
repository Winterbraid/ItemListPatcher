using System;
using System.IO;

namespace ItemListPatcher
{
  internal static class Names
  {
    private const string NAMES_FILE = "Names.txt";

    private static readonly string[] newLines = { "\r\n", "\r", "\n" };

    public static string[] List { get; private set; } = new string[1901];

    public static void Load()
    {
      if (File.Exists(NAMES_FILE))
      {
        string text;

        using (StreamReader reader = new StreamReader(NAMES_FILE))
        {
          text = reader.ReadToEnd();
        }

        string[] newList = text.Split(newLines, StringSplitOptions.RemoveEmptyEntries);

        if (newList.Length >= 1901)
        {
          List = newList;
        }
      }
    }
  }
}
