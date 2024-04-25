using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Interactable
{
    [SerializeField]
    private InventoryManager.AllItems _itemType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        InventoryManager.Instance.AddItem(_itemType);
        Destroy(gameObject);
    }
}
