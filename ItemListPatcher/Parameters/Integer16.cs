using System;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Integer16 : Parameter
  {
    public Integer16(int offset) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      value = reader.ReadInt16();
    }

    public override void WriteValue(BinaryWriter writer)
    {
      writer.Write(Convert.ToInt16(value));
    }
  }
}
