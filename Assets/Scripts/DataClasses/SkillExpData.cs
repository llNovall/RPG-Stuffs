
public struct SkillExpData
{
    public int StartLevel { get; }
    public int MaxLevel { get; }
    public float BaseMaxExperience { get; }
    public float MaxExpScalerAfterLevelUp { get; }
    public float EffectivenessFromExpLevel { get; }
    public SkillExpData(int startLevel, int maxLevel, float baseMaxExperience, float maxExpScalerAfterLevelUp, float effectivenessFromExpLevel)
    {
        StartLevel = startLevel;
        MaxLevel = maxLevel;
        BaseMaxExperience = baseMaxExperience;
        MaxExpScalerAfterLevelUp = maxExpScalerAfterLevelUp;
        EffectivenessFromExpLevel = effectivenessFromExpLevel;
    }

}
