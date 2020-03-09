using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumberText : MonoBehaviour
{
    //Money amount
    public static int Money = 9999999;

    //Money cost 
    public static int TriaCost = 5000;
    public static int LabCost = 4000;
    public static int TreatCost = 4000;
    public static int ICUCost = 10000;

    public static int TriaDocCost = 2000;
    public static int LabDocCost = 2000;
    public static int TreatDocCost = 2000;
    public static int ICUDocCost = 2000;

    //Doctor numbers
    public static int DocNum = 36;
    public static int TriageDoc = 1;
    public static int LabDoc = 1;
    public static int TreatDoc = 1;
    public static int ICUDoc = 1;

    //Fecilities
    public static int Fecilities;
    public static int TriaFec = 0;
    public static int LabFec = 0;
    public static int TreatFec = 0;
    public static int ICUFec = 0;


    //Showing current numbers
    public Text TriaDocNum;
    public Text LabDocNum;
    public Text TreatDocNum;
    public Text ICUDocNum;

    public Text TriaFecNum;
    public Text LabFecNum;
    public Text TreatFecNum;
    public Text ICUFecNum;

    public Text TriaQueueNum;
    public Text LabQueueNum;
    public Text TreatQueueNum;
    public Text ICUQueueNum;

    public Text TotalDoc;
    public Text TotalMoney;
    public Text Cured;
    public Text RIP;

    private void Start()
    {


    }
    private void Update()
    {
        TriaDocNum.text = TriageDoc.ToString();
        LabDocNum.text = LabDoc.ToString();
        TreatDocNum.text = TreatDoc.ToString();
        ICUDocNum.text = ICUDoc.ToString();

        TriaFecNum.text = TriaFec.ToString();
        LabFecNum.text = LabFec.ToString();
        TreatFecNum.text = TreatFec.ToString();
        ICUFecNum.text = ICUFec.ToString();

        TriaQueueNum.text = LobbyController.TriaQueue.ToString();
        LabQueueNum.text = LobbyController.LabQueue.ToString();
        TreatQueueNum.text = LobbyController.TreatQueue.ToString();
        ICUQueueNum.text = LobbyController.ICUQueue.ToString();

        TotalDoc.text = DocNum.ToString();
        TotalMoney.text = Money.ToString();
    }

}
