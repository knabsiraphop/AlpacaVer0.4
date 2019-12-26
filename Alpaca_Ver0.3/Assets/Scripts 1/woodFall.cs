using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodFall : MonoBehaviour
{
    Animator wF;
    // Start is called before the first frame update
    void Start()
    {
        wF = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                wF.enabled = true;
            }
        }
    }
}
