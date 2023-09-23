using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManger : MonoBehaviour
{
    public GameObject AdminPanel, StudentPanel;

    public void AdminPanelClick()
    {
        AdminPanel.SetActive(true);
    }
    public void StudentPanelClick()
    {
        StudentPanel.SetActive(true);
    }
}
