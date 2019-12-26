using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamAnim : MonoBehaviour
{
    public GameObject position;
   public GameObject image;
    public RawImage logo;
    public GameObject farmer;
    float time;
    private void Start()
    {
        if (gameObject.name == "Cam4")
        {
            farmer.SetActive(true);
        }
            time = 0;
    }
    public void OnAnimationEnd()
    {
        
        if(gameObject.name == "Cam5" && image != null)
        {
            image.SetActive(true);
            Color c = logo.material.color;
            c.a = 0;
            image.transform.position = position.transform.position;
        }
        
        else
        {
            AnimationManager.instance.DestroyCamera(gameObject);
        }
    }

    public void Update()
    {
       
        if (gameObject.name == "Cam4")
        {
            time = time + Time.deltaTime;
            if (time >= 5)
            {
                farmer.SetActive(false);
            }
        }
    }
}
