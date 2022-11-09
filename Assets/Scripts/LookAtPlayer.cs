using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public int mode = 0;
    private int rotateTime = 30;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mode == 0){
            transform.LookAt(player.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        if(mode == 1){
            rotateTime--;
            if(rotateTime==0){
                transform.Rotate(0,45,0);
                rotateTime = 30;
            }
            
        }
    }
}
