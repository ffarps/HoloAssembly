using TMPro;
using UnityEngine;
public class InteractionManagerScript : MonoBehaviour
{
    public Transform MainCameraObject;
    public float distance;
    public TextMeshProUGUI textMeshProUGUI;
    public Material highlightMaterial;
    GameObject selectedObject;
    public Material originalMaterial;
    bool hasAnyObjectBeenSelected = false;
    void Update()
    {
        Ray ray = new Ray(MainCameraObject.position, MainCameraObject.forward);
        Debug.DrawRay(MainCameraObject.position, -MainCameraObject.up * distance, Color.green);

        RaycastHit hit;
        //this will detect if the game object is hit by the ray
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Interactive"))
            {
                hasAnyObjectBeenSelected = true;
            }
            textMeshProUGUI.text = hit.transform.name;

            //action to be perform by selecting the Interactible object
            //Debug.LogWarning("O objeto "+hit.transform.name+ " foi colidido");
        }
        else if (hit.collider == null && hasAnyObjectBeenSelected)
        {
            textMeshProUGUI.text = "";
        }
    }
}