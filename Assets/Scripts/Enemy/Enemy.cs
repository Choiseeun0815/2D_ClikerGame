using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("Reference")]
    [SerializeField] public EnemySO Data;

    public float curHP;
    private int previousStage;
    private Animator animator;

    [SerializeField] EnemyHpBar enemyHpBar;
    private AudioSource audioSource;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyHpBar = GetComponentInChildren<EnemyHpBar>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        curHP = Data.maxHealth;
        enemyHpBar.UpdateHpBar(curHP, Data.maxHealth);
        previousStage = GameManager.Instance.currentStage;
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

            GameManager.Instance.Gold += Data.Gold;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetTrigger("Die");

            Data.maxHealth += GameManager.Instance.currentStage;

            audioSource.PlayOneShot(SoundManager.Instance.EnemyDieSound);

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
