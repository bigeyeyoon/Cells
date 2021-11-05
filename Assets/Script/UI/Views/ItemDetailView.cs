using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailView : View
{
    public Button ExitButton;
    public Button BuyButton;

    private static ItemDetailView m_instance;
    public static ItemDetailView GetInstance() { if (m_instance == null) m_instance = new ItemDetailView(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.DETAIL_INFO;

        ExitButton.onClick.AddListener(() => UIManager.Show<ItemListView>());
        BuyButton.onClick.AddListener(() => PushUIManager.Show<QueryChat>());
    }
}
