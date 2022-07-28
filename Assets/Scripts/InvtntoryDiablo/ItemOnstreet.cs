using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnstreet : MonoBehaviour, ICanUse
{
    [SerializeField] private ItemData itemData;

    public int Amount = 0;

    private Outline outline;

    private void Awake() 
    {
        outline = GetComponent<Outline>();    
    }

    public void ShowOutline(bool value)
    {
        outline.enabled = value;
    }

    //подобрать предмет с улицы
    public void TakeItem(InventoryController inventoryController )
    {       
        inventoryController.PickedUpItem(itemData, inventoryController.GetPlayerChest().GetChestGrid(), Amount);
        Destroy(gameObject);
    }

    public void Use()
    {
        ShowOutline(false);
        TakeItem(GameManager.singleton.GetComponent<InventoryController>());
    }
}
