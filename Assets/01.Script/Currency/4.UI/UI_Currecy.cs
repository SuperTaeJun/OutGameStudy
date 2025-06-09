using TMPro;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;


public class UI_Currecy : MonoBehaviour
{
    public TextMeshProUGUI GoldCountText;
    public TextMeshProUGUI DiaCountText;

    private void Start()
    {
        Refresh();
        CurrecncyManager.Instance.OnDataChanged += Refresh;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyHealth();
        }
    }

    private void Refresh()
    {
        int gold = CurrecncyManager.Instance.Get(ECurrencyType.Gold).Value;
        int dia = CurrecncyManager.Instance.Get(ECurrencyType.Diamond).Value;

        GoldCountText.text = $"Gold : {gold}";
        DiaCountText.text = $"Dia : {dia}";
    }

    public void BuyHealth()
    {
        if (CurrecncyManager.Instance.TryBuy(ECurrencyType.Gold, 500))
        {
            var player = GameObject.FindFirstObjectByType<PlayerCharacterController>();
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.Heal(100);
        }

    }
}
