
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StageTxt;
    [SerializeField] private TextMeshProUGUI GoldTxt;
    [SerializeField] private GameObject UpgradeStatPanel;

    [SerializeField] private TextMeshProUGUI attackUpgradeBtnTxt;

    private void Start()
    {
        UpgradeStatPanel.SetActive(false);
        SetUpgradeStatPanel();
    }
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            StageTxt.text = $"Stage {GameManager.Instance.currentStage}-{GameManager.Instance.currentMiniState}";
            GoldTxt.text = $"GOLD : {GameManager.Instance.Gold} G";
        }
    }

    public void OnStore(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            UpgradeStatPanel.SetActive(!UpgradeStatPanel.activeSelf);
        }
    }

    public void SetUpgradeStatPanel()
    {
        if (GameManager.Instance != null)
        {
            attackUpgradeBtnTxt.text = $"{GameManager.Instance.upgradeState.currentAttakUpgradeCost}G\n" +
            $"Upgrade\n" +
            $"<color=#FF0000>+{GameManager.Instance.upgradeState.plusAttackStat}</color>";
        }
    }
}
