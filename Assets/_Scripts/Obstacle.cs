using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] int lifeTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }


    void DestroyThis()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Player.Score++;
        }
    }
}
