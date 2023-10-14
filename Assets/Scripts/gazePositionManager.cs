using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazePositionManager : MonoBehaviour
{
    private void Awake()
    {
        //Debug.Log(Screen.width); Debug.Log(Screen.height);
        var phoneCenterOffsetWidth = Screen.width/2;//Debug.Log(phoneCenterOffsetWidth);
        var phoneCenterOffsetHeight = Screen.height/2;//Debug.Log(phoneCenterOffsetHeight);
        transform.localPosition= new Vector3(phoneCenterOffsetWidth, phoneCenterOffsetHeight);
    }
}
