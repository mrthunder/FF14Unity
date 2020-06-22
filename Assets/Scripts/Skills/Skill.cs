using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    private SkillInformation information = null;
    public SkillInformation Information => information;

    // Those variables will store the moment when the skill was activated or the cooldown started
    protected float recastTime = 0f;
    protected float castingTime = 0f;

    private StatsComponent _target = null; 

    private void Update()
    {
        if(castingTime>0 && DidFinishedCasting())
        {
            castingTime = 0;
            Use(_target);
            StartCoolDown();
        }
        if(recastTime >0 && !IsInCoolDown())
        {
            recastTime = 0;
            _target = null;
        }
    }


    public void StartCasting(StatsComponent target)
    {
        if (castingTime > 0) return;
        castingTime = Time.time;
        _target = target;
    }
    private void StartCoolDown()
    {
        recastTime = Time.time;
    }

    protected abstract void Use(StatsComponent target);

    protected float GetCooldown()
    {
        float cooldown = (recastTime + information.Recast) - Time.time;
        return Mathf.Clamp(cooldown,0, information.Recast);
    }

    protected bool IsInCoolDown()
    {
        return recastTime + information.Recast > Time.time;
    }

    /// <summary>
    /// Return the progress of the skill cast between 0 and 1.
    /// </summary>
    public float GetCastingProgress()
    {
        float value = Mathf.Clamp((castingTime + information.Cast) - Time.time,0, information.Cast);
        return Mathf.InverseLerp(0, information.Cast, value);
    }

    /// <summary>
    /// Did the skill finished casting?
    /// </summary>
    public bool DidFinishedCasting()
    {
        return castingTime + information.Cast < Time.time;
    }
}
