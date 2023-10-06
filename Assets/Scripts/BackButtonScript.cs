//using System;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//public class BackButtonScript : MonoBehaviour
//{
//    setActiveConfirmationPanel setActiveConfirmationPanel;
//    GameObject confirmationPanel;
//    private bool ConfirmationPending = false;
//    private void Update()
//    {
//        if (Input.GetKeyUp(KeyCode.Escape))
//        {
//            ShowConfirmationPanel();
//        }
//    }
//    private void ShowConfirmationPanel()
//    {
//        Debug.LogWarning("SHOW!");
//        //confirmationPanel.SetActive(true);
//        setActiveConfirmationPanel.ActivateConfirmationPanel(true);
//        ConfirmationPending = true;
//    }
//    void confirmPanel() 
//    {
//        SceneManager.LoadScene("GUIScene");
//    }
//    void CancelPanel()
//    {
//        //confirmationPanel.SetActive(false);
//        setActiveConfirmationPanel.ActivateConfirmationPanel(false);
//        ConfirmationPending = false;
//    }
//}