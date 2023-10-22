using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManagerScript : MonoBehaviour
{
    /// <summary>
    /// This class handles the interaction between objects and a cast ray
    /// 
    /// ffarps October 2023
    /// </summary>
    public Transform MainCameraObject;
    float distanceToObject = 10f;
    public TextMeshProUGUI textMeshProUGUI;
    Outline outline;
    public Material originalMaterial;
    bool hasAnyObjectBeenSelected = false;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up * distanceToObject, Color.green);
        RaycastHit hit;
        //this will detect if the game object is hit by the ray
        if (Physics.Raycast(ray, out hit, distanceToObject))
        {
            //action to be perform by selecting the Interactible object
            OnHover(hit);
            //Debug.Log("O objeto "+hit.transform.name+ " foi colidido");
        }
        else if (hit.collider == null && hasAnyObjectBeenSelected)
        {
            OnExit();
        }
    }
    void OnHover(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent<Outline>(out outline))
        {
            while (outline.OutlineWidth < 5)
            {
                outline.OutlineWidth++;
            }
            hasAnyObjectBeenSelected = true;
            textMeshProUGUI.text = hit.transform.name;
            if(Input.GetMouseButtonDown(0))
            {
                Debug.LogWarning("click!");
            }
        }
    }
    void OnExit()
    {
        textMeshProUGUI.text = "";
        while (outline.OutlineWidth > 0)
        {
            outline.OutlineWidth--;
        }
    }
    void OnSelect()
    {

    }
    void OnDeselect()
    {

    }
}