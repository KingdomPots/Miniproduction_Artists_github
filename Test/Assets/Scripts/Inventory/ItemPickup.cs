using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour {

    public Item item;

    public void Interact()
    {
        //base.Interact();
        Debug.Log("Interacting with " + transform.name);

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        if (Inventory.instance.Add(item))
        {
            GameManager.IncreaseNotes();
            Destroy(gameObject);
        }
    }
}
