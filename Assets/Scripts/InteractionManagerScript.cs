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
    public Transform MainCameraObject;
    public TextMeshProUGUI textMeshProUGUI;
    readonly float DistanceToObject = 10f;
    ObjectState objectState;
    Outline outline;
    GameObject HoveredObject;
    GameObject SelectedObject;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up * DistanceToObject, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, DistanceToObject) && hit.transform.TryGetComponent<Outline>(out outline))
        {
            OnHover(hit);
        }
        else if (hit.collider == null && HoveredObject != null)
        {
            OnHoverExit(HoveredObject);
        }
    }
    void OnHover(RaycastHit hit)
    {
        HoveredObject = hit.collider.gameObject;
        outline.OutlineWidth = 5;
        if (HoveredObject != null)
        {
            textMeshProUGUI.text = HoveredObject.name;
            if (Input.GetMouseButtonDown(0))///this is not questioning if the object is selected
            {
                SelectedObject = gameObject;
                if (SelectedObject != HoveredObject)
                {
                    Select(HoveredObject);
                }
                else
                {
                    Deselect(HoveredObject);
                }
            }
            else
            {
                ///
            }
        }
        else
        {
            ///
        }

    }
    void OnHoverExit(GameObject HoveredObject)
    {
        objectState = HoveredObject.GetComponent<ObjectState>();
        if (objectState.IsObjectSelected == false)
        {
            textMeshProUGUI.text = "";
            outline.OutlineWidth = 0;
            HoveredObject = null;
        }
        else
        {
            textMeshProUGUI.text = "";
            outline.OutlineWidth = 5;
            HoveredObject = null;
        }
    }
    void Select(GameObject gameObject)
    {
        SelectedObject = gameObject;
        objectState = gameObject.GetComponent<ObjectState>();
        if (objectState.IsObjectSelected != true)
        {
            if (objectState != null)
            {
                objectState.IsObjectSelected = true;
            }
        }
        else
        {
            Deselect(gameObject);
        }
        /// to do
        /// Database 
    }
    void Deselect(GameObject gameObject)
    {
        SelectedObject = gameObject;
        objectState = gameObject.GetComponent<ObjectState>();
        if (SelectedObject != null)
        {
            if (objectState != null)
            {
                objectState.IsObjectSelected = false;
                outline.OutlineWidth = 0;
            }
            SelectedObject = null;
        }
    }
}