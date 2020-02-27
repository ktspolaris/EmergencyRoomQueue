using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool IsMove;
    public float stayTime;
    private float timer = 0;
    private bool cooldown = false;
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
            if (stayTime <= timer) {
                cooldown = false;
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
            Debug.Log("123");
          
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
        Debug.Log("123");
        if (IsMove)
        {
            IsMove = false;
            cooldown = true;
        }
    } 
    



}
