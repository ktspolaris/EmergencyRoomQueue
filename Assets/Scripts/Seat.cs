using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public bool isOccupied;
    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Patient")
    //    {
    //        isOccupied = false;
    //    }
    //}


}
