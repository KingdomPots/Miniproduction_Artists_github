using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCasting : MonoBehaviour {

    public GameObject m_keyObtainedParticle;
    public Image CanPickUp;
    public GameObject m_SpawnEachInteraction;


    public float m_fRayDistance = 3;
    bool m_bPressedAlready = false;
    bool m_bActionDone = false;

    private GameObject m_Player;
    private RaycastHit m_objectHit;
    //private Inventory m_inventory;

    [Header("Audio")]
    public AudioSource m_keyObtainedAudio;
    public AudioSource m_unlockAudio;

    //public EventManager m_eventManager;

    // Use this for initialization
    void Start () {
        m_keyObtainedAudio.Stop();
        m_unlockAudio.Stop();

        CanPickUp.gameObject.SetActive(false);

        m_Player = GameObject.FindWithTag("Player");
        //m_inventory = m_Player.GetComponent<Inventory>();
        //m_eventManager = m_eventManager.GetComponent<EventManager>();
    }

    bool GetAxisOnce(string _name)
    {
        bool current = Input.GetAxis(_name) > 0;

        if (current && m_bPressedAlready)
        {
            return false;
        }
        m_bPressedAlready = current;

        return current;
    }

    // Update is called once per frame
    void Update () {
        //Draw a debug ray that displays in the editor
        Debug.DrawRay(this.transform.position, this.transform.forward * m_fRayDistance, Color.magenta);

        //Get raycast of object the player 
        if (Physics.Raycast(this.transform.position, this.transform.forward, out m_objectHit, m_fRayDistance))
        {
            if(m_objectHit.collider.CompareTag("Pickup") || m_objectHit.collider.CompareTag("Lock") ||
                m_objectHit.collider.CompareTag("Lever"))
            {
                CanPickUp.gameObject.SetActive(true);
            }
            else
            {
                CanPickUp.gameObject.SetActive(false);
            }
            
            if (GetAxisOnce("Pickup"))
            {
                if (m_objectHit.collider.CompareTag("Lever"))
                {
                    EventManager.m_finalDoorOpen = true;
                }
                else
                {
                    if (m_objectHit.collider.CompareTag("Pickup"))
                    {
                        AddItemToInventory(PickupObject.EPickups.BlueKey);
                        AddItemToInventory(PickupObject.EPickups.IDCard);
                        AddItemToInventory(PickupObject.EPickups.GreenKey);
                        AddItemToInventory(PickupObject.EPickups.YellowKey);
                    }
                    if (m_objectHit.collider.CompareTag("Lock"))
                    {
                        UseOnLock(LockManager.ELocks.BlueLock);
                        UseOnLock(LockManager.ELocks.IDSwipe);
                    }

                    if (m_bActionDone)
                    {
                        if (m_objectHit.collider.tag == "Pickup")
                        {
                            m_keyObtainedAudio.Play();
                        }

                        if (m_objectHit.collider.tag == "Lock")
                        {
                            m_unlockAudio.Play();
                        }

                        m_bActionDone = false;
                        GameObject bKeyParticle = (GameObject)Instantiate(m_keyObtainedParticle, m_objectHit.transform.position, m_objectHit.transform.rotation);
                        bKeyParticle.GetComponent<ParticleSystem>().Play();
                        Destroy(bKeyParticle, 2.0f);

                        GameObject.FindGameObjectWithTag("SpawnMore").GetComponent<SpawnMore>().SpawnMoreOfThisType(m_SpawnEachInteraction);
                    }
                }
            }
        }
	}

    void AddItemToInventory(PickupObject.EPickups _pickupType)
    {
        if (m_objectHit.collider.gameObject.GetComponent<PickupObject>().pickUpObject.pickupType == _pickupType)
        {
            SetInventoryStatus(_pickupType, true);
            m_bActionDone = true;
            Destroy(m_objectHit.collider.gameObject);
        }
    }

    void UseOnLock(LockManager.ELocks _pickupType)
    {
        if (m_objectHit.collider.gameObject.GetComponent<LockManager>().lockType == _pickupType)
        {
            PickupObject.EPickups type = GetInventoryType(_pickupType);
            if (GetInventoryStatus(type))
            {
                if(type == PickupObject.EPickups.BlueKey)
                {
                    EventManager.m_gateOpen = true;
                    GameObject.FindGameObjectWithTag("Gate").GetComponent<Gate>().OpenGate();
					SetInventoryStatus(type, false);
					m_bActionDone = true;
					Destroy(m_objectHit.collider.gameObject);
                }
                if (type == PickupObject.EPickups.IDCard)
                {
                    EventManager.m_atticOpen = true;
					SetInventoryStatus(type, false);
					m_bActionDone = true;
                }
                
            }
        }
    }

    void SetInventoryStatus(PickupObject.EPickups _pickupType, bool _itemNowExists)
    {
        switch(_pickupType)
        {
            case PickupObject.EPickups.BlueKey:
            {
                m_Player.GetComponent<Inventory>().hasBlueKey = _itemNowExists;
                break;
            }
            case PickupObject.EPickups.IDCard:
            {
                m_Player.GetComponent<Inventory>().hasID = _itemNowExists;
                break;
            }
            case PickupObject.EPickups.GreenKey:
            {
                m_Player.GetComponent<Inventory>().hasGreenKey = _itemNowExists;
                break;
            }
            case PickupObject.EPickups.YellowKey:
            {
                m_Player.GetComponent<Inventory>().hasYellowKey = _itemNowExists;
                break;
            }
        }
    }

    PickupObject.EPickups GetInventoryType(LockManager.ELocks _lock)
    {
        PickupObject.EPickups temp = PickupObject.EPickups.NONE;

        switch (_lock)
        {
            case LockManager.ELocks.BlueLock:
            {
                temp = PickupObject.EPickups.BlueKey;
                break;
            }
            case LockManager.ELocks.IDSwipe:
                {
                    temp = PickupObject.EPickups.IDCard;
                    break;
                }
            case LockManager.ELocks.GreenLock:
                {
                    temp = PickupObject.EPickups.GreenKey;
                    break;
                }
            case LockManager.ELocks.YellowLock:
                {
                    temp = PickupObject.EPickups.YellowKey;
                    break;
                }
        }
        return temp;
    }

    bool GetInventoryStatus(PickupObject.EPickups _pickupType)
    {
        bool temp = false;
        switch (_pickupType)
        {
            case PickupObject.EPickups.BlueKey:
            {
                temp = m_Player.GetComponent<Inventory>().hasBlueKey;
                break;
            }
            case PickupObject.EPickups.IDCard:
            {
                temp = m_Player.GetComponent<Inventory>().hasID;
                break;
            }
            case PickupObject.EPickups.GreenKey:
            {
                temp = m_Player.GetComponent<Inventory>().hasGreenKey;
                break;
            }
            case PickupObject.EPickups.YellowKey:
            {
                temp = m_Player.GetComponent<Inventory>().hasYellowKey;
                break;
            }
        }
        return temp;
    }
}
