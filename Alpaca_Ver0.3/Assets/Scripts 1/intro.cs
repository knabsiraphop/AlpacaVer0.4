using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
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

    CharacterController character;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, 0, 1);        // 
                                                // 
        velocity = transform.TransformDirection(velocity);
        velocity *= forwardSpeed;

        CollisionFlags flag = character.Move(velocity * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
    }
}
