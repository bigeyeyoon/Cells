using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_State : MonoBehaviour
{
    private const ulong PL_DROP = 0b0000000000000000000000000000000000000000000000000000000000000001;
    private const ulong PL_IDLE = 0b0000000000000000000000000000000000000000000000000000000000000010;
    private const ulong PL_WALK = 0b0000000000000000000000000000000000000000000000000000000000000100;
    private const ulong PL_JUMP = 0b0000000000000000000000000000000000000000000000000000000000001000;

    private static ulong m_ulState = PL_DROP | PL_IDLE;

    public void Initialize()
    {


    }

    public void UpdateComponent()
    {
        if (!Check_Walk() || m_ulState >= (PL_WALK << 1))
        {
            GetComponent<Animator>().SetBool("bWalk", false);
        }

        if (Check_Walk())
        {
            GetComponent<Animator>().SetBool("bWalk", true);
        }

        if (!Check_Idle() || m_ulState >= (PL_IDLE << 1))
        {
            GetComponent<Animator>().SetBool("bIdle", false);
        }

        if (Check_Idle())
        {
            GetComponent<Animator>().SetBool("bIdle", true);
        }

        if (!Check_Jump() || m_ulState >= (PL_JUMP << 1))
        {
            GetComponent<Animator>().SetBool("bJump", false);
        }


        if (Check_Jump())
        {
            GetComponent<Animator>().SetBool("bJump", true);

        }
       
        
    }
    public static bool Check_Idle () { return MM.StateExist(m_ulState, PL_IDLE);  }
    public static void Set_Idle() { m_ulState |= PL_IDLE; }
    public static void Release_Idle() { if (Check_Idle()) m_ulState ^= PL_IDLE;}

    public static bool Check_Drop() { return MM.StateExist(m_ulState, PL_DROP); }
    public static void Set_Drop() { m_ulState |= PL_DROP;  }
    public static void Release_Drop() { if (Check_Drop()) m_ulState ^= PL_DROP;  }

    public static bool Check_Walk() { return MM.StateExist(m_ulState, PL_WALK); }
    public static void Set_Walk() { m_ulState |= PL_WALK; }
    public static void Release_Walk() { if (Check_Walk()) m_ulState ^= PL_WALK; }

    public static bool Check_Jump() { return MM.StateExist(m_ulState, PL_JUMP); }
    public static void Set_Jump() { m_ulState |= PL_JUMP; }
    public static void Release_Jump() { if (Check_Jump()) m_ulState ^= PL_JUMP; }


}
