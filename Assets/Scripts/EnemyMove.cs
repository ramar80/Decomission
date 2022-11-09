using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float moveSpeed = 1.0f;
    private float facingSpeed = 1.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
        GameObject[] breakProj = GameObject.FindGameObjectsWithTag("EnemyBreakBullet");
        GameObject[] unbreakProj = GameObject.FindGameObjectsWithTag("EnemyHazardBullet");
        GameObject[] enemyEntities = new GameObject [breakProj.Length + unbreakProj.Length];
        breakProj.CopyTo(enemyEntities,0);
        unbreakProj.CopyTo(enemyEntities,breakProj.Length);
        foreach(GameObject bullet in enemyEntities){
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        float singleStep = facingSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection,singleStep,0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,moveSpeed * Time.deltaTime);
    }
}
