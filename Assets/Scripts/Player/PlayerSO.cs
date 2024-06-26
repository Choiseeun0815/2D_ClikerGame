using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Palyer")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float Damage;
    [SerializeField] public float evasionRate; // 회피율
    [SerializeField] public float AutoAttackSpeed; //자동 클릭 속도
}
