using System.Collections.Generic;

public class SkillNode
{
    public SkillIdentityData SkillIdentityData { get; }

    public SkillExpData SkillExpData { get; }

    public SkillAcquireRequirement SkillAcquireRequirement {get;}

    public SkillAddAndRemovalData SkillAddAndRemovalData { get; }

    public List<SkillNode> ParentNodes;
    public List<SkillNode> ChildNodes;

    public SkillNode(SkillIdentityData skillIdentityData, SkillExpData skillExpData, SkillAcquireRequirement skillAcquireRequirement, SkillAddAndRemovalData skillAddAndRemovalData)
    {
        SkillIdentityData = skillIdentityData;
        SkillExpData = skillExpData;
        SkillAcquireRequirement = skillAcquireRequirement;
        SkillAddAndRemovalData = skillAddAndRemovalData;

        ParentNodes = new List<SkillNode>();
        ChildNodes = new List<SkillNode>();
    }

}
