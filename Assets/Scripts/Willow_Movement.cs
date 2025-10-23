using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Willow_Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 60f;
    public float sideForce = 40f;
    public float jumpForce = 15f;  
    private bool isJumping = false;
    public float gravityScale = 2.7f;
    

    void Update()
    {
        //αυτόματη κίνηση στον άξονα z
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        // κίνηση στον άξονα x με τα πλήκτρα "right" και "left"
        if (Input.GetKey("right"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("left"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        // κίνηση slide/ σμύκρινση με το πλήκτρο "down" 
        if(Input.GetKey("down")){
            transform.localScale = new Vector3(1, 1, 1);
        }
        else{
            transform.localScale = new Vector3(2, 2, 2);
        }
        //κίνηση στον άξονα y - jump με το πλήκτρο "up" (με βελτίωση κατά την κάθοδο)
        if (Input.GetKeyDown("up") && !isJumping)  
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isJumping = true;
        }    
        if (rb.velocity.y < 0){
                rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
            }
    } 
    //συνάρτηση που αποτρέπει πολλαπλά jumps     
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
