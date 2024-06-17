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
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("OnAttack()");
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(Data.Damage);
                    animator.SetTrigger("Attack");
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        animator.SetTrigger("Hit");
    }
    
}
