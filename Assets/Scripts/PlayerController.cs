using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 8;

    private Rigidbody rb;

    private int startImmunity = 30;
    private int immunity = 0;

    private float movementX;
    private float movementY;
    public PlayerHP HealthMark;

    private GameObject WinText;
    private GameObject LoseText;
    private GameObject PauseText;

    private string CurrentScene;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        WinText = GameObject.Find("WinText");
        LoseText = GameObject.Find("LoseText");
        PauseText = GameObject.Find("Pause");

        WinText.SetActive(false);
        LoseText.SetActive(false);
        PauseText.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update(){
        if (Input.GetKeyDown("r")) { //If you press R
            SceneManager.LoadScene(CurrentScene); //Load scene called Game
        }
        if (Input.GetKeyDown("c") && WinText.activeSelf){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        if (Input.GetKeyDown("p") && !WinText.activeSelf && !LoseText.activeSelf){
            if(Time.timeScale == 0){
                PauseText.SetActive(false);
                Time.timeScale = 1;
            } 
            else{
                PauseText.SetActive(true);
                Time.timeScale = 0;
            } 
        }
    }

    private void FixedUpdate()
    {
        if(immunity>0)
            immunity--;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength)){
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            pointToLook.y = transform.position.y;
            transform.LookAt(pointToLook);
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        if(movementX != 0 || movementY != 0){
            rb.isKinematic = false;
            rb.velocity = (movement * speed);
        }
        else{
            rb.isKinematic = true;
            rb.velocity = new Vector3(0,0,0);
        } 

        if(!WinText.activeSelf)
            if(GameObject.FindGameObjectsWithTag("Enemy").Length==0){
                WinText.SetActive(true);
                Time.timeScale = 0;
            }
                
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="Hazard" ||collision.gameObject.tag.Contains("Enemy") || collision.gameObject.tag=="Breakable"){
            if(immunity==0){
                if(HealthMark.Attacked()==0){
                    LoseText.SetActive(true);
                    Time.timeScale = 0;
                }
                immunity=startImmunity;
            }
            else{
            }
        }
    }

}