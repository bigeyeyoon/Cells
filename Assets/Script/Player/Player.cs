using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{

    public bool IsMasterClientLocal => PhotonNetwork.IsMasterClient && photonView.IsMine;
    PL_KeyInput KeyInput;
    PL_State State;
    PL_Transform Transform;
    // Start is called before the first frame update
    void Start()
    {
        
        KeyInput = GetComponent<PL_KeyInput>();
        State = GetComponent<PL_State>();
        Transform = GetComponent<PL_Transform>();


        KeyInput.Initialize();
        State.Initialize();
        Transform.Initialize();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!IsMasterClientLocal)
        //{
        //    return;
        //}
        KeyInput.UpdateComponent();
        State.UpdateComponent();
        Transform.UpdateComponent();
    }
}
