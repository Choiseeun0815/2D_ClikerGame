using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Palyer")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int Damage;
    [SerializeField] public float evasionRate;
    [SerializeField] public float AutoAttackSpeed;
}
