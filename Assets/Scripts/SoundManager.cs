using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip attackSound1;
    public AudioClip attackSound2;

    public AudioClip UpgradeStatSound;

    public AudioClip EnemyDieSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //씬이 전환되어도 bgm이 계속 재생될 수 있도록 
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
