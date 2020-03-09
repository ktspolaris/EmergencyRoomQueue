using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public GameObject patient;
    public Transform entrance;
    public float ArriveRate;
    private float timer;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ArriveRate) {
            timer = 0;
            GameObject obj = GameObject.Instantiate(patient,entrance.transform);
            //random need

            obj.GetComponent<PlayerController>().patientLv = 1;
        }
    }
}
