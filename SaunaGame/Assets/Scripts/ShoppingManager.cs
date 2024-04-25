using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingManager : MonoBehaviour
{
    public static bool isOpenUI = false;
    [SerializeField]
    private Button speedButton;
    [SerializeField]
    private Button highJumpButton;

    private int moneySafe = 0;
    [SerializeField]
    private int speedButtonMoney;
    [SerializeField]
    private int jumpButtonMoney;
    private bool isSpeedBuy = false;
    private bool isHighJumpBuy = false;

    public void AddMoneyUp(int money)
    {
        moneySafe += money;
    }

    void setSpeeditem(bool isBuy)
    {
        isSpeedBuy = isBuy;
    }
    public bool getSpeedBought()
    {
        return isSpeedBuy;
    }

    void setHighJumpitem(bool isBuy)
    {
        isHighJumpBuy = isBuy;
    }
    public bool getHighJumpBought()
    {
        return isHighJumpBuy;
    }
    void Decreasemoney(int money)
    {
        if(getMoney() < 0 || getMoney() - money < 0)
        {
            moneySafe = 0;
        }
        else
        {
            moneySafe -= money;
        }
        
        //Mathf.Clamp(moneySafe, 0, 2000);
    }

    public int getMoney()
    {
        return moneySafe;
    }

    public void ClickSpeedButton()
    {
        if (getMoney() >= speedButtonMoney)
        {
            Debug.Log("BUY ITEM");
            speedButton.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.75f);
            speedButton.interactable = false;
            Decreasemoney(speedButtonMoney);
            setSpeeditem(true);
        }
        else
        {
            Debug.Log("CAN'T BUY ITEM");
            setSpeeditem(false);
        }
    }

    public void ClickHighJumpButton()
    {
        if (getMoney() >= jumpButtonMoney)
        {
            Debug.Log("BUY ITEM");
            highJumpButton.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.75f);
            highJumpButton.interactable = false;
            Decreasemoney(jumpButtonMoney);
            setHighJumpitem(true);
        }
        else
        {
            Debug.Log("CAN'T BUY ITEM");
            setHighJumpitem(false);
        }
    }


    public void OpenUIButton()
    {
        Cursor.visible = true;
        isOpenUI = true;
    }
    public void ExitButton()
    {
        isOpenUI = false;
    }


}
