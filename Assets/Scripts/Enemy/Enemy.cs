using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("Reference")]
    [SerializeField] public EnemySO Data;

    public int curHP;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        curHP = Data.maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        //curHP -= CharacterManager.Instance.Player.controller.Data.Damage;
        animator.SetTrigger("Hit");
    }
}
