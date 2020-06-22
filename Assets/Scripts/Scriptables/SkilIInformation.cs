using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Skill Name", menuName ="Scriptable Objects/Informations/Skill")]
public class SkillInformation : ScriptableObject
{
    [System.Serializable]
    public enum Type { Spell, Ability };
    public Sprite Icon = null;
    public string Name = "";
    public string Effect = "";
    // The radius tells if this skills is an AOE or single target
    public int Radius = 0;
    // The range signifies how far can this skill be activated
    public int Range = 0;
    // How long it takes to cast
    public float Cast = 0f;
    // How long it takes to recast / cooldown
    public float Recast = 0f;
    public Type SkillType = Type.Spell;
    public int MpCost = 0;
    public GameObject EffectPrefab = null;
}
