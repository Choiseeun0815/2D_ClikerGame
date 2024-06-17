using System;
using System.Collections;
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

    private void OnDisable()
    {
        curHP = Data.maxHealth;
        enemyHpBar.UpdateHpBar(curHP, Data.maxHealth);
    }
    public void TakeDamage(float damage)
    {
        curHP -= damage;
        enemyHpBar.UpdateHpBar(curHP, Data.maxHealth);

        if (curHP <= 0)
        {
            GameManager.Instance.currentMiniState++;
            if(GameManager.Instance.currentMiniState > 5) 
            {
                GameManager.Instance.currentMiniState = 1;
                GameManager.Instance.currentStage++;
            }

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetTrigger("Die");
            StartCoroutine(DisableAfterAnimation());
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
        GameManager.Instance.enemySpawner.SpawningEnemy();
    }
}
