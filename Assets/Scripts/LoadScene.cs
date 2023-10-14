using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public GameObject GUIEventSystem;
    bool triggered;
    public bool loadSampleSceneImageTarget;
    public void LoadImageTargetScene()
    {
        SceneManager.LoadScene("SampleSceneImageTarget");
        //Destroy(GUIEventSystem);
    }
    public void quitAppNow()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }
}
