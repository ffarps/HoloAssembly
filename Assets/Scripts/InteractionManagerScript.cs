using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class InteractionManagerScript : MonoBehaviour
{
    public Transform MainCameraObject;
    public float distance;
    public TextMeshProUGUI textMeshProUGUI;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        //Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;

        //Debug.DrawRay(transform.position, -transform.up*distance, Color.green);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up*distance, Color.green);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Interactive"))
            {
                textMeshProUGUI.text = hit.transform.name;

                //action to be perform by selecting the Interactible object
                //Debug.LogWarning("O objeto "+hit.transform.name+ " foi colidido");

            }
        }
    }
}
