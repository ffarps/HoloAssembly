using TMPro;
using UnityEngine;
public class InteractionManagerScript : MonoBehaviour
{
    public Transform MainCameraObject;
    public float distance;
    public TextMeshProUGUI textMeshProUGUI;
    //public Material highlightMaterial;
    Outline outline;
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
            //estes ifs podem nao fazer sentido
            if (outline != null)
            {
                if (outline.transform != hit.transform)
                {
                    outline = null;
                }
            }
            if (hit.transform.TryGetComponent<Outline>(out outline))
            {
                while (outline.OutlineWidth < 10)
                {
                    outline.OutlineWidth++;
                }
                hasAnyObjectBeenSelected = true;
                textMeshProUGUI.text = hit.transform.name;
            }
            //if (hit.collider.CompareTag("Interactive"))
            //action to be perform by selecting the Interactible object
            //Debug.LogWarning("O objeto "+hit.transform.name+ " foi colidido");
        }
        else if (hit.collider == null && hasAnyObjectBeenSelected)
        {
            textMeshProUGUI.text = "";
            while (outline.OutlineWidth > 0)
            {
                outline.OutlineWidth--;
            }
        }
    }
}