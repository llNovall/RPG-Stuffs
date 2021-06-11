using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EEHealth : ExperienceEarnable
{
    [SerializeField]
    private HealthData _healthData;

    public event UnityAction<float> OnHealthChanged;
    public event UnityAction<float> OnMaxHealthChanged;
    public event UnityAction<HealthData> OnHealthDataUpdated;
    public event UnityAction OnHealthDepleted;

    protected override void OnLevelUp_UpdateStats()
    {
        _healthData.MaxHealth += EffectivenessFromExpLevel * _healthData.MaxHealth;

        OnMaxHealthChanged?.Invoke(_healthData.MaxHealth);
        OnHealthDataUpdated?.Invoke(_healthData);
    }

    public void ModifyHealth(float value)
    {
        _healthData.Health = Mathf.Clamp(_healthData.Health + value, 0, _healthData.MaxHealth);

        OnHealthChanged?.Invoke(_healthData.Health);
        OnHealthDataUpdated?.Invoke(_healthData);

        if(_healthData.Health == 0)
        {
            OnHealthDepleted?.Invoke();
        }
    }
}
