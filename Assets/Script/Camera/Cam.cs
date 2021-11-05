using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    Cam_KeyInput KeyInput;
    Cam_Move Move;
    // Start is called before the first frame update
    void Start()
    {
        KeyInput = GetComponent<Cam_KeyInput>();
        Move = GetComponent<Cam_Move>();

        KeyInput.Initialize();
        Move.Initialize();

    }

    // Update is called once per frame
    void Update()
    {
        KeyInput.UpdateComponent();
        Move.UpdateComponent();

    }
}
