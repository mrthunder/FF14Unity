using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "[Class or Job] Group", menuName = "Scriptable Objects/Informations/Skill Groups")]
public class SkillGroup : ScriptableObject
{
    public List<Skill> Skills = new List<Skill>();
}

