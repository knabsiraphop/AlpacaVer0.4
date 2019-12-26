using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void chageImage(Sprite sprite)
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = sprite;
    }
}
