using System;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class Single : Parameter
  {
    public Single(int offset) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      value = reader.ReadSingle();
    }

    public override void WriteValue(BinaryWriter writer)
    {
      writer.Write(Convert.ToSingle(value));
    }
  }
}
