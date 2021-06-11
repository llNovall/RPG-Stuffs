
using System.Collections.Generic;

public struct SkillAcquireRequirement
{
    public Dictionary<string, int> SkillLevelRequirements;
    public int PointsRequired;

    public SkillAcquireRequirement(Dictionary<string, int> skillLevelRequirements, int pointsRequired)
    {
        SkillLevelRequirements = skillLevelRequirements;
        PointsRequired = pointsRequired;
    }
}
