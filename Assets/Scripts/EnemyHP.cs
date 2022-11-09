using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int Health;
    public BarrierControl barrier;
    private Rigidbody rb;

    private bool hit;
    Material showHit;
    Material defaultMat;
    private int dmgTime = 10;

    void Start()
    {
        hit=false;
        defaultMat = Resources.Load("Materials/Breakable", typeof(Material)) as Material;
        showHit = Resources.Load("Materials/Hit", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hit){
            GetComponent<MeshRenderer>().material = showHit;
            dmgTime--;
        }
        if(dmgTime==0){
            GetComponent<MeshRenderer>().material = defaultMat;
            hit=false;
        }
    }
    void OnCollisionEnter(Collision collision){
        if(barrier==null)
            if(collision.gameObject.tag=="PlayerBullet"){
                Health--;
                hit=true;
                dmgTime = 5;
                if(Health==0)Destroy(gameObject);
            }
    }
}
