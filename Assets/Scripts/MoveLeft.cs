using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{   
    // Velocidade de movimentação
    public float speed;

    // Ponto em que o inimigo será destruído
    public float end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        // Se o game object for o inimigo, ele será destruído ao atingir a posição end
        if (gameObject.tag == "obstacle") {
            if (transform.position.x <= end) {
                Destroy(gameObject);
            }         
        }
        if (gameObject.tag == "gel") {
            if (transform.position.x <= end) {
                Destroy(gameObject);
            }         
        }
    }
}
