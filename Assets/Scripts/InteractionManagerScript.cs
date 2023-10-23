using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManagerScript : MonoBehaviour
{
    /// <summary>
    /// This class handles the interaction between objects and a cast ray
    /// ffarps October 2023
    /// </summary>
    Outline outline;
    float DistanceToObject = 10f;
    public Transform MainCameraObject;
    public TextMeshProUGUI textMeshProUGUI;
    GameObject HoveredObject;
    GameObject SelectedObject;
    bool hasAnyObjectBeenHovered = false;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up * DistanceToObject, Color.green);
        RaycastHit hit;
        //this will detect if the game object is hit by the ray
        if (Physics.Raycast(ray, out hit, DistanceToObject))
        {
            if (hit.transform.TryGetComponent<Outline>(out outline))
                //action to be perform by selecting the Interactible object
                OnHover(hit);
            //Debug.Log("O objeto "+hit.transform.name+ " foi colidido");
        }
        else if (hit.collider == null && hasAnyObjectBeenHovered)
        {
            OnHoverExit();
        }
    }
    void OnHover(RaycastHit hit)
    {
        
        {
            while (outline.OutlineWidth < 5)
            {
                outline.OutlineWidth++;
            }
            hasAnyObjectBeenHovered = true;
            textMeshProUGUI.text = hit.transform.name;
            HoveredObject=hit.collider.gameObject;
            if(Input.GetMouseButtonDown(0))
            {
                Select(hit);
                if (Input.GetMouseButtonDown(0))
                {
                    Deselect(hit);
                }
            }
        }
        /// to do
        /// Database 
    }
    void OnHoverExit()
    {
        textMeshProUGUI.text = "";
        while (outline.OutlineWidth > 0)
        {
            outline.OutlineWidth--;
        }
    }
    void Select(RaycastHit hit)
    {
        //this is only called when the object is hovered an clicked to select
        SelectedObject = hit.collider.gameObject;
        Debug.LogWarning("Object "+SelectedObject.name+" Selected");
    }
    void Deselect(RaycastHit hit)
    {
        //this is only called when the object is hovered an clicked to deselect
        if (SelectedObject!=null)
        {
            while (outline.OutlineWidth > 0)
            {
            outline.OutlineWidth--;
            }
            SelectedObject = null;
        }
        Debug.LogWarning("Object " + SelectedObject.name + " deselected");
    }
}