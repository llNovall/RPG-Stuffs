using UnityEngine;
using UnityEngine.Events;

public abstract class ExperienceEarnable : MonoBehaviour
{
    public float EffectivenessFromExpLevel;

    [SerializeField]
    protected ExpData _expData;

    public event UnityAction<int> OnLevelUp;
    public event UnityAction OnMaxLevelReached;
    public event UnityAction<float> OnExpChanged;
    public event UnityAction<float> OnMaxExpChanged;

    public void ModifyExp(float exp)
    {
        if (_expData.Level < _expData.MaxLevel)
        {
            if (exp + _expData.Exp >= _expData.MaxExp)
            {
                _expData.Exp = exp - (_expData.MaxExp - _expData.Exp);
                _expData.Level++;
                _expData.MaxExp += _expData.MaxExp * _expData.MaxExpScalerAfterLevelUp;

                OnLevelUp?.Invoke(_expData.Level);
                OnMaxExpChanged?.Invoke(_expData.MaxExp);
                OnExpChanged?.Invoke(_expData.Exp);

                OnLevelUp_UpdateStats();

                if (_expData.Level == _expData.MaxLevel)
                {
                    OnMaxLevelReached?.Invoke();
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
}
