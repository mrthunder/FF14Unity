using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : Skill
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Instantiate the effect on the target
    /// </summary>
    protected override void Use(StatsComponent target)
    {
        Instantiate(Information.EffectPrefab, target.transform, true);
    }
}
