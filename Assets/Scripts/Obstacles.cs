using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Frequencia na qual o objeto será gerado
    float maxTime;
    float timer;
    int objModfier;
    int pwGeneration;
    float countDown;
    // Random rnd = new Random()

    // Prefabs dos inimigos
    public GameObject obstacle1;
    public GameObject gel;
    public GameObject remedio;


    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1f;
    }

    // Update is called once per frame
    void Update()
    { 
        timer += Time.deltaTime;
        maxTime = Random.Range(0.5f, 1f);

        pwGeneration = Random.Range(0,100);

        if (timer >= maxTime + Random.Range(0.18f, 0.22f)) {
            // Gera obstaculo
            GenerateObstacle();
            timer = 0;
        }

        if (pwGeneration%3==0 && timer >= maxTime + Random.Range(0.18f, 0.22f)) {
            GeneratePowerUp();
        }

        if (obstacle1.transform.position.x <= gel.transform.position.x) {
            Destroy(gel);
            Destroy(remedio);
        }

    }

    // Random de 0 a 10 -> Par vem de cima, Ímpar vem de baixo
    void GenerateObstacle() {
        
        GameObject newObstacle = Instantiate(obstacle1);
        objModfier = Random.Range(0,100);
        
        if (objModfier%2==0) {
            newObstacle.transform.position = new Vector2(transform.position.x - Random.Range(0f,2f), Random.Range(1.0f, 2.5f));
        } else {
            newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
        }     
        
    }

    void GeneratePowerUp() {

        GameObject newBuff;
        if (Random.Range(0, 100) <= 75) 
        {
            newBuff = Instantiate(gel);
        }
        else 
        {
            newBuff = Instantiate(remedio);
        }

        objModfier = Random.Range(0,100);
        if (objModfier%2==0) {
            newBuff.transform.position = new Vector2(transform.position.x - Random.Range(0f,2f) + obstacle1.transform.position.x, Random.Range(1.0f, 2.5f));
        } else {
            newBuff.transform.position = new Vector2(transform.position.x + obstacle1.transform.position.x, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "gel") {
            Destroy(gel);
        }
        else if (collision.tag == "remedio")
        {
            Destroy(remedio);
        }
    }
}
