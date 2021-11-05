using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectionView : View
{
    public Transform Contents;
    public Button NextButton;
    public float currentSelection = -1;
    public List<Button> Selectable;


    private static AvatarSelectionView m_instance;
    public static AvatarSelectionView GetInstance() { if (m_instance == null) m_instance = new AvatarSelectionView(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.AVATAR_SELECTION;
        Selectable = new List<Button>();
        Selectable = new List<Button>();
        for (int i = 0; i < Contents.childCount; i++)
        {
            Selectable.Add(Contents.GetChild(i).GetComponent<Button>());
            Selectable[i].onClick.AddListener(() => OnCategorySelect(i));
        }

        NextButton.interactable = false;
        NextButton.onClick.AddListener(() => UIManager.Show<CategorySelectionView>());

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
