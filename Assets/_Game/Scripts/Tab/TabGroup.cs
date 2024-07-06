using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private List<TabButton> tabButtons;
    [SerializeField] private Color tabIdle, textIdle, tabHover, textHover, tabActive, textActive;
    [SerializeField] private TabButton selectedTab;
    [SerializeField] private List<GameObject> objectToSwap;
    [SerializeField] private PanelGroup panelGroup;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTab();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
            button.text.color = textHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTab();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTab();
        button.background.color = tabActive;
        button.text.color = textActive;

        //Swap panel
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectToSwap.Count; i++)
        {
            if (i == index)
            {
                objectToSwap[i].SetActive(true);
                if (panelGroup != null)
                {
                    panelGroup.SetPageIndex(objectToSwap[i].transform.GetSiblingIndex());
                }
            }
            else
            {
                objectToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTab()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            if (selectedTab != null && tabButton == selectedTab) { continue; }
            tabButton.background.color = tabIdle;
            tabButton.text.color = textIdle;
        }
    }

}
