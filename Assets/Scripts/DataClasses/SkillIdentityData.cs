
public struct SkillIdentityData
{
    public string ID { get; }
    public string SkillName { get; }
    public string SkillComponentName { get; }
    public SkillIdentityData(string iD, string skillName, string skillComponentName)
    {
        ID = iD;
        SkillName = skillName;
        SkillComponentName = skillComponentName;
    }
}
