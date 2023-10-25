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
    bool disableOutline = false;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up * DistanceToObject, Color.green);
        RaycastHit hit;
        //this will detect if the game object is hit by the ray
        if (Physics.Raycast(ray, out hit, DistanceToObject) && hit.transform.TryGetComponent<Outline>(out outline))
        {
            OnHover(hit);
        }
        else if (hit.collider == null && hasAnyObjectBeenHovered)
        {
            OnHoverExit();
            //Deselect();
        }
    }
    void OnHover(RaycastHit hit)
    {
        HoveredObject = hit.collider.gameObject;
        while (outline.OutlineWidth < 5)
        {
            outline.OutlineWidth++;
        }
        hasAnyObjectBeenHovered = true;
        textMeshProUGUI.text = HoveredObject.name;
        if (Input.GetMouseButtonDown(0))
        {
            //SelectedObject = HoveredObject;
            if (SelectedObject != HoveredObject)
            {
                Select(HoveredObject);
                disableOutline = false;
            }
            else
            {
                Deselect();
                disableOutline = true;
            }
        }
        else
        {
            disableOutline = true;
        }
        /// to do
        /// Database 
    }
    void OnHoverExit()
    {
        if (disableOutline)
        {
            textMeshProUGUI.text = "";
            while (outline.OutlineWidth > 0)
            {
                outline.OutlineWidth--;
            }
        }
    }
    void Select(GameObject gameObject)
    {
        //this is only called when the object is hovered an clicked to select
        //SelectedObject = hit.collider.gameObject;
        SelectedObject = gameObject;
        Debug.LogWarning("Object " + SelectedObject.name + " Selected");
    }
    void Deselect()
    {
        //this is only called when the object is hovered an clicked to deselect
        if (SelectedObject != null)
        {
            while (outline.OutlineWidth > 0)
            {
                outline.OutlineWidth--;
            }
            Debug.LogWarning("Object " + SelectedObject.name + " Deselected");
            SelectedObject = null;
        }
    }
}