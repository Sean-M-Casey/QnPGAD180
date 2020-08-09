using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlimpseItems : MonoBehaviour
{
    public GameObject[] glimpseItems;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < glimpseItems.Length; i++)
        {
            glimpseItems[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
