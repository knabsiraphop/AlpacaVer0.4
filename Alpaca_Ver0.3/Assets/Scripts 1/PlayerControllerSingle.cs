using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSingle : MonoBehaviour
{

    public float forwardSpeed = 5F;
    // 
    public float backwardSpeed = 2F;
    // 
    public float rotateSpeed = 4F;
    // 
    public float jumpSpeed = 8F;
    // 
    public float gravity = 20F;

    public AudioClip walkS;
    public AudioClip bwalkS;
    public AudioClip runS;

    AudioSource PSource;
    Animator anim;
    bool chturn = false;
    public GameObject CamF;
    public GameObject CamB;
    // 
    CharacterController character;
    // 
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        PSource = gameObject.AddComponent<AudioSource>();
        PSource.loop = true;
        PSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!chturn)
            {
                CamF.SetActive(false);
                CamB.SetActive(true);
                chturn = true;
            }
            else
            {
                CamF.SetActive(true);
                CamB.SetActive(false);
                chturn = false;

            }
            
        }
        float v = Input.GetAxis("Vertical");        // 
        float h = Input.GetAxis("Horizontal");  // 

        if (v > 0 || h != 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            forwardSpeed = 0.2f;
            anim.SetFloat("speed", 2.0f);
            if (!PSource.isPlaying)
            {
                PSource.clip = walkS;
                PSource.Play();
            }



        }
        else if (v < 0)
        {
            forwardSpeed = 0.2f;
            anim.SetFloat("speed", 6.0f);
        }
        else
        {
            PSource.Stop();
            anim.SetFloat("speed", 0.0f);
        }

        if (v > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            PSource.Stop();
            forwardSpeed = 5.0f;
            anim.SetFloat("speed", 4.0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("pickup");
        }
        velocity = new Vector3(h, 0, v);        // 
                                                // 
        velocity = transform.TransformDirection(velocity);

        if (v > 0)
        {
            velocity *= forwardSpeed;       // 
        }
        else if (v < 0)
        {
            velocity *= backwardSpeed;  // 
        }

        CollisionFlags flag = character.Move(velocity * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
    }
    public void disableCom()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
    }

    public void enableCom()
    {
        gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
