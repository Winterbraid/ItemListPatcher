using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Defense : Parameter
  {
    public Defense(int offset = 4) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      byte[] bytes = reader.ReadBytes(4);

      byte[] defenseBytes = { bytes[0], (byte)(bytes[1] % 4) };
      byte[] magDefBytes = { bytes[1], bytes[2] };

      int defense = BitConverter.ToUInt16(defenseBytes, 0);
      int magickDefense = BitConverter.ToUInt16(magDefBytes, 0) / 4;

      value = new Dictionary<string, int>
      {
        { "physical", defense },
        { "magick", magickDefense }
      };
    }

    public override void WriteValue(BinaryWriter writer)
    {
      JObject jobject = value as JObject;
      Dictionary<string, ushort> dict = jobject.ToObject<Dictionary<string, ushort>>();

      byte[] defenseBytes = BitConverter.GetBytes(dict["physical"]);
      byte[] magDefBytes = BitConverter.GetBytes(dict["magick"] * 4);

      byte[] bytes =
      {
        defenseBytes[0],
        (byte)(defenseBytes[1] + magDefBytes[0]),
        magDefBytes[1]
      };

      writer.Write(bytes);
    }
  }
}
