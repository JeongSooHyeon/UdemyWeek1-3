using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    TextMesh text;
    int coinCnt = 0;

    Rigidbody playerRigid;
    float speed = 8.0f;

    PoseChanger pose;

    void Start()
    {
        text = GameObject.Find(name: "Text").GetComponent<TextMesh>();
        pose = GetComponent<PoseChanger>();
        playerRigid = GetComponent<Rigidbody>();

    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            pose.changePose();
            addScore();
            Destroy(collision.gameObject);
            if(coinCnt == 4)
            {
                Clear();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // 점수 더하기
    public void addScore()
    {
        coinCnt++;
        text.text = "모은 코인 " + coinCnt + " / 4";
    }

    public void Clear()
    {
        text.text = "성공 !!";
        text.transform.position = Vector3.zero;
        text.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
    }
}
