using System;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Byte : Parameter
  {
    public Byte(int offset) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      value = reader.ReadByte();
    }

    public override void WriteValue(BinaryWriter writer)
    {
      writer.Write(Convert.ToByte(value));
    }
  }
}
