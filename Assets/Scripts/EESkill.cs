using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EESkill : MonoBehaviour
{
    [SerializeField]
    private SkillNode _skillNode;

    [SerializeField]
    protected ExpData _expData;

    public event UnityAction<string, int> OnLevelUp;
    public event UnityAction<string> OnMaxLevelReached;
    public event UnityAction<float> OnExpChanged;
    public event UnityAction<float> OnMaxExpChanged;

    public void InitializeSkill(SkillNode skillNode)
    {
        _skillNode = skillNode;
        _expData = new ExpData(skillNode.SkillExpData.StartLevel, skillNode.SkillExpData.MaxLevel, 0, skillNode.SkillExpData.BaseMaxExperience, skillNode.SkillExpData.MaxExpScalerAfterLevelUp, skillNode.SkillExpData.EffectivenessFromExpLevel);
    }
    public void ModifyExp(float exp)
    {
        if (_expData.Level < _expData.MaxLevel)
        {
            if (exp + _expData.Exp >= _expData.MaxExp)
            {
                _expData.Exp = exp - (_expData.MaxExp - _expData.Exp);
                _expData.Level++;
                _expData.MaxExp += _expData.MaxExp * _expData.MaxExpScalerAfterLevelUp;

                OnLevelUp?.Invoke(_skillNode.SkillIdentityData.ID, _expData.Level);
                OnMaxExpChanged?.Invoke(_expData.MaxExp);
                OnExpChanged?.Invoke(_expData.Exp);

                OnLevelUp_UpdateStats();

                if (_expData.Level == _expData.MaxLevel)
                {
                    OnMaxLevelReached?.Invoke(_skillNode.SkillIdentityData.ID);
                    OnLevelUP_MaxLevelReached();
                }
            }
            else
            {
                _expData.Exp = Mathf.Max(_expData.Exp + exp, 0);
                OnExpChanged?.Invoke(_expData.Exp);
            }
        }
    }

    protected abstract void OnLevelUp_UpdateStats();
    protected abstract void OnLevelUP_MaxLevelReached();

}
