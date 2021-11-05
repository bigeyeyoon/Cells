using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_KeyInput : MonoBehaviour
{
    [SerializeField]
    public static FixedJoystick joystick;
    [SerializeField]
    public static Joybutton joybutton;

    // Start is called before the first frame update
    public void Initialize()
    {
        GameObject go = GameObject.Find("Fixed Joystick");
        if (go == null) print("go is null");

        joystick = go.GetComponent<FixedJoystick>();

        if (joystick == null) print("joystick stick is null");
        joybutton = GameObject.Find("JoyButton").GetComponent<Joybutton>();
    }


    // Update is called once per frame
    public void UpdateComponent()
    {
        if (joystick == null) print("joystick stick is null");
        if (( joystick.Direction == Vector2.zero ))
        {
            PL_State.Set_Idle();
            PL_State.Release_Walk();

        }
        else
        {
            PL_State.Release_Idle();
            PL_State.Set_Walk();
        }


        if (joybutton.IsJoyPressed())
        {
            PL_State.Set_Jump();
        }
        else
        {
            PL_State.Release_Jump();
        }
        
    }

}
