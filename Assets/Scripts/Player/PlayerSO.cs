using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Palyer")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int Damage;
    [SerializeField] public float evasionRate; // 회피율
    [SerializeField] public float AutoAttackSpeed; //자동 클릭 속도
}
