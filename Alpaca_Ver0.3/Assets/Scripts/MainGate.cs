using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGate : MonoBehaviour
{
    int Completed = 0;
    float time = 0.0f;
    float KeepTime = 0.0f;

    bool gateActive = false;
    bool inGateArea = false;
    bool PlayBar = false;
    bool BarCompleted = false;

    public GameObject Canvas_Gate;
    public GameObject LeftG;
    public GameObject RightG;
    public Transform gateBar;

    Collider a,b;
    AudioSource mGAudiosurce;
    Animator Left;
    Animator Right;
    // Start is called before the first frame update
    void Start()
    {
        a = LeftG.GetComponent<Collider>();
        b = RightG.GetComponent<Collider>();
        Left = LeftG.GetComponent<Animator>();
        Right = RightG.GetComponent<Animator>();
        mGAudiosurce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Completed == 4)
        {
            gateActive = true;
        }   
        if (Input.GetMouseButtonDown(0) && inGateArea && gateActive)
        {
            Canvas_Gate.SetActive(true);
            PlayBar = true;
        }else if (Input.GetMouseButtonUp(0) || !inGateArea)
        {
            Canvas_Gate.SetActive(false);
            time = 0;
            KeepTime = 0;
            PlayBar = false;
        }
        if (PlayBar && !BarCompleted)
        {
            if(time <= 30)
            {
                time = time + Time.deltaTime;

                KeepTime = time * 10.0f / 3.0f;
                gateBar.transform.localScale = new Vector3((KeepTime / 100.0f), 1.0f, 1.0f);
            }
            else
            {
                Canvas_Gate.SetActive(false);
                BarCompleted = true;
                time = 0;
            }
        }
       // print(BarCompleted);
        if (BarCompleted)
        {
            a.isTrigger = true;
            b.isTrigger = true;
            //mGAudiosurce.enabled = true;
            if (mGAudiosurce.isPlaying == false)
            {
                Left.enabled = true;
                Right.enabled = true;
            }
           // mGAudiosurce.clip = openGate;
          //  mGAudiosurce.Play();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gateActive)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                inGateArea = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gateActive)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                inGateArea = false;
            }
        }
    }

    public void addCompleted()
    {
        Completed = Completed+1;
        print(Completed);
    }
}
