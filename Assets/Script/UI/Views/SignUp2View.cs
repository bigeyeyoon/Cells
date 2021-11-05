using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignUp2View : View
{

    private static SignUp2View m_instance;
    public static SignUp2View GetInstance() { if (m_instance == null) m_instance = new SignUp2View(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.SIGNUP2;

    }

    private void Update()
    {
        if (Input.touchCount > 1 || Input.GetMouseButtonDown(0) )
        {
            UIManager.Show<AvatarSelectionView>();
        }
    }


}
