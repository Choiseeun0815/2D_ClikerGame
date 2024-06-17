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

    public event Action OnDeath; // 죽었을 때 발생하는 이벤트
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
        //OnDeath = null;
    }
    public void TakeDamage(float damage)
    {
        curHP -= damage;
        enemyHpBar.UpdateHpBar(curHP, Data.maxHealth);
        if (curHP <= 0)
        {
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
        OnDeath?.Invoke();
    }
}
