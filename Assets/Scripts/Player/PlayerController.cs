using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public PlayerSO Data;

    private int curHP;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        curHP = Data.maxHealth;
    }

    void Update()
    {
        
    }
    public void OnAttack()
    {
        animator.SetBool("Attack", true);
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        //animator.SetTrigger("Hit");
    }

    
}
