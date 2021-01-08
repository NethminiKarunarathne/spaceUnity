using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    private int count;

    public Text countText;
    public Text winText;

    private Rigidbody2D rBody;
    void Start()
    {
        count = 0;
        countText.text = "";
        winText.text = "";
        //handle to the rigidbody
        rBody = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {   
        //a,d or right arrow,left arrow
        float horizontalInput = Input.GetAxis("Horizontal");
        //w,s or up arrow ,down arrow
        float verticalInput = Input.GetAxis("Vertical");

        rBody.AddForce(new Vector2(horizontalInput, verticalInput) * speed);
    }
   void OnTriggerEnter2D(Collider2D target)
    {
       if (target.gameObject.CompareTag("PickUp"))
        {
            Destroy(target.gameObject);
            Count();
        }//ontrigger
    }
    void Count()
    {
        count++;
        countText.text = "Count: " + count.ToString();

        if(count >= 8)
        {
            winText.text = "You won!!!";
        }
    }//count



}//class
