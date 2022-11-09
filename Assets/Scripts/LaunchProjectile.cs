using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private int fireDelay = 30;
    [SerializeField] private int wait = 0;

    private int fireWait = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fireWait>0) fireWait--;
        else{
            if(this.name.Contains("Player")){
                if(Input.GetKey("space") || Input.GetMouseButton(0)){
                    Shoot();
                    fireWait = fireDelay;
                }
            }
            else {
                if(wait==0){
                    Shoot();
                    fireWait = fireDelay;
                }
                else wait--;
            } 
            
        }
        
    }
    void Shoot(){
        GameObject bullet = Instantiate(projectile,transform.position+ new Vector3(0,0.32f,0),transform.rotation);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
    }
}
