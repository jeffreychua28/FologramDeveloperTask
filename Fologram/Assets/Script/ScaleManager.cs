using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script changes the scale of an object with the data sent from the UI Changes
public class ScaleManager : MonoBehaviour
{
    public static ScaleManager instance;
    public Transform mainObject;

    void Start()
    {
        instance = this;
    }

    public void updateModel(Vector3 scale)
    {
        mainObject.localScale = scale;
    }
}
