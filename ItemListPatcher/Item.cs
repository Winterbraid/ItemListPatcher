using ItemListPatcher.Parameters;
using System.IO;

namespace ItemListPatcher
{
  internal class Item
  {
    private const int INITIAL_OFFSET = 16;
    private const int ITEM_SIZE = 128;

    public string name;
    public int id = 0;
    public int offset = 0;

    public ParameterSet parameters = new ParameterSet();

    public Item(int id)
    {
      this.id = id;

      name = Names.List[id];
      offset = INITIAL_OFFSET + id * ITEM_SIZE;
    }

    public void ReadData(BinaryReader reader)
    {
      foreach (Parameter parameter in parameters.ToArray())
      {
        parameter.Load(this, reader);
      }
    }

    public void WriteData(BinaryWriter writer)
    {
      foreach (Parameter parameter in parameters.ToArray())
      {
        parameter.Save(this, writer);
      }
    }
  }
}
