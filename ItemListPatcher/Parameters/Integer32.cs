using System;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Integer32 : Parameter
  {
    public Integer32(int offset) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      value = reader.ReadInt32();
    }

    public override void WriteValue(BinaryWriter writer)
    {
      writer.Write(Convert.ToInt32(value));
    }
  }
}
