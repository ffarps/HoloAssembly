using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManagerScript : MonoBehaviour
{
    /// <summary>
    /// This class handles the interaction between objects and a cast ray
    /// ffarps October 2023
    /// </summary>
    /// 
    public DatabaseManagerScript Database;
    [Header("GameObjects to attach")]
    public Transform MainCameraObject;
    [Header("GameObjects (to not attach)")]
    public ObjectState objectState;
    public Outline outline;
    public GameObject HoveredObject;
    public GameObject SelectedObject;
    [Header("Text Mesh Pro UI to attach")]
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI selectionInfo;
    public Image GazeCursor;
    public Color originalGazeColor = new(255, 255, 255);
    public Color GazeColor = new(254, 102, 1);
    [Header("Values that can be modified")]
    public float DistanceToObject = 10f;
    public short minOutlineWidth = 0;
    public short maxOutlineWidth = 5;


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
        outline.OutlineWidth = maxOutlineWidth;
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
            Debug.LogWarning("Hovered Object is non existant");
        }

    }
    void OnHoverExit(GameObject HoveredObject)
    {
        GazeCursor.color = originalGazeColor;
        objectState = HoveredObject.GetComponent<ObjectState>();
        if (objectState.IsObjectSelected == false)
        {
            textMeshProUGUI.text = "";
            outline.OutlineWidth = minOutlineWidth;
            HoveredObject = null;
        }
        else
        {
            textMeshProUGUI.text = "";
            outline.OutlineWidth = maxOutlineWidth;
            HoveredObject = null;
        }
    }
    void Select(GameObject gameObject)
    {
        GazeCursor.color = GazeColor;
        SelectedObject = gameObject;
        objectState = gameObject.GetComponent<ObjectState>();
        if (objectState.IsObjectSelected != true)
        {
            if (objectState != null)
            {
                objectState.IsObjectSelected = true;
                HoloDataBase dataBase = new HoloDataBase
                {
                    IsSelected = objectState.IsObjectSelected,
                    HoloName = gameObject.name,
                    HoloZone = "Zone 1"
                };
                Database._connection.Insert(dataBase);
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
        GazeCursor.color = originalGazeColor;
        SelectedObject = gameObject;
        objectState = gameObject.GetComponent<ObjectState>();
        if (SelectedObject != null)
        {
            if (objectState != null)
            {
                objectState.IsObjectSelected = false;
                outline.OutlineWidth = minOutlineWidth;
            }
            SelectedObject = null;
        }
    }
}