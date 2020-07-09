using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : TargetSkillEffect
{
    [TitleGroup("Effect")]
    public int RecoveryPoints = 100;
    public float EffectDuration = 5f;

    public override void ActivateOnTarget(StatsComponent user, StatsComponent target)
    {
        if(target.CompareTag("Enemy"))
        {
            user.RecoverHealth(RecoveryPoints);
        }
        else
        {
            target.RecoverHealth(RecoveryPoints);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Name = "Heal";
        Destroy(gameObject, EffectDuration);
    }

}
