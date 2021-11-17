using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : EnemyClass
{
   // private Animator anim;


    bool movingRight = true;

    public Transform groundDetection;

    public float groundDetectionLength = 2f;

    bool walking = true;

   // public CircleCollider2D awareness;

  //  public GameObject beam; 


    void Start() {
      //  anim = GetComponent<Animator>();
    }

    void walk() {
        if (walking = true)
        {


            //anim.SetBool("walking", true);


            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDetectionLength);

            if ((groundInfo.collider == false) || (groundInfo.transform.tag == "Wall"))
            {
                if (movingRight == true)
                {

                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }




        }
    }




    void Update() {

       

       

        walk();
    }   

}
