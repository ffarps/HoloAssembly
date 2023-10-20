using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setActiveConfirmationPanel : MonoBehaviour
{
    public GameObject EvenSystemObject;
    public GameObject confirmationPanel;
    bool panel = false;
    void Awake()
    {
        // Make the GameObject persist across scenes
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        //confirmationPanel.SetActive(false);
        //Asyncloader = transform.GetComponent<AsyncSceneLoader>();
    }
    public void Update()
    {
        //  if (Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().name!="GUIScene")
        if(Input.GetKeyUp(KeyCode.Escape)&&SceneManager.GetActiveScene().name!="GUIScene")
        {
            panel = !panel;
            confirmationPanel.SetActive(panel);
        }
    }
    public void YesButtonReturnToGUIScene()
    {
        if (SceneManager.GetActiveScene().name != "GUIScene")
        {
          //  Asyncloader.LoadSceneButton("GUIScene");
            SceneManager.LoadScene("GUIScene");
        }
        confirmationPanel.SetActive(false);
        Destroy(EvenSystemObject);
    }
    public void NoButtonDeactivatePanel()
    {
        confirmationPanel.SetActive(false);
    }
}
