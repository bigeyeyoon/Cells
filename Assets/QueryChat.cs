using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueryChat : Push
{
    public Button ProceedButton;
    public Button CancelButton;
    private static QueryChat m_instance;
    public static QueryChat GetInstance() { if (m_instance == null) m_instance = new QueryChat(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = PushType.QUERY_CHAT;

        CancelButton.onClick.AddListener(() => { PushUIManager.Hide(); });
    }


}
