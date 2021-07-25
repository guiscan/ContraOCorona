using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Frequencia na qual o objeto será gerado
    float maxTime;
    float timer;

    // Prefabs dos inimigos
    public GameObject obstacle1;


    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime) {
            // Gera o inimigo
            GenerateObstacle();
            timer = 0;

        }
        
    }
    void GenerateObstacle() {
        GameObject newObstacle = Instantiate(obstacle1);
        newObstacle.transform.position = transform.position;
    }
}
