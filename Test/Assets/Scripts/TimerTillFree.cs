using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTillFree : MonoBehaviour
{
    public int OverallTime = 300; //5 Min
    public int monsterDefaultTime = 60;
    public int monsterHungerChicken = 50;
    public int endGameTimeToEscape = 60;
    public TextMeshProUGUI mainTimer;
    public TextMeshProUGUI monsterTalking;
    public TextMeshProUGUI notesAmountText;
    public TextMeshProUGUI monsterHungerVal;

    public AudioSource eating;
    public AudioSource music;

    public GameObject tutorialWalls;

    private float timer;
    private float timerMonsterHunger;

    private int nextTalkTime;
    private int timeTillEscape;
    private int timeTillMonsterEatsYou;
    private int timeVeryWell;
    private int timeOtherwise;
    private int timeOtherwiseKey;
    private int timeStartFin;

    private int timeLeaving;

    private bool isDeadlineSoon;
    private bool tutorial;
    private bool endGame;

    private GameObject directionalLight;
    private GameObject[] houseLights;
    private Color monsterLightColor;
    private GameObject key;

    private int m_iCurrentText = 0;


    // Use this for initialization
    void Start()
    {
        timeTillEscape = OverallTime;
        timeTillMonsterEatsYou = monsterDefaultTime;
        timer = Time.time + 10000;
        timerMonsterHunger = Time.time + 10000;

        mainTimer.text = "";
        monsterTalking.text = "";
        notesAmountText.text = "";
        monsterHungerVal.text = "";
        tutorial = true;

        directionalLight = GameObject.FindGameObjectWithTag("MainLight");
        if (null == directionalLight)
        {
            Debug.Log("Timer can't find main directional light");
        }

        houseLights = GameObject.FindGameObjectsWithTag("MonsterHouseLights");
        monsterLightColor = new Color32(255, 92, 69, 255);

        endGame = false;

        key = GameObject.FindGameObjectWithTag("PickUpKey");
        key.SetActive(false);
    }

    void Update()
    {
        if (!tutorial)
        {
            mainTimer.text = "Assignment Due In: " + (timeTillEscape + 60).ToString() + "s";
            notesAmountText.text = GameManager.GetNoteCount().ToString();
            monsterHungerVal.text = "Monster's Hunger Level: " + (timeTillMonsterEatsYou).ToString() + "s";
            for (int i = 0; i < houseLights.Length; ++i)
            {
                Light light = houseLights[i].GetComponent<Light>();
                light.color = monsterLightColor;
            }
        }

        if (Time.time > timer)
        {
            //Time Up
            // GameManager.GameOver(true);
            endGame = true;
        }
        else if (Time.time > timerMonsterHunger)
        {
            GameManager.GameOver(false);
        }
    }

    public void IncreaseHungerTimeChicken()
    {
        if (!tutorial)
        {
            if (!endGame)
            {
                eating.Play();
                timerMonsterHunger += monsterHungerChicken;
                timeTillMonsterEatsYou += monsterHungerChicken;
                timeTillMonsterEatsYou = Mathf.Min(timeTillMonsterEatsYou, 100);
            }
        }
        else
        {
            music.Play();

            eating.Play();
            //Destroy(tutorialWalls.gameObject);
            tutorialWalls.gameObject.SetActive(false);
            tutorial = false;
            monsterTalking.text = "SO YOU WANT TO RESEARCH ME...";
            timeVeryWell = timeTillMonsterEatsYou - 3;
            nextTalkTime = timeTillMonsterEatsYou - 3;
            InvokeRepeating("DecreaseTimeBy1", 1f, 1f);  //1s delay, repeat every 1s

            if (null != directionalLight)
            {
                Light overallLight = directionalLight.GetComponent<Light>();
                Color32 color = new Color32(92, 41, 26, 100);
                overallLight.color = color;
            }
            ChangeColor();

            timer = Time.time + OverallTime;
            timerMonsterHunger = Time.time + monsterDefaultTime;
        }
    }
    public void IncreaseHungerTimeFood(int amount)
    {
        if (!endGame)
        {
            eating.Play();
            timerMonsterHunger += amount;
            timeTillMonsterEatsYou += amount;
            timeTillMonsterEatsYou = Mathf.Min(timeTillMonsterEatsYou, 100);
        }
    }

    private void DecreaseTimeBy1()
    {
        timeTillEscape -= 1;
        timeTillMonsterEatsYou -= 1;

        if(nextTalkTime == timeTillMonsterEatsYou && m_iCurrentText < 3)
        {
            Speak(m_iCurrentText);
            m_iCurrentText += 1;
            nextTalkTime -= 2;
        }

        if (timeTillEscape == 0)
        {
            monsterTalking.text = "Take this key and LEAVE!";
            Invoke("ClearMonsterText", 2f);
            timeTillMonsterEatsYou = 60;
            timer = Time.time + 60;
            timerMonsterHunger = Time.time + 60;
            key.SetActive(true);
            monsterLightColor = new Color32(255, 255, 255, 255);
            timeLeaving = timeTillMonsterEatsYou - 3;
            isDeadlineSoon = true;
            Light overallLight = directionalLight.GetComponent<Light>();
            overallLight.color = new Color32(255, 224, 214, 255);
            endGame = true;
        }

        if ((20 == timeTillMonsterEatsYou || 10 == timeTillMonsterEatsYou || 5 == timeTillMonsterEatsYou) && !isDeadlineSoon)
        {
            Speak(timeTillMonsterEatsYou);
        }
        else if (timeTillMonsterEatsYou == 2 && !isDeadlineSoon)
        {
            monsterTalking.text = "AND THEREFORE YOU SHALL BECOME MY FOOD";
            Invoke("ClearMonsterText", 2f);
        }

        if (timeLeaving == timeTillMonsterEatsYou && isDeadlineSoon)
        {
            monsterTalking.text = "...UNLESS YOU WANT TO STAY";
            Invoke("ClearMonsterText", 2f);
        }
        else if (10 == timeTillMonsterEatsYou && isDeadlineSoon)
        {
            monsterTalking.text = "OH? SOMEONE DOESNT WANT TO LEAVE?";
            Invoke("ClearMonsterText", 2f);
        }
        else if (3 == timeTillMonsterEatsYou && isDeadlineSoon)
        {
            monsterTalking.text = "YOU WILL NEVER LEAVE AGAIN..\nM Y  F R I E N D";
            Invoke("ClearMonsterText", 2f);
        }

        if (timeTillEscape == -60)
        {
            GameManager.GameOver(false);
        }
        ChangeColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.GameOver(true);
        }
    }

    private void ChangeColor()
    {
        if (!endGame)
        {
            float rTemp = (timeTillMonsterEatsYou / 100f) * 255f;
            rTemp = Mathf.RoundToInt(rTemp);
            rTemp = Mathf.Clamp(rTemp, 0, 255);
            float gTemp = (timeTillMonsterEatsYou / 100f) * 92f;
            gTemp = Mathf.RoundToInt(gTemp);
            gTemp = Mathf.Clamp(gTemp, 0, 147);
            float bTemp = (timeTillMonsterEatsYou / 100f) * 69f;
            bTemp = Mathf.RoundToInt(bTemp);
            bTemp = Mathf.Clamp(bTemp, 0, 131);

            monsterLightColor = new Color32((byte)rTemp, (byte)gTemp, (byte)bTemp, 255);
            //Debug.Log("RGB(" + rTemp + ", " + gTemp + ", " + bTemp + ")");

            float pitchToPlay = (timeTillMonsterEatsYou / 100f) * 0.6f;
            music.pitch = 1.6f - pitchToPlay;
        }
    }

    private void ClearMonsterText()
    {
        monsterTalking.text = "";
    }

    private void Speak(int _TextToSay)
    {
        switch (_TextToSay)
        {
            case 0:
                {
                    monsterTalking.text = "VERY WELL, BUT YOU MUST FEED ME";
                    break;
                }
            case 1:
                {
                    monsterTalking.text = "OR I WILL EAT YOU";
                    break;
                }
            case 2:
                {
                    monsterTalking.text = "I WILL GIVE YOU A KEY WHEN YOUR DEADLINE IS CLOSE";
                    Invoke("ClearMonsterText", 2f);
                    break;
                }
            case 5:
                {
                    monsterTalking.text = "YOU'RE LOOKING VERY TASTY";
                    Invoke("ClearMonsterText", 2f);
                    break;
                }
            case 10:
                {
                    monsterTalking.text = "MY PATIENCE CAN'T LAST FOREVER";
                    Invoke("ClearMonsterText", 2f);
                    break;
                }
            case 20:
                {
                    monsterTalking.text = "SO HUNGRY...\nFEED ME";
                    Invoke("ClearMonsterText", 2f);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}
