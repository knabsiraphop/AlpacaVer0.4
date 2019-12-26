using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;
using UnityEngine.EventSystems;

public class Mutiphoton : MonoBehaviourPunCallbacks
{

    public PlayfabLogin pf;

    public GameObject[] SelectAl;
    public GameObject[] SelectHun;
    public GameObject playbut;
    public GameObject playbut2;
    public Text connectingStatus;
    public string gameversion;
    public GameObject player_m;
    public GameObject preCam;
    public GameObject rommCanvas;
    public GameObject mainCam;
    public GameObject ThirdCam;
    public GameObject CreJo;
    public GameObject side;//choosen ui
    public GameObject alpacaSide;
    public GameObject HunterSide;

    bool checkChar = false;

    string Ss;

    GameObject currentSelected;
    GameObject currentSelected2;

    bool played = false;

    //Animator alpacaModle;


    // Start is called before the first frame update
    void Start()
    {
        //alpacaModle = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
        currentSelected2 = EventSystem.current.currentSelectedGameObject;

        if (Ss == "alpacaMul" && played == false)
        {
            SelectAl[0].SetActive(true);
            SelectAl[0].transform.Rotate(0, 1, 0);
            SelectAl[1].transform.Rotate(0, 1, 0);
            SelectAl[2].transform.Rotate(0, 1, 0);
            if (currentSelected.name == "alpaca1")
            {
                SelectAl[0].SetActive(true);
                SelectAl[1].SetActive(false);
                SelectAl[2].SetActive(false);
                print("alpaca1");
                checkChar = true;

            }
            else if (currentSelected.name == "alpaca2")
            {
                SelectAl[0].SetActive(false);
                SelectAl[1].SetActive(true);
                SelectAl[2].SetActive(false);
                print("alpaca2");
                checkChar = true;
            }
            else if (currentSelected.name == "alpaca3")
            {
                SelectAl[0].SetActive(false);
                SelectAl[1].SetActive(false);
                SelectAl[2].SetActive(true);
                print("alpaca3");
                checkChar = true;
            }
        }

        if (Ss == "PlayerMul" && played == false)
        {
            print("hunnnn");
            print(currentSelected.name);
            SelectHun[0].SetActive(true);
            SelectHun[0].transform.Rotate(0, 1, 0);
            SelectHun[1].transform.Rotate(0, 1, 0);
            SelectHun[2].transform.Rotate(0, 1, 0);
            if (currentSelected.name == "Hunter1")
            {
                SelectHun[0].SetActive(true);
                SelectHun[1].SetActive(false);
                SelectHun[2].SetActive(false);
                print("hunter1");
                checkChar = true;
            }
            else if (currentSelected.name == "Hunter2")
            {
                SelectHun[0].SetActive(false);
                SelectHun[1].SetActive(true);
                SelectHun[2].SetActive(false);
                print("hunter2");
                checkChar = true;
            }
            else if (currentSelected.name == "Hunter3")
            {
                SelectHun[0].SetActive(false);
                SelectHun[1].SetActive(false);
                SelectHun[2].SetActive(true);
                print("hunter3");
                checkChar = true;
            }

            if (currentSelected2.name == "playAl")
            {

            }
            if (currentSelected2.name == "playHun")
            {

            }
        }


    }

    private void FixedUpdate()
    {
        //connectingStatus.text = PhotonNetwork.connectionState.ToString();
        connectingStatus.text = PhotonNetwork.NetworkClientState.ToString();
    }

    public void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public virtual void OnConnectedToMaster()
    {
        pf.Hide();
    }

    public void Join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void Create()
    {
        RoomOptions rm = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = true
        };
        int rndID = Random.Range(0, 3000);
        PhotonNetwork.CreateRoom("Default:" + rndID, rm, TypedLobby.Default);
        side.SetActive(true);
        CreJo.SetActive(false);
        print("roomCreate");
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        print("JoinFailed");
    }

    public virtual void OnJoinedRoom()
    {
        side.SetActive(true);
        CreJo.SetActive(false);
        print("JOin!!!");
        //GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
    }

    public void OnSelectSide(string ss)
    {
        side.SetActive(false);
        //playbut.SetActive(true);
        Ss = ss;
        print(Ss + ";" + ss);

        if (Ss == "alpacaMul")
        {
            //select alpaca
            alpacaSide.SetActive(true);

            HunterSide.SetActive(false);
            print("alpaca");

        }
        else
        {
            //select hunter
            HunterSide.SetActive(true);
            alpacaSide.SetActive(false);
            print("Hunter");
        }

    }

    public void playAl()
    {
        played = true;
        SelectAl[0].SetActive(false);
        SelectAl[1].SetActive(false);
        SelectAl[2].SetActive(false);
        print(currentSelected2.name);
        if (currentSelected2.name == "alpaca1")
        {
            Ss = "AlpacaMul1";
        }
        else if(currentSelected2.name == "alpaca2")
        {
            Ss = "AlpacaMul2";
        }
        else
        {
            Ss = "AlpacaMul3";
        }
        rommCanvas.SetActive(false);
        mainCam.SetActive(true);
        //GameObject player = PhotonNetwork.Instantiate("PlayerMul", Vector3.zero,Quaternion.identity, 0);
        GameObject alpaca = PhotonNetwork.Instantiate(Ss, Vector3.zero, Quaternion.identity, 0);
    }

    public void playHun()
    {
        SelectHun[0].SetActive(false);
        SelectHun[1].SetActive(false);
        SelectHun[2].SetActive(false);
        print(currentSelected2.name);
        rommCanvas.SetActive(false);
        mainCam.SetActive(true);
        //GameObject player = PhotonNetwork.Instantiate("PlayerMul", Vector3.zero,Quaternion.identity, 0);
        GameObject hunter = PhotonNetwork.Instantiate(Ss, Vector3.zero, Quaternion.identity, 0);
    }
    /*public void play()
    {
        rommCanvas.SetActive(false);
        mainCam.SetActive(true);
        //GameObject player = PhotonNetwork.Instantiate("PlayerMul", Vector3.zero,Quaternion.identity, 0);
        print(Ss);
        GameObject alpaca = PhotonNetwork.Instantiate(Ss, Vector3.zero, Quaternion.identity, 0);
    }*/


}
