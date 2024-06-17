using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StageTxt;
    [SerializeField] private TextMeshProUGUI GoldTxt;
    [SerializeField] private GameObject UpgradeStatPanel;

    [Header("Attack Upgrade Button")]
    [SerializeField] private TextMeshProUGUI attackUpgradeBtnTxt;
    [SerializeField] private TextMeshProUGUI CurrnetAttackStat;
    [SerializeField] private Image attackUpgradeBtnColor;

    [Header("AutoAttack Upgrade Button")]
    [SerializeField] private TextMeshProUGUI AutoAttackUpgradeBtnTxt;
    [SerializeField] private TextMeshProUGUI CurrnetAutoStat;
    [SerializeField] private Image AutoUpgradeBtnColor;

    private void Start()
    {
        UpgradeStatPanel.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            StageTxt.text = $"Stage {GameManager.Instance.currentStage}-{GameManager.Instance.currentMiniState}";
            GoldTxt.text = $"GOLD : {GameManager.Instance.Gold} G";

            SetButtonColor();
            
            SetUpgradeAttackTxt(); SetUpgradeAutoTxt();
        }
    }

    public void OnStore(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            UpgradeStatPanel.SetActive(!UpgradeStatPanel.activeSelf);
        }
    }

    public void SetUpgradeAttackTxt()
    {
        if (GameManager.Instance != null)
        {
            //<color=#FF0000> ¡æ »¡°£»ö
            attackUpgradeBtnTxt.text = $"{GameManager.Instance.upgradeState.currentAttakUpgradeCost}G\n" +
            $"Upgrade\n" +
            $"<color=#FF0000>+{GameManager.Instance.upgradeState.plusAttackStat}</color>";

            CurrnetAttackStat.text = $"Current Attack\nLv.<color=#FF0000>{GameManager.Instance.upgradeState.attackLevel}</color>" +
                $"\nDamage : <color=#FF0000>{CharacterManager.Instance.Player.controller.Data.Damage}</color>";
        }
    }

    public void SetUpgradeAutoTxt()
    {
        if (GameManager.Instance != null)
        {
            AutoAttackUpgradeBtnTxt.text = $"{GameManager.Instance.upgradeState.currentAutoUpgradeCost}G\n" +
           $"Upgrade\n" +
           $"<color=#FF0000>-{0.05}</color>";

            CurrnetAutoStat.text = $"Auto Attack\nLv.<color=#FF0000>{GameManager.Instance.upgradeState.autoAttackLevel}</color>" +
                $"\nSpeed : {CharacterManager.Instance.Player.controller.Data.AutoAttackSpeed}";
        }
    }

    void SetButtonColor()
    {
        if (GameManager.Instance.upgradeState.currentAttakUpgradeCost > GameManager.Instance.Gold)
        {
            attackUpgradeBtnColor.color = new Color(0.9f, 0.9f, 0.9f); 
        }
        else
        {
            attackUpgradeBtnColor.color = Color.green;
        }

        if (GameManager.Instance.upgradeState.currentAutoUpgradeCost > GameManager.Instance.Gold)
        {
            AutoUpgradeBtnColor.color = new Color(0.9f, 0.9f, 0.9f); 
        }
        else
        {
            AutoUpgradeBtnColor.color = Color.green;
        }

    }
}
