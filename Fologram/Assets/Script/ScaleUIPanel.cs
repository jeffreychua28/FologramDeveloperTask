using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// UI Panel Scale Script
/// Functions: Maintain Ratio, update other sliders, Send Vector3 to Scale Manager
/// 
/// Important!!!
/// 0 = x
/// 1 = y
/// 2 = z
/// 
/// </summary>
public class ScaleUIPanel : MonoBehaviour
{

    public Slider[] axisScale;

    //scale ratio for uniform scaling(x,y,z)
    float[] persistScale = new float[3];

    public Toggle uniform;
    public Transform mainObj;

    bool initialSetup;

    private void OnEnable()
    {
        //get the current scale and showcase in slider
        initialSetup = true;
        axisScale[0].value = mainObj.localScale.x;
        axisScale[1].value = mainObj.localScale.y;
        axisScale[2].value = mainObj.localScale.z;
        initialSetup = false;
    }

    public void valueChange(int id)
    {
        if (initialSetup) return;
        float scale = axisScale[id].value;
        
        if (uniform.isOn)
        {
            //maintaining the right ratio while uniformly scaling
           float ratioDivider = persistScale[id];
           float ratio = scale / ratioDivider;

           for(int i = 0; i < axisScale.Length; i++)
            {
                //axis value should scale while maintaining object ratio
                axisScale[i].value = persistScale[i] * ratio;
            }
        }

        Vector3 scale_V3 = new Vector3(axisScale[0].value, axisScale[1].value, axisScale[2].value);
        ScaleManager.instance.updateModel(scale_V3);
    }

    public void toggleChange(bool id)
    {
        if (id)
        {
            for(int i = 0; i < persistScale.Length; i++)
            {
                persistScale[i] = axisScale[i].value;
            }
        }
    }
}
