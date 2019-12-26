using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonController : MonoBehaviourPunCallbacks
{
    public InputField InputNickname;
    public Text TextStatus;
    public Button PlayButton;
    public GameObject[] HideOrShow;

    string status = "";
    string Nickname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.NetworkClientState.ToString().Equals(status))
        {
            status = PhotonNetwork.NetworkClientState.ToString();
            TextStatus.text = status;
        }

        if(InputNickname.text.Length == 0)
        {
            PlayButton.interactable = false;
        }
        else
        {
            PlayButton.interactable = true;
        }
    }

    public void OnClickPlay()
    {
        PhotonNetwork.ConnectUsingSettings();
        Nickname = InputNickname.text;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.NickName = Nickname;
        print(PhotonNetwork.NickName);
        
        PhotonNetwork.JoinRandomRoom();
        
    }

    public void OnClickAlpaca()
    {
        PhotonNetwork.Instantiate("Capsule",new Vector3(0,2,0), Quaternion.identity, 0);
        HideOrShow[3].SetActive(false);
        HideOrShow[0].SetActive(false);
    }

    public void OnClickHunter()
    {
        
        PhotonNetwork.Instantiate("Farmer_Female", Vector3.zero, Quaternion.identity,0);
        HideOrShow[3].SetActive(false);
        HideOrShow[0].SetActive(false);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions rm = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = true
        };
        int rndID = Random.Range(0, 3000);
        PhotonNetwork.CreateRoom("Default:" + rndID, rm, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        HideOrShow[1].SetActive(false);
        HideOrShow[2].SetActive(true);
    }

}
