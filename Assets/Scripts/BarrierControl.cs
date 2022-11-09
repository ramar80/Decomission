using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("CommonEnemy").Length==0 &&
        GameObject.FindGameObjectsWithTag("StaticEnemy").Length==0)Destroy(gameObject);   
    }
}
