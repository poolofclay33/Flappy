using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;                   //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?

    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody rb;               //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(new Vector3(0, upForce, 0));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
