using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Transform : MonoBehaviour
{
    private Transform player;
    public Cam_Move Cam;
    public float m_fMoveSpeed = 1.0f;
    public float m_fRotationSpeed = 1.0f;
    public float m_fMaxJumpHeight = 5.0f;
    public float m_fGravity = 5.0f;
    private float m_fJumpSpeed = 0.0f;

    private bool m_bIsJumping;
    private bool m_bIsJumpingUp;
    private bool m_bIsJumpingDown;

    private Vector3 m_vScale = new Vector3(1f, 1f, 1f);
    private Vector3 m_vDir = new Vector3(0f, 0f, 1f);
    private Vector3 m_vPos = new Vector3(0f, 0f, 0f);

    public void Initialize()
    {
        player = gameObject.transform;
    }

    //업데이트 함수
    public void UpdateComponent()
    {

        if (PL_State.Check_Walk()) Walk();
        if (PL_State.Check_Jump()) Jump();

        
    }

    void Walk()
    {
        Vector3 input = new Vector3(PL_KeyInput.joystick.Horizontal, 0, PL_KeyInput.joystick.Vertical);
        float cameraHeading = Cam.rotation.y;

        Quaternion controlRotation = Quaternion.Euler(0, cameraHeading, 0);
        var RotatedMoveInputs = controlRotation * input;

        var motion = RotatedMoveInputs * m_fMoveSpeed * Time.deltaTime;


        transform.position += motion;


        float controlsFacing = Mathf.Atan2(RotatedMoveInputs.x, RotatedMoveInputs.z) * Mathf.Rad2Deg;
        float myCurrentHeading = transform.eulerAngles.y;
        myCurrentHeading = Mathf.MoveTowardsAngle(myCurrentHeading, controlsFacing, m_fRotationSpeed);

        transform.rotation = Quaternion.Euler(0, myCurrentHeading, 0);

        
    }

    void Jump()
    {

        if (m_bIsJumping) {
            Vector3 vMovement = new Vector3();
            if (m_vPos.y < m_fMaxJumpHeight)
            {

                vMovement.y += (m_fJumpSpeed * Time.deltaTime) - (m_fGravity * Time.deltaTime);
                //movement.y = Mathf.Clamp(movement.y, maxFall * -1, maxFall * 10);

            }

            if (m_fJumpSpeed > 0)
            {
                m_bIsJumpingUp = true;
                m_fJumpSpeed -= m_fGravity * Time.deltaTime;
            }
            if (m_fJumpSpeed < 0)
            {
                m_fJumpSpeed = 0;
                if (m_bIsJumpingUp) m_bIsJumpingDown = true;
                if (m_bIsJumpingDown) m_bIsJumping = m_bIsJumpingDown = false;
            }
            m_vPos += vMovement;
        }

        else
        {
            m_fJumpSpeed = 20.0f;
            m_bIsJumping = true;
        }


    }

    void UpdateTransform()
    {
        player.transform.position = m_vPos;
        player.transform.rotation = Quaternion.Euler(m_vDir);
        player.transform.localScale = m_vScale;
    }

    //Get 함수
    public Vector3 Get_Scale() { return m_vScale; }
    public Vector3 Get_Pos() { return m_vPos; }

    public Vector3 Get_Dir() { return m_vDir; }

    //Set 함수
    public void Set_Pos(Vector3 vPos) { m_vPos = vPos; }

    public void Set_Dir(Vector3 vDir) { m_vDir = vDir; }

}
