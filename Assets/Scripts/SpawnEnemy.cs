using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private int spawnRate;
    [SerializeField] private GameObject enemyToSpawn;
    private int spawnCounter;
    private Vector3 fixPos = new Vector3(0,-0.3f,0);

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = 20;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(spawnCounter==0){
            if(!Physics.CheckSphere(transform.position+transform.forward,0.5f)){
                Instantiate(enemyToSpawn,transform.position+transform.forward*1f+fixPos,transform.rotation);
                spawnCounter = spawnRate;
                return;
            }
            if(!Physics.CheckSphere(transform.position+transform.right,0.5f)){
                Instantiate(enemyToSpawn,transform.position+transform.right*1.5f+fixPos,transform.rotation);               
                spawnCounter = spawnRate;
                return;
            }
            if(!Physics.CheckSphere(transform.position-transform.right,0.5f)){
                Instantiate(enemyToSpawn,transform.position+transform.right*(-1.5f)+fixPos,transform.rotation);
                spawnCounter = spawnRate;
                return;
            }
            if(!Physics.CheckSphere(transform.position-transform.forward,0.5f)){
                Instantiate(enemyToSpawn,transform.position+transform.forward*(-1.5f)+fixPos,transform.rotation);
                spawnCounter = spawnRate;
                return;
            }
        }
        else spawnCounter--;
    }
}
