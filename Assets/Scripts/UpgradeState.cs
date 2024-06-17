using UnityEngine;

public class UpgradeState: MonoBehaviour
{
    public int attackLevel = 1;
    public int currentAttakUpgradeCost = 1;
    public float plusAttackStat = 1.2f;
    public void UpgradeAttackStat()
    {
        if(GameManager.Instance !=null && CharacterManager.Instance !=null)
        {
            if (GameManager.Instance.Gold >= currentAttakUpgradeCost)
            {
                GameManager.Instance.Gold -= currentAttakUpgradeCost;
                CharacterManager.Instance.Player.controller.Data.Damage += plusAttackStat;
            }
        }
    }
}