using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Attack : Parameter
  {
    public Attack(int offset = 0) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      byte[] bytes = reader.ReadBytes(4);

      byte[] strengthBytes = { bytes[0], (byte)(bytes[1] % 8) };
      byte[] magickBytes = { bytes[1], (byte)(bytes[2] % 128) };
      byte[] unknownBytes = { (byte)(bytes[2] - magickBytes[1]), bytes[3] };

      int strength = BitConverter.ToUInt16(strengthBytes, 0);
      int magick = BitConverter.ToUInt16(magickBytes, 0) / 8;
      int unknown = BitConverter.ToUInt16(unknownBytes, 0);

      value = new Dictionary<string, int>
      {
        { "strength", strength },
        { "magick", magick },
        { "unknown", unknown }
      };
    }

    public override void WriteValue(BinaryWriter writer)
    {
      JObject jobject = value as JObject;
      Dictionary<string, ushort> dict = jobject.ToObject<Dictionary<string, ushort>>();

      byte[] strengthBytes = BitConverter.GetBytes(dict["strength"]);
      byte[] magickBytes = BitConverter.GetBytes(dict["magick"] * 8);
      byte[] unknownBytes = BitConverter.GetBytes(dict["unknown"]);

      byte[] bytes =
      {
        strengthBytes[0],
        (byte)(strengthBytes[1] + magickBytes[0]),
        (byte)(magickBytes[1] + unknownBytes[0]),
        unknownBytes[1]
      };

      writer.Write(bytes);
    }
  }
}
