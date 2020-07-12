using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "[Class or Job] Group", menuName = "Scriptable Objects/Informations/Skill Groups")]
public class SkillGroup : SerializedScriptableObject
{
    public Dictionary<string,Skill> SkillTable = new Dictionary<string, Skill>();
}

