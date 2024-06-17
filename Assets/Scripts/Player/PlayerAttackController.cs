using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] public PlayerSO Data;

    private int curHP;
    private Animator animator;

    private bool isAttacking = false;
    private float attackTime = 0f;
    private float hitTime = 0.03f;

    void Start()
    {
        animator = GetComponent<Animator>();
        curHP = Data.maxHealth;
    }

    void Update()
    {
        
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (CheckAttacking()) return;

        if(context.performed)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(Data.Damage);
                    animator.SetTrigger("Attack");

                    isAttacking = true;
                }
            }
        }
    }
    private bool CheckAttacking()
    {
        if (isAttacking)
        {
            attackTime += Time.deltaTime;

            if (attackTime > hitTime)
            {
                attackTime = 0f;
                isAttacking = false;
            }
        }
        return isAttacking;
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        animator.SetTrigger("Hit");
    }
    
}
