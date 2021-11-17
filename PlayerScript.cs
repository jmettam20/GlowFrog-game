using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   public float playerHealth = 100; 
   public float maxSpeed; 
   Rigidbody2D myRB; 
   Animator myAnim; 
   bool facingRight; 

   bool grounded = false; 
   public float groundCheckRadius = 3f;
   public LayerMask groundLayer; 
   public Transform groundCheck; 
   public float jumpHeight; 

   public GameObject playerAttack; 

   public float attackSpeed;
   

void Start(){
   myRB = GetComponent<Rigidbody2D>();
   myAnim = GetComponent<Animator>();

   facingRight = true; 
   gameObject.tag = "BlueSlime"; 



}

void Update(){
   melee();

   
   jump();
   walk();


 

   

 }  

 // Update is called once per frame
    
   void FixedUpdate(){
      grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);

         
        

      
       }

void flip(){

   facingRight=!facingRight;
   Vector3 theScale = transform.localScale; 
   theScale.x *= -1; 
   transform.localScale = theScale; 
}

public void walk(){

   float move = Input.GetAxis("Horizontal");
            
            myAnim.SetFloat("horizontalSpeed",Mathf.Abs(move)); 

          myRB.velocity = new Vector2(move*maxSpeed,myRB.velocity.y); 

          if(move>0&&!facingRight){

            flip();
         }else if(move<0&&facingRight){

            flip(); 
         }
}    



public void melee(){
  
   if(Input.GetKeyDown("e")){
  // myAnim.SetTrigger("Melee"); 
  Debug.Log("Attacking"); 
    Instantiate(this.playerAttack, this.transform.position, this.transform.rotation);//spawn prefab
    playerAttack.transform.position = new Vector3(attackSpeed * Time.deltaTime,0);
   }
}

public void jump(){
    

    if(grounded && Input.GetKeyDown("w")){
      
      grounded = false; 
    
      myRB.AddForce(new Vector2(0,jumpHeight));
     // myAnim.SetTrigger("Jumping"); 
    }
     
   }

   void OnCollisionEnter2D(Collision2D col)
    {
       //Debug.Log("Collision");

       //blue slime damage 
       if (col.gameObject.tag =="BlueSlime"){
          //Debug.Log("CollisionWithBlueSlime");
          ///do damage 
          float blueSlimeDamage = GameObject.Find("Slime").GetComponent<SlimeScript>().damage;; 
          playerHealth = playerHealth - blueSlimeDamage;
          myRB.AddForce(new Vector2(0,jumpHeight));
       }
        
    }
}
