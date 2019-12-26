using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainPlayerController : MonoBehaviourPunCallbacks
{
    public float forwardSpeed = 5.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 4.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public GameObject Cam;
    Animator PlayerAnim;
    Renderer AlpacaRender;
    CharacterController CharControl;
    bool Attack = true;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        CharControl = gameObject.GetComponent<CharacterController>();
        PlayerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (!PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("2Hand-Axe-Attack3"))
        {
            if (Attack)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlayerAnim.SetTrigger("Attack");
                    Attack = false;
                }
            }
        }
        else
        {
            Attack = true;
            v = 0;
            h = 0;
        }
        velocity = new Vector3(h, 0, v);

        velocity = transform.TransformDirection(velocity);

        if (v > 0 || (v > 0 && h != 0))
        {
            velocity *= forwardSpeed;
            PlayerAnim.SetFloat("Speed", 5.0f);
            if (h < 0)
            {
                PlayerAnim.SetFloat("Speed", 4.0f);
            }
            else if (h > 0)
            {
                PlayerAnim.SetFloat("Speed", 6.0f);
            }
        }
        else if (v < 0 || (v < 0 && h != 0))
        {
            velocity *= backwardSpeed;
            PlayerAnim.SetFloat("Speed", 10.0f);
            if (h < 0)
            {
                PlayerAnim.SetFloat("Speed", 8.0f);
            }
            else if (h > 0)
            {
                PlayerAnim.SetFloat("Speed", 12.0f);
            }
        }
        else if (h != 0)
        {
            velocity *= forwardSpeed;
        }
        else
        {
            PlayerAnim.SetFloat("Speed", 0.0f);
        }


        //CharControl.Move(velocity * Time.deltaTime);
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
        velocity.y -= gravity * Time.deltaTime;
    }
}

