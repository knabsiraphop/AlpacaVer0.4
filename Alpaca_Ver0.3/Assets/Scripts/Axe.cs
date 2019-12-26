using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController character;
    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Alpaca")
        {
            collision.gameObject.GetComponent<asasdasd>().addHit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Alpaca")
        {
            other.gameObject.GetComponent<asasdasd>().addHit();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit.gameObject.tag);

    }

}
