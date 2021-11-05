using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CategorySelectionView : View
{
    public Button NextButton;
    public float currentSelection = -1;
    public List<Button> Selectable;

    private static CategorySelectionView m_instance;
    public static CategorySelectionView GetInstance() { if (m_instance == null) m_instance = new CategorySelectionView(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.CATEGORY_SELECTION;
        Selectable = new List<Button>();
        for (int i = 0; i< transform.Find("Selectables").childCount; i++)
        {
            Selectable.Add (transform.Find("Selectables").GetChild(i).GetComponent<Button>());
            Selectable[i].onClick.AddListener(() => OnCategorySelect(i) );
        }
        

        NextButton.interactable = false;
        NextButton.onClick.AddListener(() => SceneManager.LoadScene("MarketPlace"));

    }
    private void Update()
    {
        if (currentSelection > -1)
        {
            NextButton.interactable = true;
        }
    }

    private void OnCategorySelect(int i)
    {
        currentSelection = i;
    }
}
