using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float jumpforce;
    private bool isJumping;
    private Rigidbody2D rb;
    private Animator myAnimator;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        // jumpforce = 5;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && isJumping == false) {
            rb.velocity = new Vector3(0, jumpforce, 0);
            isJumping = true;
        }

        myAnimator.SetBool("Grounded", isJumping);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "obstacle") {
            gameManager.GameOver();
        }
    }
}
