using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaController : MonoBehaviour
{

    Animator alpaca;
    public GameObject camFront;
    public GameObject camBack;
    bool chturn = false;

    float time_ = 5;
    public float forwardspeed = 3F;
    public float Runspeed = 8F;
    public float rotateSpeed = 2F;
    //public float jumpSpeed = 8F;
    public float gravity = 20F;
    CharacterController character;

    Vector3 velocity;
    void Start()
    {
        character = GetComponent<CharacterController>();
        alpaca = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!chturn)
            {
                camFront.SetActive(false);
                camBack.SetActive(true);
                chturn = true;
            }
            else
            {
                camFront.SetActive(true);
                camBack.SetActive(false);
                chturn = false;

            }

        }

        float v = Input.GetAxis("Vertical");        
        float h = Input.GetAxis("Horizontal");

        if (character.isGrounded)
        {
            velocity = new Vector3(h, 0, v);
            velocity = transform.TransformDirection(velocity);

            if (v <= 0)
            {
                alpaca.SetFloat("speed", 0f);
            }
            else if (v > 0 && v <= 0.5)
            {
                    //walk
                    velocity *= forwardspeed;
                    alpaca.SetFloat("speed", forwardspeed);
            }
            else if (v > 0.5)
            {
                //run
                velocity *= Runspeed;
                alpaca.SetFloat("speed", Runspeed);
            }
        }
        
        //attacked
        if (v <= 0 && Input.GetKey(KeyCode.X))
        {
            alpaca.SetTrigger("IsAtk");

            time_ -= Time.deltaTime;
            if (time_ >= 0)
            {
                velocity *= forwardspeed;
                alpaca.SetFloat("speed", forwardspeed);
                
            }
            else
            {
                alpaca.SetBool("IsIdle", true);
            }

        }



        //collide object
        if (Input.GetKey(KeyCode.Space))
        {
            alpaca.SetTrigger("IsCollide");
        }
        else
        {
            alpaca.SetBool("IsIdle", true);
        }
        


        //Dead
        if (Input.GetKey(KeyCode.Q))
        {
            alpaca.SetTrigger("Isfall");
            //alpaca.SetBool("catch", true);
            time_ -= Time.deltaTime;
            if(time_ <= 0)
            {
                alpaca.SetBool("catch", true);
            }

        }
        



            velocity.y -= gravity * Time.deltaTime;
    

    CollisionFlags flag = character.Move(velocity * Time.deltaTime);
		if (flag == CollisionFlags.None) {
			
		}
		if ((flag & CollisionFlags.Above) == CollisionFlags.Above) {
			
		}
		if ((flag & CollisionFlags.Sides) == CollisionFlags.Sides) {
			
		}
		if ((flag & CollisionFlags.Below) == CollisionFlags.Below) {
			
		}
		
		transform.Rotate(0, h* rotateSpeed, 0);
    }

   
}