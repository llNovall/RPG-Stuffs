
using System;

[Serializable]
public class EESkillAndLevelPair
{
    public int Level;
    public EESkill EESkill;

    public EESkillAndLevelPair(int level, EESkill eESkill)
    {
        Level = level;
        EESkill = eESkill;
    }
}
