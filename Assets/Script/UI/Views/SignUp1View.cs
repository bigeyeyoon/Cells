using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignUp1View : View
{
    public Button NextButton;
    public TMP_InputField input;
    private static SignUp1View m_instance;
    public static SignUp1View GetInstance() { if (m_instance == null) m_instance = new SignUp1View(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.SIGNUP1;

        NextButton.interactable = false;
        NextButton.onClick.AddListener(() => UIManager.Show<SignUp2View>() );
    }

    public void LateUpdate()
    {
        if (input.text.Length < 1) NextButton.interactable = false;
        else NextButton.interactable = true;
    }
}
