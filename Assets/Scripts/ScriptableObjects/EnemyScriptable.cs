using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "GameConfigs/Enemy", order = 1)]
public class EnemyScriptable : ScriptableObject
{
    public float MaxHp;
    public float Speed;
    public AnimatorController AnimController;
}
