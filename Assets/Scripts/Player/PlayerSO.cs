using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Palyer")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int Damage;
    [SerializeField] public float evasionRate; // ȸ����
    [SerializeField] public float AutoAttackSpeed; //�ڵ� Ŭ�� �ӵ�
}
