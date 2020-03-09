using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    public bool isAvaliable;
    private bool isWork;
    public float workTime;
    private float timer;
    private GameObject nowPatient;
    public LobbyController LC;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        isAvaliable = true;
        isWork = false;

    }

    // Update is called once per frame
    void Update()
    {
        workTime = Add_Minus.LabworkTime;
        if (NumberText.LabDoc <= 0)
        {
            isAvaliable = false;
        }

        if (isWork)
        {
            timer += Time.deltaTime;
            if (timer >= workTime)
            {
                sendPatient();

                isWork = false;
              
                isAvaliable = true;
                timer = 0;
            }
        }
    }

    public void sendPatient()
    {
        Debug.Log("leavelab");
        switch (nowPatient.GetComponent<PlayerController>().patientLv)
        {
            case 1:

                break;
            case 2:
                LC.treatList.AddLast(nowPatient);
                nowPatient.GetComponent<MeshRenderer>().material = LC.TreatMaterial;
                break;
            case 3:
                LC.emergencyList.AddLast(nowPatient);
                nowPatient.GetComponent<MeshRenderer>().material = LC.emergencyMaterial;
                break;
        }
        nowPatient.GetComponent<PlayerController>().destination = LC.transform;
     
        nowPatient = null;
        
    }

    public void recivePatient()
    {
        isWork = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         Debug.Log("getpatient");

        if (collision.tag == "Patient" && collision.gameObject.GetComponent<PlayerController>().patientLv != 1)
        {
            recivePatient();
            nowPatient = collision.gameObject;
           
        }
    }
}
