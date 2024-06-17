using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] public PlayerSO Data;
    private AudioSource audioSource;

    private Animator animator;

    private bool isAttacking = false;
    private float attackTime = 0f;
    private float hitTime = 0.03f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                    PlayRandomAttackSound();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Instance.CanAutoAttack && collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy!=null)
            {
                StartCoroutine(AttackAutoEnemy(enemy));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            isAttacking = false;
        }
    }
    private IEnumerator AttackAutoEnemy(Enemy enemy)
    {
        isAttacking = true;
        while(enemy!= null && isAttacking)
        {
            enemy.TakeDamage(Data.Damage);
            animator.SetTrigger("AutoAttack");
            PlayRandomAttackSound();
            yield return new WaitForSeconds(Data.AutoAttackSpeed);
        }
        isAttacking = false;
    }
    
    private void PlayRandomAttackSound()
    {
        int randomIdx = UnityEngine.Random.Range(0, 2);
        AudioClip attackAudio = randomIdx == 0 ? SoundManager.Instance.attackSound1 : SoundManager.Instance.attackSound2;
        audioSource.PlayOneShot(attackAudio);

    }
}
