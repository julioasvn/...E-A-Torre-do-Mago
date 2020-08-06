using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAtack : MonoBehaviour
{
        
    void Start()
    {
        
    }
   
    void Update()
    {        
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            Destroy(this.gameObject);            
        }        
    }
}
