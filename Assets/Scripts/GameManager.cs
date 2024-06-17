using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectPool pool;
    public EnemySpawner enemySpawner;
    public UpgradeState upgradeState;

    // Stage 5-1 => 5는 currentStage, 1은 currentMiniState
    public int currentStage = 1;
    public int currentMiniState = 1;

    public bool CanAutoAttack = false; //AutoAttack 아이템을 구매하면 true로 전환

    public int Gold = 0;

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
        enemySpawner = GetComponent<EnemySpawner>();
        upgradeState = GetComponent<UpgradeState>();
    }

    private void Start()
    {
        if(enemySpawner != null )
            enemySpawner.SpawningEnemy();
    }

    
}
