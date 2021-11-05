using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashView : View
{
    public GameObject Buttons;
    public Button SignUp;
    public Button SignIn;

    private static SplashView m_instance;
    public static SplashView GetInstance() { if (m_instance == null) m_instance = new SplashView(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.SPLASH;

        SignUp.onClick.AddListener( () => UIManager.Show<SignUp0View>());
        Buttons.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Input.touchCount > 1 || Input.GetMouseButtonDown(0)) ShowButtons();
    }
    void ShowButtons()
    {
        Buttons.SetActive(true);
    }



}
