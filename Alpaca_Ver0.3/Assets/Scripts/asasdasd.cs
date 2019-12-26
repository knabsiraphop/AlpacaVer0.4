using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class asasdasd : MonoBehaviourPunCallbacks
{
    int Hit = 0;
    public GameObject Crate;
    public GameObject Alpaca;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(Hit);
        if(Hit == 2)
        {
            Alpaca.SetActive(false);
            Crate.SetActive(true);
            
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit);
    }

    public void addHit()
    {
        Hit++;
    }
}
