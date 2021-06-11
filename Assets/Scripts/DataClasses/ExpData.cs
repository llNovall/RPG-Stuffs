[System.Serializable]
public struct ExpData
{
    public int Level;
    public int MaxLevel;

    public float Exp;
    public float MaxExp;

    public float MaxExpScalerAfterLevelUp;

    public float EffectivenessFromExpLevel;

    public ExpData(int level, int maxLevel, float exp, float maxExp, float maxExpScalerAfterLevelUp, float effectivenessFromExpLevel)
    {
        Level = level;
        MaxLevel = maxLevel;
        Exp = exp;
        MaxExp = maxExp;
        MaxExpScalerAfterLevelUp = maxExpScalerAfterLevelUp;
        EffectivenessFromExpLevel = effectivenessFromExpLevel;
    }
}
