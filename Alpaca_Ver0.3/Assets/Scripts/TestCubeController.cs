using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TestCubeController : MonoBehaviourPunCallbacks
{
    public float forwardSpeed = 5.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 4.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public GameObject Cam;
    CharacterController CharControl;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        CharControl = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");


            velocity = new Vector3(h, 0, v);

            velocity = transform.TransformDirection(velocity);

            if (v > 0 || (v > 0 && h != 0))
            {
                velocity *= forwardSpeed;

            }
            else if (v < 0 || (v < 0 && h != 0))
            {
                velocity *= backwardSpeed;

            }
            else if (h != 0)
            {
                velocity *= forwardSpeed;
            }
            velocity.y -= gravity * Time.deltaTime;
            CollisionFlags flag = CharControl.Move(velocity * Time.deltaTime);
            if (flag == CollisionFlags.None)
            {
                // 
            }
            if ((flag & CollisionFlags.Above) == CollisionFlags.Above)
            {
                // 
            }
            if ((flag & CollisionFlags.Sides) == CollisionFlags.Sides)
            {
                //
            }
            if ((flag & CollisionFlags.Below) == CollisionFlags.Below)
            {
                // 
            }
            transform.Rotate(0, h * rotateSpeed, 0);
        }
        else
        {
            gameObject.GetComponent<TestCubeController>().enabled = false;
            Cam.SetActive(false);
        }
        print(CharControl.detectCollisions);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit);
    }
}

