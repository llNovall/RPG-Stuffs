using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EEJump : ExperienceEarnable
{
    [SerializeField]
    private JumpData _jumpData;

    public event UnityAction<float> OnJumpHeightChanged;
    protected override void OnLevelUp_UpdateStats()
    {
        _jumpData.JumpHeight = Mathf.Lerp(_jumpData.MinJumpHeight, _jumpData.MaxJumpHeight, _expData.Level / _expData.MaxLevel);
        OnJumpHeightChanged?.Invoke(_jumpData.JumpHeight);
    }
}
