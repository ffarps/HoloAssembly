using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    bool triggered;
    public bool loadSampleSceneImageTarget;

    public void LoadImageTargetScene()
    {
        SceneManager.LoadScene("SampleSceneImageTarget");
    }
}
