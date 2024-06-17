using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectPool pool;
    public EnemySpawner enemySpawner;

    // Stage 5-1 => 5는 currentStage, 1은 currentMiniState
    int currentStage = 1;
    int currentMiniState = 1;

    bool CanAutoAttack = false; //AutoAttack 아이템을 구매하면 true로 전환

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();

        if(enemySpawner != null )
            enemySpawner.SpawningEnemy();
    }

    
}
