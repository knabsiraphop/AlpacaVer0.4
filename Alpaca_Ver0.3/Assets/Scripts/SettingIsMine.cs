using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SettingIsMine : MonoBehaviourPunCallbacks
{
    public GameObject[] HideObj;
    public TextMeshProUGUI PlayerNameText;
    public TextMeshProUGUI OwnPlayerNameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            gameObject.GetComponent<MainPlayerController>().enabled = true;
            SetName(OwnPlayerNameText);
            
        }
        else
        {
            HideObj[0].SetActive(false);
            gameObject.GetComponent<MainPlayerController>().enabled = false;
            SetName(PlayerNameText);

        }
    }

    void SetName(TextMeshProUGUI TT)
    {
        TT.text = photonView.Owner.NickName;
    }
}
