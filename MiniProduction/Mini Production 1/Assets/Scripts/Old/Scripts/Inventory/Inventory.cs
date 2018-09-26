using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject notePickup1;

    public int space = 12;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(!item.isDefault )
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }
}
