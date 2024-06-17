using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    private Slider hpBar;

    private void Awake()
    {
        hpBar = GetComponent<Slider>();
    }
    
    void Update()
    {
        
    }

    public void UpdateHpBar(float curHp, float maxHp)
    {
        hpBar.value = curHp / maxHp;
    }
}
