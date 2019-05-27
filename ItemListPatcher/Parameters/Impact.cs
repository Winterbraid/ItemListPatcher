using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Impact : Parameter
  {
    public Impact(int offset = 8) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      byte[] bytes = reader.ReadBytes(4);

      byte[] staggerBytes = { bytes[0], (byte)(bytes[1] % 4) };
      byte[] knockdownBytes = { bytes[1], bytes[2] };

      int stagger = BitConverter.ToUInt16(staggerBytes, 0);
      int knockdown = BitConverter.ToUInt16(knockdownBytes, 0) / 4;

      value = new Dictionary<string, int>
      {
        { "stagger", stagger },
        { "knockdown", knockdown }
      };
    }

    public override void WriteValue(BinaryWriter writer)
    {
      JObject jobject = value as JObject;
      Dictionary<string, ushort> dict = jobject.ToObject<Dictionary<string, ushort>>();

      byte[] staggerBytes = BitConverter.GetBytes(dict["stagger"]);
      byte[] knockdownBytes = BitConverter.GetBytes(dict["knockdown"] * 4);

      byte[] bytes =
      {
        staggerBytes[0],
        (byte)(staggerBytes[1] + knockdownBytes[0]),
        knockdownBytes[1]
      };

      writer.Write(bytes);
    }
  }
}
