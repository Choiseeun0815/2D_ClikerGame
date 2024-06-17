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

    private IEnumerator DisableAfterAnimation()
    {
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        gameObject.SetActive(false);
    }
}
