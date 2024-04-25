using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<AllItems> _inventoryItems = new List<AllItems>();

    private void Awake()
    {
        Instance = this;
    }

    public enum AllItems
    {
        BlueKey,
        RedKey,
        PurpleKey,
        FinalKey
    }

    public void AddItem(AllItems items)
    {
        if (!_inventoryItems.Contains(items))
        {
            _inventoryItems.Add(items);
        }
    }

    public void RemoveItem(AllItems items)
    {
        if (!_inventoryItems.Contains(items))
        {
            _inventoryItems.Remove(items);
        }
    }
}
