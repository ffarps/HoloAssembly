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
    public float maxOutlineWitdh = 10f;
    readonly float DistanceToObject = 10f;
    ObjectState ObjectState;
    Outline outline;
    GameObject HoveredObject;
    GameObject SelectedObject;
    bool disableOutline = false;
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
            OnHoverExit();
        }
    }
    void OnHover(RaycastHit hit)
    {
        GameObject newHoveredObject = hit.collider.gameObject;
        if (HoveredObject != newHoveredObject)
        {
            HoveredObject = newHoveredObject;
            textMeshProUGUI.text = HoveredObject.name;
            disableOutline = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectedObject != HoveredObject)
            {
                Select(HoveredObject);
            }
            else
            {
                Deselect();
            }
        }
        else
        {
            disableOutline = true;
        }
    }
    void OnHoverExit()
    {
        if (disableOutline)
        {
            textMeshProUGUI.text = "";
            outline.OutlineWidth = 0;
        }
    }
    void Select(GameObject gameObject)
    {
        SelectedObject = gameObject;
        ObjectState objectState = gameObject.GetComponent<ObjectState>();
        if (objectState != null)
        {
            objectState.IsObjectSelected = true;
            Debug.LogWarning("Object " + SelectedObject.name + " Selected");
        }
        /// to do
        /// Database 
    }
    void Deselect()
    {
        if (SelectedObject != null)
        {
            outline.OutlineWidth = 0;
            ObjectState objectState = gameObject.GetComponent<ObjectState>();
            if (objectState != null)
            {
                objectState.IsObjectSelected = false;
            }
            Debug.LogWarning("Object " + SelectedObject.name + " Deselected");
            SelectedObject = null;
        }
    }
}