using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float Damage;
    [SerializeField] public float evasionRate;
    [SerializeField] public int Gold;
}
