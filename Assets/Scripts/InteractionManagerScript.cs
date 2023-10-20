using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class InteractionManagerScript : MonoBehaviour
{
    public Transform MainCameraObject;
    public float distance;
    public TextMeshProUGUI textMeshProUGUI;
    public Material highlightMaterial;
    GameObject selectedObject;
    Material originalMaterial;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        //Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;
        //Debug.DrawRay(transform.position, -transform.up*distance, Color.green);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up * distance, Color.green);
        //this will detect if the game object is hit by the ray
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Interactive"))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if(renderer != null)
                {
                    originalMaterial = renderer.material;
                    renderer.material = highlightMaterial;
                    GameObject selectedObject = hit.collider.gameObject;
                }
                textMeshProUGUI.text = hit.transform.name;
                //action to be perform by selecting the Interactible object
                //Debug.LogWarning("O objeto "+hit.transform.name+ " foi colidido");
            }
        }
        else if (hit.collider == null)
        {
            if (selectedObject != null)
            {
                Renderer render = selectedObject.GetComponent<Renderer>();
                if (render != null)
                {
                    Material originalMaterial = render.material;
                    Color originalColor = originalMaterial.color;
                    render.material.color = originalColor;
                }
            }
            textMeshProUGUI.text = "";
        }
    }
}