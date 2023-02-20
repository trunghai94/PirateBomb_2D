using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "GameConfigs/Character", order = 1)]
public class CharacterScriptable : ScriptableObject
{
    public float MaxHP;
    public string Name;
    public float Armor;
    public float Speed;
    public AnimatorController Anim;
}
