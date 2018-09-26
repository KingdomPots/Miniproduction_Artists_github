using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        if(item != null)
            item = null;
        if(icon.sprite != null)
            icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        item.Use();
    }

    public Item GetItem()
    {
        return item;
    }
}
