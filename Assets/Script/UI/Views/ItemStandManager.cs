using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandManager : MonoBehaviour
{
    public GameObject ItemStandUIPrefab;

    private static ItemStandManager m_instance;

    public static ItemStandManager GetInstance() { if (m_instance == null) m_instance = new ItemStandManager(); return m_instance; }


    [SerializeField] private List<ItemStandUI> ItemStands = new List<ItemStandUI>(); //모든 메뉴를 저장한 리스트

    private void Awake()
    {
        m_instance = this;

        //for (int i = 0; i< DataManager.itemstands.Count; i++)
        //{
        //    GameObject go = Instantiate(ItemStandUIPrefab, gameObject.transform, true);
        //    go.transform.position = DataManager.itemstands[i].location;
        //    go.GetComponent<ItemStandUI>().data = DataManager.itemstands[i];
        //}

        
        for (int i = 0; i< ItemStands.Count; i++)
        {
            ItemStands[i].Show();
        }
    }

    public static void Show()
    {
        for (int i = 0; i < m_instance.ItemStands.Count; i++)
        {
            m_instance.ItemStands[i].Show();
        }
    }
    public static void Stop()
    {

        for (int i = 0; i < m_instance.ItemStands.Count; i++)
        {
            m_instance.ItemStands[i].Hide();
        }
    }
}
