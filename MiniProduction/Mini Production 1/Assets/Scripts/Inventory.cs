using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<bool> m_bIsFull;

    public GameObject m_inventory;
    private List<GameObject> m_inventorySlot;

    public GameObject m_keyUI;
    public GameObject m_cardUI;

    public bool hasYellowKey, hasBlueKey, hasGreenKey, hasID;

    private PickupObject m_pickUp;
    private bool m_blueInst = false;
    private bool m_idInst = false;
    void Start()
    {
        m_bIsFull = new List<bool>(20);
        m_inventorySlot = new List<GameObject>(20);
    }

    public void Update ()
    {
        if(!m_blueInst)
        {
            CheckKey(hasBlueKey, PickupObject.EPickups.BlueKey);
        }
        else
        {

            RemoveKey(hasBlueKey, PickupObject.EPickups.BlueKey);
        }

        if (!m_idInst)
        {
            CheckKey(hasID, PickupObject.EPickups.IDCard);
        }
        else
        {

            RemoveKey(hasID, PickupObject.EPickups.IDCard);
        }

    }

    void CheckKey(bool _hasKey, PickupObject.EPickups _keyType)
    {
        if (_hasKey && SearchKeyInInventory(_keyType) == 99999) //if key obtained and doesnt contain in list
        {
            GameObject _newKey;

            if (_keyType == PickupObject.EPickups.IDCard)
            {
                _newKey = (GameObject)Instantiate(m_cardUI, m_cardUI.transform.position, m_cardUI.transform.rotation);
                Debug.Log("Instantiated: ID card");
            }
            else
            {
                _newKey = (GameObject)Instantiate(m_keyUI, m_keyUI.transform.position, m_keyUI.transform.rotation);
                Debug.Log("Instantiated: key ");

            }

            _newKey.GetComponent<PickupObject>().pickUpObject.pickupType = _keyType;
            _newKey.transform.SetParent(m_inventory.transform);
            m_inventorySlot.Add(_newKey);
            m_bIsFull.Add(true);
            if(_keyType == PickupObject.EPickups.BlueKey) m_blueInst = true;
            if(_keyType == PickupObject.EPickups.IDCard) m_idInst = true;
        }
    }

    void RemoveKey(bool _hasKey, PickupObject.EPickups _keyType)
    {
        if (!_hasKey && SearchKeyInInventory(_keyType) != 99999)
        {
            int _index = SearchKeyInInventory(_keyType);
            GameObject toDelete = m_inventorySlot[_index];
            m_inventorySlot.RemoveAt(_index);
            m_bIsFull.RemoveAt(_index);
            Destroy(toDelete);

            if (_keyType == PickupObject.EPickups.BlueKey)
            {
                Debug.Log("Removed: key card");
                m_blueInst = false;
            }
            if (_keyType == PickupObject.EPickups.IDCard)
            {
                Debug.Log("Removed: ID card");
                m_idInst = false;
            }

        }
    }

    public int SearchKeyInInventory(PickupObject.EPickups _pickup)
    {
        if(m_inventorySlot != null)
        {
            for (int i = 0; i < m_inventorySlot.Count-1; ++i)
            {
                Debug.Log("Bool size: " + (m_bIsFull.Count) + " num: " + i + " BoolItem: " + m_bIsFull[i]);
                if (m_bIsFull[i])
                {
                    if (m_inventorySlot[i].GetComponent<PickupObject>().pickUpObject.pickupType == _pickup)
                    {
                        //Debug.Log("return: " + i + "Item: " + m_inventorySlot[i]);
                        return i;
                    }
                }
            }
        }
        return 99999; //key not found
    }
}
