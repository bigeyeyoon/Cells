using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cam_KeyInput : MonoBehaviour
{
    Touch touch;
    Vector2 m_vPrevMousePos;

    // Start is called before the first frame update
    public void Initialize()
    {
    }

    // Update is called once per frame
    public void UpdateComponent()
    {
        if (EventSystem.current.IsPointerOverGameObject() || PL_KeyInput.joystick.Direction != Vector2.zero) return;
        if (true)
        {
            int nTouch = Input.touchCount;


            if (nTouch == 1)
            {
                //Rotate

                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = Input.GetTouch(0).deltaPosition.x / ((float)Screen.width / 2);
                    float deltaY = Input.GetTouch(0).deltaPosition.y / ((float)Screen.height / 2);
                    Vector3 vDeltaRot = new Vector3(deltaY, deltaX, 0.0f);
                    GetComponent<Cam_Move>().Rotate(vDeltaRot);

                }
            }

            else if (nTouch == 2)
            {
                //Zoom

                if ((Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved))
                {
                    Vector2 vTouchPrevPos0 = Input.touches[0].position - Input.touches[0].deltaPosition;
                    Vector2 vTouchPrevPos1 = Input.touches[1].position - Input.touches[1].deltaPosition;

                    float fPrevTouchMagnitude = (vTouchPrevPos0 - vTouchPrevPos1).magnitude;
                    float fCurTouchMagnitude = (Input.touches[0].position - Input.touches[1].position).magnitude;

                    float fDeltaMagniTude = fCurTouchMagnitude - fPrevTouchMagnitude;

                    GetComponent<Cam_Move>().Zoom(fDeltaMagniTude);

                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 vNewMousePos = Input.mousePosition;
                m_vPrevMousePos = vNewMousePos;
            }

            else if (Input.GetMouseButton(0))
            {
                Vector2 vNewMousePos = Input.mousePosition;
                Vector2 vDeltaPos = m_vPrevMousePos - vNewMousePos;
                float deltaX = vDeltaPos.x / ((float)Screen.width) * 90;
                float deltaY = vDeltaPos.y / ((float)Screen.height) * 90;
                GetComponent<Cam_Move>().Rotate(new Vector3(deltaY, deltaX, 0.0f));
                m_vPrevMousePos = vNewMousePos;
            }

            if(Input.GetAxis("Mouse ScrollWheel") != 0)
            {

                GetComponent<Cam_Move>().Zoom(Input.GetAxis("Mouse ScrollWheel"));


            }

        }



    }


}
