using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    [SerializeField] private int Health = 3; 
    [SerializeField] private Material[] materials;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Health==3)GetComponent<MeshRenderer>().material = materials[0];
        if(Health==2)GetComponent<MeshRenderer>().material = materials[1];
        if(Health==1)GetComponent<MeshRenderer>().material = materials[2];
        if(Health==0)GetComponent<MeshRenderer>().material = materials[3];
    }
    public int Attacked(){
        Health--;
        return Health;
    }
}
