using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour {
    
    public Transform itemsParent;
    public GameObject inventoryUI;

    InventorySlot[] slots;

    Inventory inventory;

    public GameObject notesUI;
    public TextMeshProUGUI textUI;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory") && !GameManager.GetNoteOpen())
        {
            if(!inventoryUI.activeSelf)
            {
                inventoryUI.SetActive(true);
                GameManager.SetInInventory(true);
                Debug.Log("Loading Backpack");
            }
            else
            {
                inventoryUI.SetActive(false);
                GameManager.SetInInventory(false);
                Debug.Log("Closing Backpack");
            }
        }
    }

    void UpdateUI()
    {
        //if(GameManager.GetIsEnd())
        //{
        //   //this.slots = GameManager.storedSlots;
        //}
        for (int i = 0; i < slots.Length; i++)
        {

            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        //GameManager.storedSlots = this.slots;
        //Debug.Log("UPDATING INVENTORY");
    }

    public void UseNote(int noteNumber)
    {
        if(inventory.items.Count > noteNumber)
        {
            inventoryUI.SetActive(false);
            notesUI.SetActive(true);

            inventory.items[noteNumber].description = inventory.items[noteNumber].description.Replace("\\n", "\n");
            
            textUI.text = inventory.items[noteNumber].description;

            GameManager.SetNoteOpen(true);
        }
    }

    public void CloseNote()
    {
        inventoryUI.SetActive(true);
        notesUI.SetActive(false);
        textUI.text = "";

        GameManager.SetNoteOpen(false);
    }
}
