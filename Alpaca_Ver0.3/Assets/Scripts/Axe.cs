using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController character;
    bool count;
    float time;
    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count)
        {
            time = time + Time.deltaTime;
        }

        if(time > 3)
        {
            count = false;
            time = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Alpaca" && !count)
        {
            collision.gameObject.GetComponent<asasdasd>().addHit();
            count = true;
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
