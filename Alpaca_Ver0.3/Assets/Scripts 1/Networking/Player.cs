using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{

    public Rigidbody rb;
    private float x;
    private float z;

    public float speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (photonView.IsMine)
        {

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {     
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            rb.AddForce(new Vector3(x, 0, z)*speed);
        }
    }
}
