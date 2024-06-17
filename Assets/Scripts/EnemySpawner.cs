using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public Transform spawnPos;
    [SerializeField] public Transform targetPos;

    public void SpawningEnemy()
    {
        if (GameManager.Instance.pool.pools.Count == 0) return;

        int rndIndex = Random.Range(0, GameManager.Instance.pool.pools.Count);
        Debug.Log($"pools.Count : {GameManager.Instance.pool.pools.Count}");
        var selecetedEnemy = GameManager.Instance.pool.pools[rndIndex];

        GameObject enemyObj = GameManager.Instance.pool.SpawnFromPool(selecetedEnemy.tag);
        Debug.Log($"curRndIndex : {rndIndex} // tag : {selecetedEnemy.tag}" );

        if (enemyObj != null)
        {
            enemyObj.transform.position = spawnPos.position;
            enemyObj.SetActive(true);

            Enemy enemy = enemyObj.GetComponent<Enemy>();
            if (enemy != null)
            {
                StartCoroutine(MoveToTargetPos(enemyObj));
            }
        }
    }
    private IEnumerator MoveToTargetPos(GameObject enemyObj)
    {
        Enemy enemy = enemyObj.GetComponent<Enemy>();

        while (enemyObj != null && Vector2.Distance(enemyObj.transform.position, targetPos.position) > 0.1f)
        {
            if (enemy != null)
            {
                enemy.RunAnim(true);
                // 몬스터가 달려오는 중에는 콜라이더를 비활성화하여 공격이 불가능하도록 함
                enemy.GetComponent<BoxCollider2D>().enabled = false;
            }

            enemyObj.transform.position = Vector2.MoveTowards(enemyObj.transform.position, targetPos.position, 4f * Time.deltaTime);
            yield return null;

            if (enemy != null)
            {
                enemy.RunAnim(false);
                enemy.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    
}
