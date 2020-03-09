using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool IsMove;
    public float stayTime1;
    public float stayTime2;
    public float stayTime3;
  
    public int patientLv  ;
    public float maxWaittime;
    private float waitTime;
    public bool inICU;
    
    public Transform nowSeat;

    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        inICU = false;
        destination = GameObject.Find("GameObject").transform;
        IsMove = true;
        waitTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        if (IsMove)
        {
            //this.transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, destination.transform.position, speed * Time.deltaTime);

        }


        LifeManagement();
    }




    public void LifeManagement() {
        if (patientLv == 3 && !inICU)
        {
            waitTime += Time.deltaTime;

            if (waitTime >= maxWaittime)
            {
                GamePlayController.deathNum += 1;
                GameObject.Destroy(this.gameObject);
            }
        }
    }
    public void Destination() { 
    
    }


}
