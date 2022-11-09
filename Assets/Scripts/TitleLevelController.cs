using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TitleLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI LevelName;

    void Start()
    {
        LevelName.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
