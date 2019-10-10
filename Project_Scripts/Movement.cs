using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2.0f;
    public static int score;
    private float timer;
    void Start()
    {
        //StartCoroutine(Networker.instance.GetScores());
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        score = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        score = (int)timer;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = -transform.right * speed;
        }
    }

    private void PutToDatabase()
    {
        User user = new User();
        RestClient.Put("https://highscore-db5cc.firebaseio.com/" + score + ".json", user);
    }

    private void Tuhoa()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("HighScores");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            
            PutToDatabase();
            Tuhoa();
            //StartCoroutine(Networker.instance.UpdateHighScore(score));
            
        }
    }

}
