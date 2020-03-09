using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    public bool isAvaliable;
    private bool isWork;
    public float workTime;
    private float timer;
    private GameObject nowPatient;
    public LobbyController LC;
    public Transform Exit;
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
        workTime = Add_Minus.TreatworkTime;
    }

    private void FixedUpdate()
    {

        if (NumberText.TreatDoc <= 0)
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
      
        nowPatient.GetComponent<PlayerController>().destination = Exit.transform;
        nowPatient.GetComponent<MeshRenderer>().material = LC.leaveMaterial;
        nowPatient = null;
     
    }

    public void recivePatient()
    {
        isWork = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  Debug.Log("getpatient");

        if (collision.tag == "Patient")
        {
            recivePatient();
            nowPatient = collision.gameObject;
           
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Patient") {
    //        switch (collision.GetComponent<PlayerController>().patientLv)
    //        {
    //            case 1:

    //                break;
    //            case 2:
                  

    //                break;
    //            case 3:
                    

    //                break;

    //        }

    //    }
    //}
}
