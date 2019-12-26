using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCheckNew : MonoBehaviour
{
    public GameObject Canvas_SkillCkeck;
    public GameObject[] arrows;
    public GameObject Cage_Door;
    public GameObject particle;

    public AudioClip Correct;
    public AudioClip InArea;
    public AudioClip DoorBreak;

    AudioSource MainSource;
    Animator OpenD;

    public Transform MainBar;
    public Transform AlertBar;

    bool Area = false;
    bool CompleteAll = false;
    bool FinishStage = false;
    bool CheckImg = false;
    bool MinusCheck = false;
    bool[] check = { true, false, false, false, false };

    float KeepTime = 0.0f;
    float time = 0.0f;
    float BarStartStage = 0.0f;

    int CurrentStage = 1;
    int[] rand = new int[4];

    public Sprite Minus_s;
    public Sprite Correct_s;
    public Sprite[] arrow;

    bool checktest = true;

    string[] CheckAns = new string[4];


    // Start is called before the first frame update
    void Start()
    {
       // MainSource = gameObject.AddComponent<AudioSource>();
        OpenD = Cage_Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Area)
        {
            if (Input.GetMouseButtonDown(0) && CompleteAll == false)
            {
                //GameObject.Find("Maingate").GetComponent<MainGate>().addCompleted();
                if (CurrentStage == 2)
                {
                    BarStartStage = 0.25f;
                }
                else if (CurrentStage == 3)
                {
                    BarStartStage = 0.75f;
                }
                else
                {
                    BarStartStage = 0.0f;
                }
                resetStage(CurrentStage, BarStartStage);
                Canvas_SkillCkeck.SetActive(true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Canvas_SkillCkeck.SetActive(false);
            }

            if (CurrentStage == 1)
            {
                if (time <= 5 && FinishStage == false)
                {
                    time = time + Time.deltaTime;
                    KeepTime = (time) * 25.0f / 5.0f;
                    MainBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                }
                else if (time > 5 && FinishStage == false)
                {
                    FinishStage = true;
                    BarStartStage = KeepTime / 100.0f;
                    KeepTime = 0;
                    time = 0;
                }
                if (CurrentStage == 1 && FinishStage)
                {
                    time = time + Time.deltaTime;
                    if (!CheckImg)
                    {
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            rand[i] = UnityEngine.Random.Range(0, 3);
                            arrows[i].GetComponent<Image>().sprite = arrow[rand[i]];
                            arrows[i].SetActive(true);
                            switch (rand[i])
                            {
                                case 0:
                                    CheckAns[i] = "W";
                                    break;
                                case 1:
                                    CheckAns[i] = "A";
                                    break;
                                case 2:
                                    CheckAns[i] = "S";
                                    break;
                                case 3:
                                    CheckAns[i] = "D";
                                    break;
                            }
                        }
                        CheckImg = true;
                    }
                    if (time < 3)
                    {

                        KeepTime = 100 - (time * 100.0f / 3.0f);
                        AlertBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                    }
                    if (time >= 3)
                    {
                        KeepTime = 100 - ((time - 3) * 100.0f / 3.0f);
                        AlertBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                        if (MinusCheck == false)
                        {
                            for (int i = 0; i < arrows.Length; i++)
                            {
                                rand[i] = UnityEngine.Random.Range(0, 3);
                                arrows[i].GetComponent<Image>().sprite = Minus_s;
                            }
                            MinusCheck = true;
                        }


                        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKeyUp(kcode))
                            {
                                if (check[0] == true)
                                {
                                    if (kcode.ToString() == CheckAns[0])
                                    {
                                        arrows[0].GetComponent<Image>().sprite = Correct_s;
                                       // MainSource.clip = Correct;
                                       // MainSource.Play();
                                        check[0] = false;
                                        check[1] = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                                else if (check[1] == true)
                                {
                                    if (kcode.ToString() == CheckAns[1])
                                    {
                                      //  MainSource.clip = Correct;
                                       // MainSource.Play();
                                        arrows[1].GetComponent<Image>().sprite = Correct_s;
                                        check[1] = false;
                                        check[2] = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                                else if (check[2] == true)
                                {
                                    if (kcode.ToString() == CheckAns[2])
                                    {
                                      //  MainSource.clip = Correct;
                                      //  MainSource.Play();
                                        arrows[2].GetComponent<Image>().sprite = Correct_s;
                                        check[2] = false;
                                        check[3] = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                                else if (check[3] == true)
                                {
                                    if (kcode.ToString() == CheckAns[3])
                                    {
                                      //  MainSource.clip = Correct;
                                      //  MainSource.Play();
                                        arrows[3].GetComponent<Image>().sprite = Correct_s;
                                        check[3] = false;
                                        check[4] = true;
                                    }
                                    else
                                    {
                                        resetStage(1, 0.0f);
                                    }
                                }
                            }
                        }
                    }
                    if (check[4] == true && checktest)
                    {
                        
                        CurrentStage = 2;
                        resetStage(2, 0.25f);
                    }
                    if (time >= 6)
                    {
                        resetStage(1, 0.0f);
                    }
                }
            }
            else if (CurrentStage == 2)
            {
                if (time <= 10 && FinishStage == false)
                {
                    time = time + Time.deltaTime;
                    KeepTime = (time) * 50.0f / 10.0f;
                    MainBar.transform.localScale = new Vector3((KeepTime / 100.0f) + BarStartStage, 1.0f, 1.0f);
                }
                else if (time > 10 && FinishStage == false)
                {
                    FinishStage = true;
                    BarStartStage = (KeepTime / 100.0f) + BarStartStage;
                    KeepTime = 0;
                    time = 0;
                }
                if (CurrentStage == 2 && FinishStage)
                {
                    time = time + Time.deltaTime;
                    if (!CheckImg)
                    {
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            rand[i] = UnityEngine.Random.Range(0, 3);
                            arrows[i].GetComponent<Image>().sprite = arrow[rand[i]];
                            arrows[i].SetActive(true);
                            switch (rand[i])
                            {
                                case 0:
                                    CheckAns[i] = "W";
                                    break;
                                case 1:
                                    CheckAns[i] = "A";
                                    break;
                                case 2:
                                    CheckAns[i] = "S";
                                    break;
                                case 3:
                                    CheckAns[i] = "D";
                                    break;
                            }
                        }
                        CheckImg = true;
                    }
                    if (time < 3)
                    {

                        KeepTime = 100 - (time * 100.0f / 3.0f);
                        AlertBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                    }
                    if (time >= 3)
                    {
                        KeepTime = 100 - ((time - 3) * 100.0f / 3.0f);
                        AlertBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                        if (MinusCheck == false)
                        {
                            for (int i = 0; i < arrows.Length; i++)
                            {
                                rand[i] = UnityEngine.Random.Range(0, 3);
                                arrows[i].GetComponent<Image>().sprite = Minus_s;
                            }
                            MinusCheck = true;
                        }


                        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKeyUp(kcode))
                            {
                                if (check[0] == true)
                                {
                                    if (kcode.ToString() == CheckAns[0])
                                    {
                                        arrows[0].GetComponent<Image>().sprite = Correct_s;
                                       // MainSource.clip = Correct;
                                       // MainSource.Play();
                                        check[0] = false;
                                        check[1] = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                                else if (check[1] == true)
                                {
                                    if (kcode.ToString() == CheckAns[1])
                                    {
                                       // MainSource.clip = Correct;
                                       // MainSource.Play();
                                        arrows[1].GetComponent<Image>().sprite = Correct_s;
                                        check[1] = false;
                                        check[2] = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                                else if (check[2] == true)
                                {
                                    if (kcode.ToString() == CheckAns[2])
                                    {
                                       // MainSource.clip = Correct;
                                       // MainSource.Play();
                                        arrows[2].GetComponent<Image>().sprite = Correct_s;
                                        check[2] = false;
                                        check[3] = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                                else if (check[3] == true)
                                {
                                    if (kcode.ToString() == CheckAns[3])
                                    {
                                        //MainSource.clip = Correct;
                                       // MainSource.Play();
                                        arrows[3].GetComponent<Image>().sprite = Correct_s;
                                        check[3] = false;
                                        check[4] = true;
                                    }
                                    else
                                    {
                                        resetStage(2, 0.25f);
                                    }
                                }
                            }
                        }
                    }
                    if (check[4] == true)
                    {
                        CurrentStage = 3;
                        resetStage(3, 0.75f);
                    }
                    if (time >= 6)
                    {
                        resetStage(2, 0.25f);
                    }
                }
            }
            else if (CurrentStage == 3)
            {
                if (time <= 15 && FinishStage == false)
                {
                    time = time + Time.deltaTime;
                    KeepTime = (time) * 25.0f / 15.0f;
                    MainBar.transform.localScale = new Vector3((KeepTime / 100.0f) + BarStartStage, 1.0f, 1.0f);
                }
                else if (time > 15 && FinishStage == false)
                {
                    FinishStage = true;
                    BarStartStage = (KeepTime / 100.0f) + BarStartStage;
                    KeepTime = 0;
                    time = 0;
                }
                if (CurrentStage == 3 && FinishStage)
                {
                    time = time + Time.deltaTime;
                    if (!CheckImg)
                    {
                        for (int i = 0; i < arrows.Length; i++)
                        {
                            rand[i] = UnityEngine.Random.Range(0, 3);
                            arrows[i].GetComponent<Image>().sprite = arrow[rand[i]];
                            arrows[i].SetActive(true);
                            switch (rand[i])
                            {
                                case 0:
                                    CheckAns[i] = "W";
                                    break;
                                case 1:
                                    CheckAns[i] = "A";
                                    break;
                                case 2:
                                    CheckAns[i] = "S";
                                    break;
                                case 3:
                                    CheckAns[i] = "D";
                                    break;
                            }
                        }
                        CheckImg = true;
                    }
                    if (time < 3)
                    {

                        KeepTime = 100 - (time * 100.0f / 3.0f);
                        AlertBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                    }
                    if (time >= 3)
                    {
                        KeepTime = 100 - ((time - 3) * 100.0f / 3.0f);
                        AlertBar.transform.localScale = new Vector3(KeepTime / 100.0f, 1.0f, 1.0f);
                        if (MinusCheck == false)
                        {
                            for (int i = 0; i < arrows.Length; i++)
                            {
                                rand[i] = UnityEngine.Random.Range(0, 3);
                                arrows[i].GetComponent<Image>().sprite = Minus_s;
                            }
                            MinusCheck = true;
                        }


                        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKeyUp(kcode))
                            {
                                if (check[0] == true)
                                {
                                    if (kcode.ToString() == CheckAns[0])
                                    {
                                        arrows[0].GetComponent<Image>().sprite = Correct_s;
                                       // MainSource.clip = Correct;
                                       // MainSource.Play();
                                        check[0] = false;
                                        check[1] = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                                else if (check[1] == true)
                                {
                                    if (kcode.ToString() == CheckAns[1])
                                    {
                                       // MainSource.clip = Correct;
                                      //  MainSource.Play();
                                        arrows[1].GetComponent<Image>().sprite = Correct_s;
                                        check[1] = false;
                                        check[2] = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                                else if (check[2] == true)
                                {
                                    if (kcode.ToString() == CheckAns[2])
                                    {
                                       // MainSource.clip = Correct;
                                      //  MainSource.Play();
                                        arrows[2].GetComponent<Image>().sprite = Correct_s;
                                        check[2] = false;
                                        check[3] = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                                else if (check[3] == true)
                                {
                                    if (kcode.ToString() == CheckAns[3])
                                    {
                                      //  MainSource.clip = Correct;
                                      //  MainSource.Play();
                                        arrows[3].GetComponent<Image>().sprite = Correct_s;
                                        check[3] = false;
                                        check[4] = true;
                                    }
                                    else
                                    {
                                        resetStage(3, 0.75f);
                                    }
                                }
                            }
                        }
                    }
                    if (check[4] == true)
                    {
                        Destroy(particle);
                        OpenD.enabled = true;
                        GameObject.Find("Maingate").GetComponent<MainGate>().addCompleted();
                        CompleteAll = true;
                        Canvas_SkillCkeck.SetActive(false);
                        gameObject.GetComponent<SkillCheckNew>().enabled = false;
                        //checktest = false;
                    }
                    if (time >= 6)
                    {
                        resetStage(3, 0.75f);
                    }
                }
            }
        }
        else
        {
            Canvas_SkillCkeck.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // MainSource.clip = InArea;
          //  MainSource.Play();
            Area = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Area = false;
    }

    void resetStage(int stage, float bar)
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
        AlertBar.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        CheckImg = false;
        MinusCheck = false;
        FinishStage = false;
        CurrentStage = stage;
        time = 0.0f;
        KeepTime = 0.0f;
        BarStartStage = bar;
        check[0] = true;
        check[1] = false;
        check[2] = false;
        check[3] = false;
        check[4] = false;
    }

}
