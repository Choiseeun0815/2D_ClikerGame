using UnityEngine;
using UnityEngine.UI;

public class UpgradeState: MonoBehaviour
{
    // �⺻ ����
    public int attackLevel = 1;
    public int currentAttakUpgradeCost = 1;
    public float plusAttackStat = 1f;

    // �ڵ� ����
    public int autoAttackLevel = 1;
    [SerializeField]private bool isFirstBuy = true;
    public int currentAutoUpgradeCost = 30;

    [SerializeField] private AudioSource audioSource;

    public void UpgradeAttackStat()
    {
        if(GameManager.Instance !=null && CharacterManager.Instance !=null)
        {
            if (GameManager.Instance.Gold >= currentAttakUpgradeCost)
            {
                GameManager.Instance.Gold -= currentAttakUpgradeCost;
                CharacterManager.Instance.Player.controller.Data.Damage += plusAttackStat;

                attackLevel++;
                currentAttakUpgradeCost = attackLevel % 3 == 0 ? currentAttakUpgradeCost + 1 : currentAttakUpgradeCost;
                plusAttackStat = attackLevel % 5 == 0 ? plusAttackStat + .5f : plusAttackStat;
            }

            audioSource.PlayOneShot(SoundManager.Instance.UpgradeStatSound);
        }
    }

    public void UpgradeAutoStat()
    {
        if (GameManager.Instance.Gold >= currentAutoUpgradeCost)
        {
            Debug.Log("isFirstBuy" + isFirstBuy);

            if (isFirstBuy)
            {
                GameManager.Instance.CanAutoAttack = true;
                GameManager.Instance.Gold -= currentAutoUpgradeCost;
                isFirstBuy = false;
            }
            else
            {
                GameManager.Instance.Gold -= currentAutoUpgradeCost;
            }

            autoAttackLevel++;
            currentAutoUpgradeCost += 10;
            
            CharacterManager.Instance.Player.controller.Data.AutoAttackSpeed -= 0.05f;

            if (CharacterManager.Instance.Player.controller.Data.AutoAttackSpeed < 0.1f)
            {
                //�ӵ��� 0.1f �Ʒ��� �������� �ʵ��� ���� 
                CharacterManager.Instance.Player.controller.Data.AutoAttackSpeed = 0.1f;
            }
            audioSource.PlayOneShot(SoundManager.Instance.UpgradeStatSound);
        }
    }

   
}