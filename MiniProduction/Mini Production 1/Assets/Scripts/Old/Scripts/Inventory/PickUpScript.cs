using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EPickups
{
    ENONE,
    ECUBE,
    EBOTTLE,
    ECHICKEN,
    EBANANA,
    EEGG,
    ESTEAK,
    EKEY,
    EHAM,
    ESANDWITCH,
    EAPPLE,
}

public class PickUpScript : MonoBehaviour
{
    public float distanceInfront = 2f;
    
    GameObject onCameraCube;
    GameObject onCameraBottle;
    GameObject onCameraChicken;
    GameObject onCameraBanana;
    GameObject onCameraEgg;
    GameObject onCameraSteak;
    GameObject onCameraKey;
    GameObject onCameraHam;
    GameObject onCameraSandwitch;
    GameObject onCameraApple;

    bool holdingSomething;
    bool m_wallInfront;
    private GameObject test;

    EPickups holding;

    void Start()
    {
        holdingSomething = false;
        
        //Edit this later so that all pick up items are placed here
        onCameraCube = GameObject.FindGameObjectWithTag("PickedUpCube");
        if (null != onCameraCube)
        {
            onCameraCube.SetActive(false);
        }

        onCameraBottle = GameObject.FindGameObjectWithTag("PickedUpBottle");
        if (null != onCameraCube)
        {
            onCameraBottle.SetActive(false);
        }

        onCameraChicken = GameObject.FindGameObjectWithTag("PickedUpChicken");
        if (null != onCameraChicken)
        {
            onCameraChicken.SetActive(false);
        }

        onCameraBanana = GameObject.FindGameObjectWithTag("PickedUpBanana");
        if (null != onCameraBanana)
        {
            onCameraBanana.SetActive(false);
        }

        onCameraEgg = GameObject.FindGameObjectWithTag("PickedUpEgg");
        if (null != onCameraEgg)
        {
            onCameraEgg.SetActive(false);
        }

        onCameraSteak = GameObject.FindGameObjectWithTag("PickedUpSteak");
        if (null != onCameraSteak)
        {
            onCameraSteak.SetActive(false);
        }

        onCameraKey = GameObject.FindGameObjectWithTag("PickedUpKey");
        if (null != onCameraKey)
        {
            onCameraKey.SetActive(false);
        }

        onCameraHam = GameObject.FindGameObjectWithTag("PickedUpHam");
        if (null != onCameraHam)
        {
            onCameraHam.SetActive(false);
        }

        onCameraSandwitch = GameObject.FindGameObjectWithTag("PickedUpSandwitch");
        if (null != onCameraSandwitch)
        {
            onCameraSandwitch.SetActive(false);
        }

        onCameraApple = GameObject.FindGameObjectWithTag("PickedUpApple");
        if (null != onCameraApple)
        {
            onCameraApple.SetActive(false);
        }

        holding = EPickups.ENONE;
    }

	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!holdingSomething && null != test)
            {
                if(test.tag == "PickUpChicken")
                {
                    if (null != onCameraChicken)
                    {
                        holding = EPickups.ECHICKEN;
                        
                        onCameraChicken.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpBottle")
                {
                    if (null != onCameraBottle)
                    {
                        holding = EPickups.EBOTTLE;

                        onCameraBottle.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpBanana")
                {
                    if (null != onCameraBanana)
                    {
                        holding = EPickups.EBANANA;

                        onCameraBanana.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpEgg")
                {
                    if (null != onCameraEgg)
                    {
                        holding = EPickups.EEGG;

                        onCameraEgg.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpSteak")
                {
                    if (null != onCameraSteak)
                    {
                        holding = EPickups.ESTEAK;

                        onCameraSteak.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpKey")
                {
                    if (null != onCameraKey)
                    {
                        holding = EPickups.EKEY;

                        onCameraKey.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpHam")
                {
                    if (null != onCameraHam)
                    {
                        holding = EPickups.EHAM;

                        onCameraHam.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpSandwitch")
                {
                    if (null != onCameraSandwitch)
                    {
                        holding = EPickups.ESANDWITCH;

                        onCameraSandwitch.SetActive(true);
                    }
                }
                else if (test.tag == "PickUpApple")
                {
                    if (null != onCameraApple)
                    {
                        holding = EPickups.EAPPLE;

                        onCameraApple.SetActive(true);
                    }
                }
                else if(test.tag == "PickUpCube")
                {
                    if (null != onCameraCube)
                    {
                        holding = EPickups.ECUBE;
                        
                        onCameraCube.SetActive(true);
                    }
                }
                test.gameObject.SetActive(false);
                holdingSomething = true;
            }
            else
            {
                if (!m_wallInfront)
                {

                    switch (holding)
                    {
                        case EPickups.ECUBE:
                            {
                                if (null != onCameraCube)
                                {
                                    onCameraCube.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.EBOTTLE:
                            {
                                if (null != onCameraBottle)
                                {
                                    onCameraBottle.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.ECHICKEN:
                            {
                                if (null != onCameraChicken)
                                {
                                    onCameraChicken.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.EBANANA:
                            {
                                if (null != onCameraBanana)
                                {
                                    onCameraBanana.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.EEGG:
                            {
                                if (null != onCameraEgg)
                                {
                                    onCameraEgg.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.ESTEAK:
                            {
                                if (null != onCameraSteak)
                                {
                                    onCameraSteak.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.EKEY:
                            {
                                if (null != onCameraKey)
                                {
                                    onCameraKey.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.EHAM:
                            {
                                if (null != onCameraHam)
                                {
                                    onCameraHam.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.ESANDWITCH:
                            {
                                if (null != onCameraSandwitch)
                                {
                                    onCameraSandwitch.SetActive(false);
                                }
                                break;
                            }
                        case EPickups.EAPPLE:
                            {
                                if (null != onCameraApple)
                                {
                                    onCameraApple.SetActive(false);
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }

                if (holding != EPickups.ENONE)
                {
                    test.gameObject.SetActive(true);
                    
                    test.transform.position = transform.position + (transform.forward * distanceInfront);
                    test.transform.rotation = transform.rotation;

                    holding = EPickups.ENONE;
                    holdingSomething = false;
                    test = null;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TutorialWall")
        {
            m_wallInfront = true;
        }

        if (!holdingSomething)
        {
            if (other.tag == "PickUpKey")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpCube")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpBottle")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpChicken")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpBanana")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpEgg")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpSteak")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpHam")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpSandwitch")
            {
                test = other.gameObject;
            }
            else if (other.tag == "PickUpApple")
            {
                test = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TutorialWall")
        {
            m_wallInfront = false;
        }

        // Somehow stop players from picking up if out of range of item
        if (!holdingSomething && null != test)
        {
            if (other.tag == test.tag)
            {
                test = null;
            }
        }
    }
}

