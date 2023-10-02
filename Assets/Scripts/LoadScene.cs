using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    bool triggered;
    public void LoadImageTargetScene()
    {
        SceneManager.LoadScene("SampleSceneImageTarget");
    }
}
