using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable {

    public Item item;

    public Text pickUpPaper;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        if (Inventory.instance.Add(item))
        {
            GameManager.IncreaseNotes();
            Destroy(gameObject);

            if(GameObject.FindGameObjectWithTag("pickUpNote1") != null)
                Destroy(GameObject.FindGameObjectWithTag("pickUpNote1").gameObject);

        }
    }

    void OnDestroy()
    {
        if (pickUpPaper != null)
        {
            Destroy(pickUpPaper.gameObject);
        }
    }
}
