using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyThisGameObjectOnLoad : MonoBehaviour
{
    //this script is used in every scene in which vuforia is running, where if the user presses the go back move/button, the app should inform the user to go back to the GUI scene
    void Awake()
    {
        // Make the GameObject persist across scenes
        DontDestroyOnLoad(this.gameObject);
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        SceneManager.LoadScene("GUIScene");
    //    }
    //}
}
