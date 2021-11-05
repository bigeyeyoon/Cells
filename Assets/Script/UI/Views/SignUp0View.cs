using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignUp0View : View
{
    public Button NextButton;
    public TMP_InputField input;
    private static SignUp0View m_instance;
    public static SignUp0View GetInstance() { if (m_instance == null) m_instance = new SignUp0View(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.SIGNUP0;

        NextButton.interactable = false;
        NextButton.onClick.AddListener( () => UIManager.Show<SignUp1View>());
    }

    public void LateUpdate()
    {
        if (input.text.Length < 11) NextButton.interactable = false;
        else NextButton.interactable = true;
    }


}
