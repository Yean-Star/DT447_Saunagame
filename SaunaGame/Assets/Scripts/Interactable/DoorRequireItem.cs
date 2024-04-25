using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRequireItem : Interactable
{
    [SerializeField]
    private InventoryManager.AllItems requireItem;
    // Start is called before the first frame update


    protected override void Interact()
    {
        if (HasRequiredItem(requireItem))
        {
            InventoryManager.Instance.RemoveItem(requireItem);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(requireItem.ToString());
        }
    }
    public bool HasRequiredItem(InventoryManager.AllItems itemRequire)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequire))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
