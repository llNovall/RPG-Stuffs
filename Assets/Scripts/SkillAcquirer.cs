using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAcquirer : MonoBehaviour
{
    public List<string> StartingSkills = new List<string>();

    public SkillTree SkillTree;

    public Dictionary<string, EESkillAndLevelPair> Skills = new Dictionary<string, EESkillAndLevelPair>();
    public List<SkillNode> AcquirableSkills = new List<SkillNode>();

    private void Start()
    {
        SkillTree = new SkillTree();

        SkillNode tinyFlame = new SkillNode(new SkillIdentityData("TinyFlame", "Tiny Flame", "EEEmber"),
            new SkillExpData(1, 20, 100, 1.1f,1),
            new SkillAcquireRequirement(new Dictionary<string, int>(), 0),
            new SkillAddAndRemovalData());

        SkillNode ember = new SkillNode(new SkillIdentityData("Ember", "Ember", typeof(EEEmber).FullName),
            new SkillExpData(1, 20, 100, 1.1f,1),
            new SkillAcquireRequirement(new Dictionary<string, int>(), 0),
            new SkillAddAndRemovalData());

        ember.ChildNodes.Add(tinyFlame);
        tinyFlame.ParentNodes.Add(ember);

        SkillTree.Nodes.Add(ember);

        StartingSkills = new List<string> { "Ember" };

        AddInitialSkills();

    }

    public void AddInitialSkills()
    {
        foreach (string skillID in StartingSkills)
        {
            AddSkill(skillID);
        }
    }

    public void AcquireSkill(SkillNode skillNode)
    {
        if (AcquirableSkills.Contains(skillNode))
        {
            foreach (string skillID in skillNode.SkillAddAndRemovalData.SkillsToRemove)
            {
                if (Skills.ContainsKey(skillID))
                {
                    EESkill skill = Skills[skillID].EESkill;
                    Destroy(skill);
                    Skills.Remove(skillID);
                }
            }

            foreach (string stringID in skillNode.SkillAddAndRemovalData.SkillsToAdd)
            {
                AddSkill(stringID);
            }
        }
        else
            Debug.LogError($"{GetType().FullName} : Failed to find {skillNode.SkillIdentityData.ID}.");
    }
    private void AddSkill(string skillID)
    {
        SkillNode foundSkillNode = SkillTree.FindSkillWithID(skillID);

        if (foundSkillNode != null)
        {
            EESkill eeSkill = gameObject.AddComponent(Type.GetType(foundSkillNode.SkillIdentityData.SkillComponentName)) as EESkill;
            eeSkill.InitializeSkill(foundSkillNode);
            eeSkill.OnLevelUp += EeSkill_OnLevelUp;
            Skills.Add(foundSkillNode.SkillIdentityData.ID,
                new EESkillAndLevelPair(foundSkillNode.SkillExpData.StartLevel, eeSkill));
        }
    }
    private void EeSkill_OnLevelUp(string skillID, int level)
    {
        if (Skills.ContainsKey(skillID))
        {
            Skills[skillID].Level = level;

            List<SkillNode> foundSkills = SkillTree.GetAllSkillNodesRequiringSkill(skillID);

            for (int i = 0; i < foundSkills.Count; i++)
            {
                if (IsRequirementsMetFor(foundSkills[i]))
                    if (!AcquirableSkills.Contains(foundSkills[i]))
                        AcquirableSkills.Add(foundSkills[i]);
            }
        }
        else
            Debug.LogError("Failed to find skill ID");
    }

    private bool IsRequirementsMetFor(SkillNode skillNode)
    {
        if (!Skills.ContainsKey(skillNode.SkillIdentityData.ID))
        {
            foreach (var item in skillNode.SkillAcquireRequirement.SkillLevelRequirements)
            {
                if (Skills.ContainsKey(item.Key))
                {
                    if (Skills[item.Key].Level < item.Value)
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        return false;
    }
}
