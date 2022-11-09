using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float speed = 12;
    private Vector3 samePos;
    private int sameCount = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        samePos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(rb.velocity.z <= transform.forward.z * speed){
            rb.velocity = transform.forward * speed;
        }
        if(checkIfSimilarPos()) sameCount--;
        else{
            sameCount = 3;
            samePos = rb.transform.forward;
        }
        if(sameCount <= 0) Destroy(rb.gameObject);

    }
    void OnCollisionEnter(Collision collision){

        if(rb.gameObject.tag.Contains("Hazard") && (collision.gameObject.tag=="PlayerBullet")){
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            rb.velocity = transform.forward * speed;
            return;
        }
        if(rb.gameObject.tag=="PlayerBullet" && (collision.gameObject.tag=="EnemyHazardBullet")){
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            rb.velocity = transform.forward * speed;
            return;
        }
        if(rb.gameObject.tag.Contains("Enemy") && (collision.gameObject.tag.Contains("Enemy"))){
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            rb.velocity = transform.forward * speed;
            return;
        }
        //if(rb.gameObject.tag.Contains("Bullet") && !rb.gameObject.tag.Contains("Player") && colli)

        if(rb.gameObject.tag=="PlayerBullet"){
            if(collision.gameObject.tag.Contains("Break") || collision.gameObject.tag=="CommonEnemy"){
                Destroy(collision.gameObject);
            }
            if(collision.gameObject.tag.Contains("Player")){
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                rb.velocity = transform.forward * speed;
                return;
            }
        }
        Destroy(rb.gameObject);
    }
    bool checkIfSimilarPos(){
        float aux = Vector3.Distance(samePos,rb.transform.position);
        if(aux < 0.05f) return true;
        return false;
    }
}
