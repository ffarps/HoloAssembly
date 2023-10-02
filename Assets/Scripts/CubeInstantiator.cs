using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using static UnityEngine.GraphicsBuffer;

public class CubeInstantiator : DefaultObserverEventHandler
{
    //The MyPrefabInstantiator class inherits from the DefaultObserverEventHandler class, that takes care of handling events when the target is detected.At that point, the Prefab 3D model gets instantiated and gets attached on the Image Target.

    public GameObject Cube;
    GameObject NewCube;
    public Vector3 CubePosition;
    protected override void OnTrackingFound()
    {
        Debug.Log("Target Found");
        if (NewCube == null)
            InstantiateCubePrefab();
        base.OnTrackingFound();
    }
    void InstantiateCubePrefab()
    {
        if(Cube!=null)
        {
            Debug.Log("Target found!, adding content");
            NewCube = Instantiate(Cube, mObserverBehaviour.transform);
            NewCube.transform.localPosition = CubePosition;
            NewCube.SetActive(true);
        }
    }
}
