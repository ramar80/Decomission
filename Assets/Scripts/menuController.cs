using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReplayGame(){
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void ExitGame(){
        Application.Quit();
    }
}
