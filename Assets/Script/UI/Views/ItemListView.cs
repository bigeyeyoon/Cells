using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemListView : View
{
    public Button CloseButton;
    public GameObject Content;
    //public List<ItemInfoPanel> ItemInfoPanels; 
    private static ItemListView m_instance;
    public static ItemListView GetInstance() { if (m_instance == null) m_instance = new ItemListView(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.ITEM_LIST;

        CloseButton.onClick.AddListener( () => CloseView());
    }
    
    private void CloseView()
    {
        UIManager.Show<WorldView>();
        ItemStandManager.Show();
    }




}
