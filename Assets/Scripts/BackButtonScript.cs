using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    public GameObject confirmationPanel;
    private bool ConfirmationPending = false;
    private void Update()
    {
        if (ConfirmationPending && Input.GetKeyUp(KeyCode.Escape))
        {
            ShowConfirmationPanel();
        }
    }
    private void ShowConfirmationPanel()
    {
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
