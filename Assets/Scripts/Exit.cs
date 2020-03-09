using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    private int leaveNum;
    // Start is called before the first frame update
    void Start()
    {
        leaveNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patient") {
            leaveNum += 1;
        }

        GameObject.Destroy(collision.gameObject);
    }

}
