using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Move : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;
    public float m_fOffset;
    public float m_fZoomSpeed;
    public float m_fRotationSpeed;
    public float m_fPlayerHeight;
    public Vector3 m_vOffset;
    public Vector3 rotation;
    public Vector3 position;


    // Start is called before the first frame update
    public void Initialize()
    {
        m_fOffset = 6.0f;
        m_fZoomSpeed = 2.0f;
        m_fRotationSpeed = 2.0f;
        m_fPlayerHeight = 10.0f;

        m_vOffset = new Vector3(0f, -0.1f, -0.65f ) / new Vector3(0f, -0.1f, -0.65f).magnitude * m_fOffset;

        cam = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 vCamPos = player.transform.position + m_vOffset +
             new Vector3(0.0f, m_fPlayerHeight, 0.0f); //캐릭터 머리 높이 만큼 카메라를 올려줌
        transform.LookAt(player.transform);
        rotation = transform.eulerAngles;

    }

    // Update is called once per frame

    public void UpdateComponent()
    {

        Vector3 vCamPos = player.transform.position + m_vOffset +
            new Vector3(0.0f, m_fPlayerHeight, 0.0f); //캐릭터 머리 높이 만큼 카메라를 올려줌
        vCamPos.y = Mathf.Clamp(vCamPos.y, 0.05f, 100.0f); // 카메라 천장 뚫기 방지
        position = vCamPos;
        transform.position = vCamPos;

        //set camera rotation
        transform.LookAt(player.transform);

        rotation = transform.eulerAngles;
    }

    public void Rotate(Vector3 vRot)
    {

        Quaternion CamRotAngleX = Quaternion.AngleAxis(vRot.y * m_fRotationSpeed, Vector3.up);

        m_vOffset = (CamRotAngleX * m_vOffset);


        Quaternion CamRotAngleY = Quaternion.AngleAxis(vRot.x * m_fRotationSpeed, Vector3.right);
        m_vOffset = (CamRotAngleX * m_vOffset);


    }

    public void Zoom (float fDistance)
    {
        m_fOffset += fDistance * m_fZoomSpeed;
        m_fOffset = Mathf.Clamp(m_fOffset, 1.0f, 10.0f);
    }


}
