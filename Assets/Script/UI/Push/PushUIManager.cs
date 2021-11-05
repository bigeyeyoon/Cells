using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PushType
{
    QUERY_ITEMLIST,
    QUERY_CHAT
}

public class PushUIManager : MonoBehaviour
{
    private static PushUIManager m_instance;

    public static PushUIManager GetInstance() { if (m_instance == null) m_instance = new PushUIManager(); return m_instance; }

    private Push _currentView; //���� �������� �޴�

    [SerializeField] private List<Push> _views = new List<Push>(); //��� �޴��� ������ ����Ʈ

    public PushType GetCurrentViewMode()
    {
        return _currentView.viewType;
    }


    private void Awake()
    {
        m_instance = this;
        _currentView = null;
    }

    public static T GetView<T>() where T : Push
    {
        for (int i = 0; i < m_instance._views.Count; i++)
        {
            if (m_instance._views[i] is T tView) // TŸ���̸� tView�� ����
            {
                return tView;
            }
        }

        return null;
    }


    public static void Hide()
    {

                if (m_instance._currentView != null)
                {
                    m_instance._currentView.Hide();
                }

                m_instance._currentView = null;

        Debug.Log("Hide");
        Debug.Log(m_instance._currentView);
    }


    public static void Show<T>() where T : Push
    {
        for (int i = 0; i < m_instance._views.Count; i++)
        {
            if (m_instance._views[i] is T)
            {
                if (m_instance._currentView != null)
                {
                    m_instance._currentView.Hide();
                }

                m_instance._views[i].Show();

                m_instance._currentView = m_instance._views[i];
            }

        }
        Debug.Log("show");
        Debug.Log(m_instance._currentView);
    }


    public static void Show<T>(Push view) where T : View
    {
        if (m_instance._currentView != null)
        {
            m_instance._currentView.Hide();
        }
        view.Show();
        m_instance._currentView = view;

        Debug.Log("show");
    }

    private void Start()
    {
        for (int i = 0; i < _views.Count; i++)
        {
            _views[i].Initialize();
            _views[i].Hide();
        }
    }
}