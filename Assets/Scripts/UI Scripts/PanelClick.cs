using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelClick : MonoBehaviour
{
    //Make sure only one panel is allowed during playing.
    public static bool PanelOpened = false;

    //Panel Objects
    public GameObject TriaPanel;
    public GameObject ICUPanel;
    public GameObject LabPanel;
    public GameObject TreatPanel;

    //Button objects
    public GameObject TriaBut;
    public GameObject ICUBut;
    public GameObject LabBut;
    public GameObject TreatBut;

    private void Start()
    {
        PanelOpened = false;
       // TriaPanel.SetActive(false);
       // ICUPanel.SetActive(false);
       // LabPanel.SetActive(false);
       // TreatPanel.SetActive(false);
    }
    private void PanelCheck()
    {
        if (PanelOpened)
        {
            Debug.Log("Panel Opened");
            TriaBut.SetActive(false);
            ICUBut.SetActive(false);
            LabBut.SetActive(false);
            TreatBut.SetActive(false);
        } 
        if (PanelOpened == false)
        {
            Debug.Log("No Current Panel");
            TriaBut.SetActive(true);
            ICUBut.SetActive(true);
            LabBut.SetActive(true);
            TreatBut.SetActive(true);
        }
    }
    //Triage panel////////////////////////////////////////////////////////////////
    public void OpenTriaPanel()
    {
        if(TriaPanel != null)
        {
            TriaPanel.SetActive(true);
            PanelOpened = true;
            PanelCheck();
        }
    }
    public void CloseTriaPanel()
    {
        TriaPanel.SetActive(false);
        PanelOpened = false;
        PanelCheck();

    }

    //ICU panel////////////////////////////////////////////////////////////////
    public void OpenICUPanel()
    {
        if (ICUPanel != null)
        {
            ICUPanel.SetActive(true);
            PanelOpened = true;
            PanelCheck();
        }
    }
    public void CloseICUPanel()
    {
        ICUPanel.SetActive(false);
        PanelOpened = false;
        PanelCheck();
    }

    //Lab panel////////////////////////////////////////////////////////////////
    public void OpenLabPanel()
    {
        if (LabPanel != null)
        {
            LabPanel.SetActive(true);
            PanelOpened = true;
            PanelCheck();
        }
    }
    public void CloseLabPanel()
    {
        LabPanel.SetActive(false);
        PanelOpened = false;
        PanelCheck();
    }

    //Treatment panel////////////////////////////////////////////////////////////////
    public void OpenTreatPanel()
    {
        if (TreatPanel != null)
        {
            TreatPanel.SetActive(true);
            PanelOpened = true;
            PanelCheck();
        }
    }
    public void CloseTreatPanel()
    {
        TreatPanel.SetActive(false);
        PanelOpened = false;
        PanelCheck();
    }
}
