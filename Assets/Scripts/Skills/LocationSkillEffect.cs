using UnityEngine;

public abstract class LocationSkillEffect : SkillEffect
{
    public abstract void ActivateOnLocation(StatsComponent user, Vector3 location);
}
