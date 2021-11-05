using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueryItemListPush : Push
{
    public Button ProceedButton;
    public Button CancelButton;
    private static QueryItemListPush m_instance;
    public static QueryItemListPush GetInstance() { if (m_instance == null) m_instance = new QueryItemListPush(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = PushType.QUERY_ITEMLIST;

        ProceedButton.onClick.AddListener( () => { ItemStandManager.Stop(); UIManager.Show<ItemListView>(); PushUIManager.Hide(); } );
        CancelButton.onClick.AddListener(() => { PushUIManager.Hide();  } );
    }


}
