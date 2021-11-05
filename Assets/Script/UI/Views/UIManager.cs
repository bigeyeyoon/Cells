using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum CanvasType
{
    SPLASH,
    SIGNUP0,
    SIGNUP1,
    SIGNUP2,
    AVATAR_SELECTION,
    CATEGORY_SELECTION,
    WORLD,
    USER_INFO,
    ITEM_LIST,
    DETAIL_INFO,
    CHATTING
}

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;

    public static UIManager GetInstance() { if (m_instance == null) m_instance = new UIManager();  return m_instance;  } 

    private View _currentView; //현재 보여지는 메뉴

    [SerializeField] private View _startingView;
    [SerializeField] private List<View> _views = new List<View>(); //모든 메뉴를 저장한 리스트
    [SerializeField] private List<Button> _buttons = new List<Button>();

    public CanvasType GetCurrentViewMode()
    {
        return _currentView.viewType;
    }


    private void Awake()
    {
        m_instance = this;
        
    }

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < m_instance._views.Count; i++)
        {
            if (m_instance._views[i] is T tView) // T타입이면 tView에 저장
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>() where T : View
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


    public static void Show<T>( View view ) where T : View
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
        for (int i = 0; i< _views.Count; i++)
        {
            _views[i].Initialize();
            _views[i].Hide();
        }

        if (_startingView != null)
        {
            Show<View>(_startingView);
        }

    }
}
