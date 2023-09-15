using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = -7;
    public float range = 5.0f;
     float interval = 1.0f;   

    Player player;


    public float randSpeed;
    float term = 0.0f;

    void Start()
    {
        //player = GameObject.Find(name: "Player").GetComponent<Player>();
        randSpeed = 0.0f;
        term = interval;
    }

    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)
        {
            if(randSpeed<0.0f)
                randSpeed = Random.Range(-50.0f, -8.0f);
            else
                randSpeed = Random.Range(8.0f, 50.0f);

            term -= interval;
        }
        transform.Translate(randSpeed * Time.deltaTime, 0, 0);
/*        if (transform.position.x < -10)
        {
            Destroy(gameObject);
            player.addScore(1);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Wall"))
        {
            randSpeed *= -1.0f;
        }
    }


}
