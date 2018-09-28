using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    static public bool GetAxisOnce(ref bool _pressedAlready, string _name)
    {
        bool current = Input.GetAxis(_name) > 0;

        if (current && _pressedAlready)
        {
            return false;
        }
        _pressedAlready = current;

        return current;
    }
}
