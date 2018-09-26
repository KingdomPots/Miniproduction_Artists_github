using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {
	public enum EPickups
    {
        YellowKey,
        BlueKey,
        GreenKey,
        IDCard,
        NONE
    }

    [System.Serializable]
    public struct EPickUpStats
    {
        public EPickups pickupType;
        public bool unlocksDoor1;
    }

    //public EPickups pickupType;
    public EPickUpStats pickUpObject;

    
}
