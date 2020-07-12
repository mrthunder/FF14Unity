using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be instantiated when when the skills requirer any effect
public abstract class SkillEffect : MonoBehaviour
{
    [System.Serializable]
    public enum Type { Spell, Ability };
    public Sprite Icon = null;
    [HideInInspector]
    public string Name = "";
    [Header("Timers")]
    public string Effect = "";
    // How long it takes to cast
    public float Cast = 0f;
    // How long it takes to recast / cool down
    public float Recast = 0f;
    [Header("Information")]
    public Type SkillType = Type.Spell;
    public int MpCost = 0;
    // The radius tells if this skills is an AOE or single target
    public int Radius = 0;
    // The range signifies how far can this skill be activated
    public int Range = 0;

    public override int GetHashCode() => Name.GetHashCode();


}
