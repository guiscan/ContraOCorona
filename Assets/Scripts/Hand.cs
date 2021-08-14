using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public float jumpforce;
    private bool isJumping;
    private Rigidbody2D rb;
    private Animator myAnimator;
    public GameManager gameManager;
    public GameObject gel;
    public float invencibleTimer;
    private int death;
    public GameObject tosse;
    public GameObject febre;
    private float timer;

    public bool isGel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        // jumpforce = 5;
        isJumping = false;
        death = 0;
        invencibleTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && isJumping == false) {
            rb.velocity = new Vector3(0, jumpforce, 0);
            isJumping = true;
        }
        myAnimator.SetBool("Grounded", isJumping);    

        if (isGel) {
            invencibleTimer -= Time.deltaTime;
            
            if (invencibleTimer <= 0) {
                isGel = false;
                invencibleTimer = 10;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "gel") {
            isGel = true;
            Score.score = Score.score + 10;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "obstacle" && isGel==false) {
            death++;
            Destroy(collision.gameObject);       
        }

        if (death==1) {
            tosse.SetActive(true);
        }

        if (death==2) {
            febre.SetActive(true);
        }

        if (death==3) {
            gameManager.GameOver();
        }

        if (isGel && collision.tag == "obstacle") {
            Score.score = Score.score + 5;
            Destroy(collision.gameObject);
        }
    }
}
