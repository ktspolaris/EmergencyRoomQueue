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

    private float timer = 0;
    private bool cooldown = false;
    private bool cooldown2 = false;
    private bool cooldown3 = false;

    // Start is called before the first frame update
    void Start()
    {
        IsMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown) {
            timer += Time.deltaTime;
           // Debug.Log(timer.ToString());
            if (stayTime1 <= timer) {
                Debug.Log("move");
                cooldown = false;
                timer = 0;
                IsMove = true;
            }
        }
        if (cooldown2)
        {
            timer += Time.deltaTime;
            if (stayTime2 <= timer)
            {
                cooldown2 = false;
                timer = 0;
                IsMove = true;
            }
        }
        if (cooldown3)
        {
            timer += Time.deltaTime;
            if (stayTime3 <= timer)
            {
                cooldown3 = false;
                timer = 0;
                IsMove = true;
            }
        }
        if (IsMove)
        {
            this.transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
        }

        Ray2D ray = new Ray2D(transform.position + Vector3.right * 0.2f, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right * 0.2f, transform.right);
        if (hit.collider.tag == "Patient") {
            Debug.DrawLine(ray.origin, hit.point,Color.red);
           // Debug.Log("123");
          
            if (hit.distance <= 0.1f)
            {
                IsMove = false;
            }
            else
            {
                IsMove = true;
            }
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("123");
        if (IsMove)
        {
            IsMove = false;
            if (collision.tag == "Counter1")
            {
                
                cooldown = true;
            }
            if (collision.tag == "Counter2")
            {
                cooldown2 = true;
            }
            if (collision.tag == "Counter3")
            {
                cooldown3 = true;
            }

        }
    }


    public void LifeManagement() { 
    
    }
    public void Destination() { 
    
    }


}
