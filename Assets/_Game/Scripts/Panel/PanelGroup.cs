using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private TabGroup tabGroup;
    public int panelIndex;

    private void Awake()
    {
        panelIndex = 0;
        ShowCurrentPanel();
    }

    private void ShowCurrentPanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == panelIndex)
            {
                panels[i].gameObject.SetActive(true);
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetPageIndex(int index)
    {
        panelIndex = index;
        ShowCurrentPanel();
    }
}
