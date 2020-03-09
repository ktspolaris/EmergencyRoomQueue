using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Minus : MonoBehaviour
{
    public static float TriageworkTime = 5f;
    public static float ICUworkTime = 60f;
    public static float LabworkTime = 10f;
    public static float TreatworkTime = 15f;


    public float OTriageworkTime = 5f;
    public float OICUworkTime = 60f;
    public float OLabworkTime = 10f;
    public float OTreatworkTime = 15f;


    //Triage doctor add and minus.
    public void TriageDocAdd()
    {
        if (NumberText.DocNum != 0 & NumberText.TriageDoc <= 8)
        {
            NumberText.TriageDoc += 1;
            NumberText.DocNum -= 1;
            TriaWorkTime();
        }
    }
    public void TriageDocSub()
    {
        if (NumberText.TriageDoc != 0)
        {
            NumberText.TriageDoc -= 1;
            NumberText.DocNum += 1;
            TriaWorkTime();
        }
    }

    //ICU doctor add and minus
    public void ICUDocAdd()
    {
        if (NumberText.DocNum != 0 & NumberText.ICUDoc <=8)
        {
            NumberText.ICUDoc += 1;
            NumberText.DocNum -= 1;
            ICUTime();
        }
    }
    public void ICUDocSub()
    {
        if (NumberText.ICUDoc != 0)
        {
            NumberText.ICUDoc -= 1;
            NumberText.DocNum += 1;
            ICUTime();
        }
    }
    
    //Lab doctor add and minus
    public void LabDocAdd()
    {
        if (NumberText.DocNum != 0 & NumberText.LabDoc <= 8)
        {
            NumberText.LabDoc += 1;
            NumberText.DocNum -= 1;
            LabTime();
        }
    }
    public void LabDocSub()
    {
        if (NumberText.LabDoc != 0)
        {
            NumberText.LabDoc -= 1;
            NumberText.DocNum += 1;
            LabTime();
        }
    }

    // Treat doctor add and minus
    public void TreatDocAdd()
    {
        if (NumberText.DocNum != 0 & NumberText.TreatDoc <= 8)
        {
            NumberText.TreatDoc += 1;
            NumberText.DocNum -= 1;
            TreatTime();
        }
    }
    public void TreatDocSub()
    {
        if (NumberText.TreatDoc != 0)
        {
            NumberText.TreatDoc -= 1;
            NumberText.DocNum += 1;
            TreatTime();
        }
    }

    //Fecilities add and minus.
    public void TriageFecAdd()
    {
        if (NumberText.Money >= NumberText.TriaCost & NumberText.TriaFec <= 2)
        {
            NumberText.TriaFec += 1;
            NumberText.Money = NumberText.Money - NumberText.TriaCost;
            TriaWorkTime();
        }
    }
    public void TriageFecSub()
    {
        if (NumberText.TriaFec != 0)
        {
            NumberText.TriaFec -= 1;
            NumberText.Money = NumberText.Money + NumberText.TriaCost;
            TriaWorkTime();
        }
    }

    public void ICUFecAdd()
    {
        if (NumberText.Money >= NumberText.ICUDocCost & NumberText.ICUFec <= 2)
        {
            NumberText.ICUFec += 1;
            NumberText.Money = NumberText.Money - NumberText.ICUDocCost;
            ICUTime();
        }
    }
    public void ICUFecSub()
    {
        if (NumberText.ICUFec != 0)
        {
            NumberText.ICUFec -= 1;
            NumberText.Money = NumberText.Money + NumberText.ICUDocCost;
            ICUTime();
        }
    }

    public void LabFecAdd()
    {
        if (NumberText.Money >= NumberText.LabDocCost & NumberText.LabFec <= 4)
        {
            NumberText.LabFec += 1;
            NumberText.Money = NumberText.Money - NumberText.LabDocCost;
            LabTime();
        }
    }
    public void LabFecSub()
    {
        if (NumberText.LabFec != 0)
        {
            NumberText.LabFec -= 1;
            NumberText.Money = NumberText.Money + NumberText.LabDocCost;
            LabTime();
        }
    }

    public void TreatFecAdd()
    {
        if (NumberText.Money >= NumberText.TreatDocCost & NumberText.TreatFec <= 4)
        {
            NumberText.TreatFec += 1;
            NumberText.Money = NumberText.Money - NumberText.TreatDocCost;
            TreatTime();
        }
    }
    public void TreatFecSub()
    {
        if (NumberText.TreatFec != 0)
        {
            NumberText.TreatFec -= 1;
            NumberText.Money = NumberText.Money + NumberText.TreatDocCost;
            TreatTime();
        }
    }

    //WorkTimes
    public void TriaWorkTime()
    {
        TriageworkTime = OTriageworkTime / (1f + NumberText.TriaFec * 0.5f + (NumberText.TriageDoc - 1) * 0.2f);
        Debug.Log("当前Triage所需时间：" + TriageworkTime);
    }
    public void ICUTime()
    {
        ICUworkTime = OICUworkTime / (1f + NumberText.ICUFec * 1f + (NumberText.ICUDoc - 1) * 0.2f);
        Debug.Log("当前ICU所需时间：" + ICUworkTime);
    }

    public void LabTime()
    {
        LabworkTime = OLabworkTime / (1f + NumberText.LabFec * 0.4f + (NumberText.LabDoc - 1) * 0.2f);
        Debug.Log("当前Lab所需时间：" + LabworkTime);
    }
    public void TreatTime()
    {
        TreatworkTime = OTreatworkTime / (1f + NumberText.TreatFec * 0.4f + (NumberText.TreatDoc - 1) * 0.2f);
        Debug.Log("当前Lab所需时间：" + TreatworkTime);
    }

}
