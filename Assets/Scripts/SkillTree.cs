using System.Collections.Generic;
using System.Linq;
public class SkillTree
{
    public List<SkillNode> Nodes = new List<SkillNode>();

    private Dictionary<string, List<SkillNode>> _skillsRelatedToID = new Dictionary<string, List<SkillNode>>();


    public List<SkillNode> GetAllSkillNodesRequiringSkill(string id)
    {
        if (_skillsRelatedToID.ContainsKey(id))
            return _skillsRelatedToID[id];
        else
        {
            List<SkillNode> foundSkillNodes = new List<SkillNode>();

            foreach (SkillNode skillNode in Nodes)
            {
                GetAllSkillNodesRequiringSkill(id, skillNode, foundSkillNodes);
            }

            _skillsRelatedToID.Add(id, foundSkillNodes);

            return foundSkillNodes;
        }
    }


    public List<SkillNode> GetAllSkillNodesRequiringSkill(string id, SkillNode parent,  List<SkillNode> skillNodes)
    {
        foreach (SkillNode skillNode in parent.ChildNodes)
        {
            if (!skillNodes.Contains(skillNode))
            {
                if (skillNode.SkillAcquireRequirement.SkillLevelRequirements.ContainsKey(id))
                {
                    skillNodes.Add(skillNode);
                }
            }

            GetAllSkillNodesRequiringSkill(id, skillNode, skillNodes);
        }

        return skillNodes;
    }
    public SkillNode FindSkillWithID(string id)
    {
        foreach (SkillNode skillNode in Nodes)
        {
            if (skillNode.SkillIdentityData.ID == id)
                return skillNode;

            SkillNode foundSkillNode = FindSkillWithID(id, skillNode);
            if (foundSkillNode != null)
                return foundSkillNode;
        }

        return null;
    }
    public SkillNode FindSkillWithID(string id, SkillNode parent)
    {
        foreach (SkillNode skillNode in parent.ChildNodes)
        {
            if (skillNode.SkillIdentityData.ID == id)
                return skillNode;
            else
                FindSkillWithID(id, skillNode);
        }

        return null;
    }
}
