using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be instantiated when when the skills requirer any effect
public abstract class SkillEffect : MonoBehaviour
{
    [System.Serializable]
    public enum Type { Spell, Ability };
    [PreviewField(Alignment = ObjectFieldAlignment.Left), HorizontalGroup("Group 1", Width = 50), HideLabel]
    public Sprite Icon = null;
    [HideInInspector]
    public string Name = "";
    [HorizontalGroup("Group 1"), TextArea, HideLabel]
    public string Effect = "";
    [TitleGroup("Timers")]
    // How long it takes to cast
    public float Cast = 0f;
    [TitleGroup("Timers")]
    // How long it takes to recast / cool down
    public float Recast = 0f;
    [TitleGroup("Information")]
    public Type SkillType = Type.Spell;
    [TitleGroup("Information")]
    public int MpCost = 0;
    [TitleGroup("Information")]
    // The radius tells if this skills is an AOE or single target
    public int Radius = 0;
    [TitleGroup("Information")]
    // The range signifies how far can this skill be activated
    public int Range = 0;


   
    
}
