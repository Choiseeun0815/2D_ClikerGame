using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("Reference")]
    [SerializeField] public EnemySO Data;

    public int curHP;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        curHP = Data.maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if (curHP <= 0)
        {
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
        else
        {
            Debug.LogWarning("Animator is not assigned in Enemy!");
        }
    }
    private IEnumerator DisableAfterAnimation()
    {
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
