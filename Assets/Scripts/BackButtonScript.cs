using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    GameObject confirmationPanel;
    private bool ConfirmationPending = false;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().name!="GUIScene")
        {
            ShowConfirmationPanel();
        }
    }
    private void ShowConfirmationPanel()
    {
        Debug.LogWarning("SHOW!");
        confirmationPanel.SetActive(true);
        ConfirmationPending = true;
    }
    void confirmPanel() 
    {
        SceneManager.LoadScene("GUIScene");
    }
    void CancelPanel()
    {
        confirmationPanel.SetActive(false);
        ConfirmationPending= false;
    }

}
