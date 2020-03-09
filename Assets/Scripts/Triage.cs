using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triage : MonoBehaviour
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
        workTime = Add_Minus.TriageworkTime;
    }

    private void FixedUpdate()
    {

        if ( NumberText.TriageDoc <= 0) {
            isAvaliable = false;
        }
        if (isWork) {
            timer += Time.deltaTime;
            if (timer >= workTime) {
                isWork = false;
               // Debug.Log("endwork");
                sendPatient();
                isAvaliable = true;
                timer = 0;
            }
        }
    }
    public void sendPatient()
    {
        nowPatient.GetComponent<PlayerController>().destination = LC.transform;
        switch (nowPatient.GetComponent<PlayerController>().patientLv)
        {
            case 1:
                LC.treatList.AddLast(nowPatient.gameObject);
                nowPatient.GetComponent<MeshRenderer>().material = LC.TreatMaterial;
              //Debug.Log("Trealist" + LC.treatList.Count);
                break;
            case 2:
                LC.labList.AddLast(nowPatient.gameObject);
                nowPatient.GetComponent<MeshRenderer>().material = LC.labMaterial;
                break;
            case 3:
                LC.labList.AddLast(nowPatient.gameObject);
                nowPatient.GetComponent<MeshRenderer>().material = LC.labMaterial;
                break;

        }
    }

    public void recivePatient()
    {
       isWork = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  Debug.Log("getpatient");

        if (collision.tag == "Patient") {
            recivePatient();
            nowPatient = collision.gameObject;
            
        }
    }
  
}
