using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMoneyChange : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI proUGUI;
    [SerializeField]
    private ShoppingManager shoppingManager;
    [SerializeField]
    private TextMeshProUGUI proUGUIHp;
    [SerializeField]
    private PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        proUGUI.text = "Money: " + shoppingManager.getMoney();
        proUGUIHp.text = "HP : " + (int)playerHealth.getHealth();
    }
}
