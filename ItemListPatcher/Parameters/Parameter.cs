using Newtonsoft.Json;
using System.IO;

namespace ItemListPatcher.Parameters
{
  [JsonConverter(typeof(ParameterConverter))]
  internal abstract class Parameter
  {
    private readonly int offset;

    public object value;

    protected Parameter(int offset)
    {
      this.offset = offset;
    }

    public void Load(Item item, BinaryReader reader)
    {
      reader.BaseStream.Seek(item.offset + offset, SeekOrigin.Begin);

      ReadValue(reader);
    }

    public void Save(Item item, BinaryWriter writer)
    {
      writer.BaseStream.Seek(item.offset + offset, SeekOrigin.Begin);

      WriteValue(writer);
    }

    public virtual void ReadValue(BinaryReader reader)
    {

    }

    public virtual void WriteValue(BinaryWriter writer)
    {

    }
  }
}
