///Script Function: Toggles Cursor Lock for FPS control
using UnityEngine;

public class FPS_ToggleCursor : MonoBehaviour
{

    bool v_lockCursor;
    bool lockCursor
    {
        get
        {
            return v_lockCursor;
        }
        set
        {
            v_lockCursor = value;
            cursorStates(v_lockCursor);
        }
    }
    public KeyCode CursorInteraction;

    void Start()
    {
        lockCursor = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(CursorInteraction))
        {
            lockCursor = !lockCursor;
        }
    }

    //Toggles cursor lock and visibility
    void cursorStates(bool state)
    {
        if (state)
        {
            Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
            //enable head movement from first Person AIO
            GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().cameraLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
            //disable head movement from first Person AIO
            GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().cameraLock = true;
        }
    }
}
