using ItemListPatcher.Parameters;

namespace ItemListPatcher
{
  internal class ParameterSet
  {
    public Attack offense = new Attack();
    public Defense defense = new Defense();
    public Impact impact = new Impact();

    public SignedByte resistPierce = new SignedByte(22);
    public SignedByte resistStrike = new SignedByte(23);
    public SignedByte resistFire = new SignedByte(24);
    public SignedByte resistIce = new SignedByte(25);
    public SignedByte resistLightning = new SignedByte(26);
    public SignedByte resistHoly = new SignedByte(27);
    public SignedByte resistDark = new SignedByte(28);

    public SignedByte resistKnockdown = new SignedByte(34);
    public SignedByte resistStagger = new SignedByte(35);

    public SignedByte resistPoison = new SignedByte(37);
    public SignedByte resistTorpor = new SignedByte(38);
    public SignedByte resistSleep = new SignedByte(40);
    public SignedByte resistSilence = new SignedByte(44);
    public SignedByte resistStifle = new SignedByte(45);
    public SignedByte resistCurse = new SignedByte(46);

    public SignedByte resistLowStr = new SignedByte(48);
    public SignedByte resistLowDef = new SignedByte(49);
    public SignedByte resistLowMag = new SignedByte(50);
    public SignedByte resistLowMagDef = new SignedByte(51);

    public Integer32 canEquip = new Integer32(53);
    public Integer16 model = new Integer16(64);
    public Single weight = new Single(68);
    public Integer32 value = new Integer32(76);

    public Parameter[] ToArray()
    {
      return new Parameter[]
      {
        offense,
        defense,
        impact,

        resistPierce,
        resistStrike,
        resistFire,
        resistIce,
        resistLightning,
        resistHoly,
        resistDark,

        resistKnockdown,
        resistStagger,

        resistPoison,
        resistTorpor,
        resistSleep,
        resistSilence,
        resistStifle,
        resistCurse,

        resistLowStr,
        resistLowDef,
        resistLowMag,
        resistLowMagDef,

        canEquip,
        model,
        weight,
        value
      };
    }
  }
}
