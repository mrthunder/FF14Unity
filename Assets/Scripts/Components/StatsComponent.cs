using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("Health: {_currentHealth}")]
public class StatsComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    private int _currentHealth = 100;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void RecoverHealth(int amount)
    {
        var clampAmount = Mathf.Clamp(amount, 0, _maxHealth - _currentHealth);
        _currentHealth = clampAmount;
    }
}
