using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCheck : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioClip correctSound;
    public AudioClip doorBreak;
    public GameObject BarTime;
    public GameObject SCUi;
    public Transform bar;
    public Sprite[] arrow = new Sprite[4];
    public Sprite minus;
    public Sprite correct;
    public GameObject[] arrows = new GameObject[4];
    public GameObject alertBar;
    public GameObject door;
    Animator openDoor;

    bool Complete = false;
    int lastStage = 1;
    string[] checkAns = new string[4];
    int[] rand = new int[4];
    bool minusCheck = false;
    bool FinishStage = false;
    bool inArea = false;
    bool checkImg = false;
    float time = 0.0f;
    float Keeptime = 0.0f;
    int stg = 0;
    float barStage = 0.0f;
    bool check0 = true;
    bool check1 = false;
    bool check2 = false;
    bool check3 = false;
    bool check4 = false;
    AudioSource audioSource;
    AudioSource CorrectSource;
    // Start is called before the first frame update
    void Start()
    {
        openDoor = door.gameObject.GetComponent<Animator>();
        CorrectSource = gameObject.AddComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            if (Input.GetMouseButtonDown(0) && Complete == false)
            {
                GameObject.Find("SM_Chr_Farmer_Male_Old_01 (2)").GetComponent<PlayerController>().disableCom();
                stg = lastStage;
                SCUi.SetActive(true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (lastStage == 2)
                {
                    barStage = 0.25f;
                }
                else if (lastStage == 3)
                {
                    barStage = 0.75f;
                }
                else
                {
                    barStage = 0.0f;
                }
                
                resetStage(lastStage, barStage);
                GameObject.Find("SM_Chr_Farmer_Male_Old_01 (2)").GetComponent<PlayerController>().enableCom();
                SCUi.SetActive(false);
            }

            if (stg==1)
            {
                if(time <= 5 && FinishStage == false)
                {
                    time = time + Time.deltaTime;
                    Keeptime = (time) * 25.0f / 5.0f;
                    bar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                }
                else if(time > 5 && FinishStage == false)
                {
                    FinishStage = true;
                    barStage = Keeptime/100.0f;
                    Keeptime = 0;
                    time = 0; 
                }
                if(stg==1 && FinishStage)
                {
                    //alertBar.SetActive(true);
                    time = time + Time.deltaTime;
                    if (!checkImg)
                    {
                        for(int i = 0; i < arrows.Length; i++)
                        {
                            rand[i] = UnityEngine.Random.Range(0, 3);
                            arrows[i].GetComponent<Image>().sprite = arrow[rand[i]];
                            arrows[i].SetActive(true);
                            switch (rand[i])
                            {
                                case 0:
                                    checkAns[i] = "W";
                                    break;
                                case 1:
                                    checkAns[i] = "A";
                                    break;
                                case 2:
                                    checkAns[i] = "S";
                                    break;
                                case 3:
                                    checkAns[i] = "D";
                                    break;
                            }
                        }
                        checkImg = true;
                    }
                    if(time < 3)
                    {
                        
                        Keeptime = 100 - (time * 100.0f / 3.0f);
                        alertBar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                    }
                    if(time >= 3)
                    {
                        Keeptime = 100 - ((time-3) * 100.0f / 3.0f);
                        alertBar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                        if(minusCheck == false)
                        {
                            for (int i = 0; i < arrows.Length; i++)
                            {
                                rand[i] = UnityEngine.Random.Range(0, 3);
                                arrows[i].GetComponent<Image>().sprite = minus;
                            }
                            minusCheck = true;
                        }
                        
                           
                        foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
{
                            if (Input.GetKeyUp(kcode))
                            {
                                if(check0 == true)
                                {
                                    if (kcode.ToString() == checkAns[0])
                                    {
                                        arrows[0].GetComponent<Image>().sprite = correct;
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        check0 = false;
                                        check1 = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                                else if (check1 == true)
                                {
                                    if (kcode.ToString() == checkAns[1])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[1].GetComponent<Image>().sprite = correct;
                                        check1 = false;
                                        check2 = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                                else if (check2 == true)
                                {
                                    if (kcode.ToString() == checkAns[2])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[2].GetComponent<Image>().sprite = correct;
                                        check2 = false;
                                        check3 = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                                else if (check3 == true)
                                {
                                    if (kcode.ToString() == checkAns[3])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[3].GetComponent<Image>().sprite = correct;
                                        check3 = false;
                                        check4 = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                            }
                            }
                    }
                    if(check4 == true)
                    {
                        resetStage(2,0.25f);
                    }
                    if(time >= 6)
                    {
                        resetStage(1,0.0f);
                    }
                }
            }
            else if (stg == 2 )
            {
                lastStage = 2;
                if (time <= 10 && FinishStage == false)
                {
                    time = time + Time.deltaTime;
                    Keeptime = (time) * 50.0f / 10.0f;
                    bar.transform.localScale = new Vector3((Keeptime / 100.0f)+barStage, 1.0f, 1.0f);
                }
                else if (time > 10 && FinishStage == false)
                {
                    FinishStage = true;
                    barStage = (Keeptime / 100.0f)+barStage;
                    Keeptime = 0;
                    time = 0;
                }
                if (stg == 2 && FinishStage)
                {
                    //alertBar.SetActive(true);
                    time = time + Time.deltaTime;
                    if (!checkImg)
                    {
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            rand[i] = UnityEngine.Random.Range(0, 3);
                            arrows[i].GetComponent<Image>().sprite = arrow[rand[i]];
                            arrows[i].SetActive(true);
                            switch (rand[i])
                            {
                                case 0:
                                    checkAns[i] = "W";
                                    break;
                                case 1:
                                    checkAns[i] = "A";
                                    break;
                                case 2:
                                    checkAns[i] = "S";
                                    break;
                                case 3:
                                    checkAns[i] = "D";
                                    break;
                            }
                        }
                        checkImg = true;
                        
                    }
                    if (time < 3)
                    {
                        Keeptime = 100 - (time * 100.0f / 3.0f);
                        alertBar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                    }
                    if (time >= 3)
                    {
                        Keeptime = 100 - ((time - 3) * 100.0f / 3.0f);
                        alertBar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                        if (minusCheck == false)
                        {
                            for (int i = 0; i < arrows.Length; i++)
                            {
                                rand[i] = UnityEngine.Random.Range(0, 3);
                                arrows[i].GetComponent<Image>().sprite = minus;
                            }
                            minusCheck = true;
                        }


                        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKeyUp(kcode))
                            {
                                if (check0 == true)
                                {
                                    if (kcode.ToString() == checkAns[0])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[0].GetComponent<Image>().sprite = correct;
                                        check0 = false;
                                        check1 = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                                else if (check1 == true)
                                {
                                    if (kcode.ToString() == checkAns[1])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[1].GetComponent<Image>().sprite = correct;
                                        check1 = false;
                                        check2 = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                                else if (check2 == true)
                                {
                                    if (kcode.ToString() == checkAns[2])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[2].GetComponent<Image>().sprite = correct;
                                        check2 = false;
                                        check3 = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                                else if (check3 == true)
                                {
                                    if (kcode.ToString() == checkAns[3])
                                    {
                                        arrows[3].GetComponent<Image>().sprite = correct;
                                        check3 = false;
                                        check4 = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                            }
                        }
                    }
                    if (check4 == true)
                    {
                        resetStage(3,0.75f);
                    }
                    if (time >= 6)
                    {
                        resetStage(2,0.25f);
                    }
                }
            }
            else if (stg == 3)
            {
                lastStage = 3;
                if (time <= 15 && FinishStage == false)
                {
                    time = time + Time.deltaTime;
                    Keeptime = (time) * 25.0f / 15.0f;
                    bar.transform.localScale = new Vector3((Keeptime / 100.0f) + barStage, 1.0f, 1.0f);
                }
                else if (time > 10 && FinishStage == false)
                {
                    FinishStage = true;
                    barStage = Keeptime / 100.0f;
                    Keeptime = 0;
                    time = 0;
                }
                if (stg == 3 && FinishStage)
                {
                    //alertBar.SetActive(true);
                    time = time + Time.deltaTime;
                    if (!checkImg)
                    {
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            rand[i] = UnityEngine.Random.Range(0, 3);
                            arrows[i].GetComponent<Image>().sprite = arrow[rand[i]];
                            arrows[i].SetActive(true);
                            switch (rand[i])
                            {
                                case 0:
                                    checkAns[i] = "W";
                                    break;
                                case 1:
                                    checkAns[i] = "A";
                                    break;
                                case 2:
                                    checkAns[i] = "S";
                                    break;
                                case 3:
                                    checkAns[i] = "D";
                                    break;
                            }
                        }
                        checkImg = true;

                    }
                    if (time < 3)
                    {
                        Keeptime = 100 - (time * 100.0f / 3.0f);
                        alertBar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                    }
                    if (time >= 3)
                    {
                        Keeptime = 100 - ((time - 3) * 100.0f / 3.0f);
                        alertBar.transform.localScale = new Vector3(Keeptime / 100.0f, 1.0f, 1.0f);
                        if (minusCheck == false)
                        {
                            for (int i = 0; i < arrows.Length; i++)
                            {
                                rand[i] = UnityEngine.Random.Range(0, 3);
                                arrows[i].GetComponent<Image>().sprite = minus;
                            }
                            minusCheck = true;
                        }


                        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKeyUp(kcode))
                            {
                                if (check0 == true)
                                {
                                    if (kcode.ToString() == checkAns[0])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[0].GetComponent<Image>().sprite = correct;
                                        check0 = false;
                                        check1 = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                                else if (check1 == true)
                                {
                                    if (kcode.ToString() == checkAns[1])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[1].GetComponent<Image>().sprite = correct;
                                        check1 = false;
                                        check2 = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                                else if (check2 == true)
                                {
                                    if (kcode.ToString() == checkAns[2])
                                    {
                                        CorrectSource.clip = correctSound;
                                        CorrectSource.Play();
                                        arrows[2].GetComponent<Image>().sprite = correct;
                                        check2 = false;
                                        check3 = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                                else if (check3 == true)
                                {
                                    if (kcode.ToString() == checkAns[3])
                                    {
                                        CorrectSource.clip = correctSound;
                                        //CorrectSource.Play();
                                        audioSource.clip = doorBreak;
                                        audioSource.Play();
                                        arrows[3].GetComponent<Image>().sprite = correct;
                                        check3 = false;
                                        check4 = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                            }
                        }
                    }
                    if (check4 == true )
                    {
                        audioSource.clip = doorBreak;
                        audioSource.Play();
                        openDoor.enabled = true;
                        Complete = true;
                        SCUi.SetActive(false);
                        openDoor.enabled = true;
                       
                    }
                    if (time >= 6)
                    {
                        resetStage(3,0.75f);
                    }
                }
            } 
        }
        else
        {
            SCUi.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        audioSource.clip = audioClip;
        audioSource.Play();
        inArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inArea = false;
    }

    void resetStage(int stage,float bar)
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
        alertBar.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        checkImg = false;
        minusCheck = false;
        FinishStage = false;
        stg = stage;
        lastStage = stage;
        time = 0.0f;
        Keeptime = 0.0f;
        barStage = bar;
        check0 = true;
        check1 = false;
        check2 = false;
        check3 = false;
        check4 = false;
    }

}
