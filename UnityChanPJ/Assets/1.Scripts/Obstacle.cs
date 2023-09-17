using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
     float interval = 1.0f;   

    public float randSpeed;
    float term = 0.0f;

    void Start()
    {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            randSpeed *= -1.0f;
        }
    }
}
