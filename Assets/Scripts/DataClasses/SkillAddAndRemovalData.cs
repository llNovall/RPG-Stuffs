using System.Collections.Generic;

public struct SkillAddAndRemovalData
{
    public List<string> SkillsToAdd { get; }
    public List<string> SkillsToRemove { get; }

    public SkillAddAndRemovalData(List<string> skillsToAdd, List<string> skillsToRemove)
    {
        SkillsToAdd = skillsToAdd;
        SkillsToRemove = skillsToRemove;
    }
}
