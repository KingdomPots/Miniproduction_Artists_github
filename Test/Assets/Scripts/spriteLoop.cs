using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteLoop : MonoBehaviour
{
    public Texture texture1;
    public Texture texture2;
    public Texture texture3;
    public Texture texture4;
    public int TicksPerSecond = 30;

    private Renderer rend;
    private int currentCycle;
    private float _t;

    // Use this for initialization
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        if (rend == null)
        {
            Debug.Log("Can't find renderer");
        }

        currentCycle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dur = 1f / this.TicksPerSecond;
        _t += Time.deltaTime;
        int cnt = 4;
        while (_t > dur && cnt > 0)
        {
            _t -= dur;
            cnt--;

            switch(currentCycle)
            {
                case 0:
                    {
                        rend.material.mainTexture = texture2;
                        currentCycle += 1;
                        break;
                    }
                case 1:
                    {
                        rend.material.mainTexture = texture3;
                        currentCycle += 1;
                        break;
                    }
                case 2:
                    {
                        rend.material.mainTexture = texture4;
                        currentCycle += 1;
                        break;
                    }
                case 3:
                    {
                        rend.material.mainTexture = texture3;
                        currentCycle += 1;
                        break;
                    }
                case 4:
                    {
                        rend.material.mainTexture = texture2;
                        currentCycle += 1;
                        break;
                    }
                default:
                    rend.material.mainTexture = texture1;
                    currentCycle = 0;
                    break;
            }
        }
    }
}
