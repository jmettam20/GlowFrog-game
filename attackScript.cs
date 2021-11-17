using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float projectileSpeed = 100f;
    public float maxLifetime = 10.00f; 

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    

    //destroy if collides w anything 
    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject); 
    }
}
