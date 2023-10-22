using UnityEngine;
public class DontDestroyThisGameObjectOnLoad : MonoBehaviour
{
    ///summary
    ///this script is used in every scene in which vuforia is running, where if the user presses the go back move/button, the app should inform the user to go back to the GUI scene <summary>
    /// </summary>
    void Awake()
{
        // Make the GameObject persist across scenes
        DontDestroyOnLoad(this.gameObject);
}
}
