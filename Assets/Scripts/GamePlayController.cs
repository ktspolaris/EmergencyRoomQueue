using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public GameObject patient;
    public Transform entrance;
    public float ArriveRate;
    private float timer;

 
    public static int deathNum;
    private float lvProb;
  //  private bool isFull;
    private int patientNum;
    // Start is called before the first frame update
    void Start()
    {
        deathNum = 0;
        //isFull = false;
        GameObject obj = GameObject.Instantiate(patient,entrance.transform);
        patientNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= ArriveRate) {
            timer = 0;
            if (patientNum <= 50)
            {
                GameObject obj = GameObject.Instantiate(patient, entrance.transform);
                patientNum += 1;
                //random need

                obj.GetComponent<PlayerController>().patientLv = GetRandomLv();
            }
        }
    }

     private int GetRandomLv() {
        int lvNum = 0;
        lvProb = Random.value;
        if (lvProb <= 0.7) {
            lvNum = 1;
        }
        else if (lvProb > 0.7 && lvProb <= 0.9) {
            lvNum = 2;
        }
        else if (lvProb > 0.9 && lvProb <= 1) {
            lvNum = 3;
        }


        return lvNum;
    }

    
}
