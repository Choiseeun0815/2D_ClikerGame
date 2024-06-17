using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("Reference")]
    [SerializeField] public EnemySO Data;

    public float curHP;

    private Animator animator;
    [SerializeField] EnemyHpBar enemyHpBar;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyHpBar = GetComponentInChildren<EnemyHpBar>();
    }
    void Start()
    {
        curHP = Data.maxHealth;
        enemyHpBar.UpdateHpBar(curHP, Data.maxHealth);
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        curHP = Data.maxHealth;
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        enemyHpBar.UpdateHpBar(curHP, Data.maxHealth);
        if (curHP <= 0)
        {
            animator.SetTrigger("Die");
            StartCoroutine(DisableAfterAnimation());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    public void RunAnim(bool isRunning)
    {
        if (animator != null)
        {
            animator.SetBool("Run", isRunning);
        }
    }
    private IEnumerator DisableAfterAnimation()
    {
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
