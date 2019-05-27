using System;
using System.IO;

namespace ItemListPatcher.Parameters
{
  internal class SignedByte : Parameter
  {
    public SignedByte(int offset) : base(offset)
    {
    }

    public override void ReadValue(BinaryReader reader)
    {
      value = reader.ReadSByte();
    }

    public override void WriteValue(BinaryWriter writer)
    {
      writer.Write(Convert.ToSByte(value));
    }
  }
}
