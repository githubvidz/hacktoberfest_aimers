using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class players : MonoBehaviour
{

    Rigidbody2D rb;
    public float movespeed;
    public float rotateAmount;
    float rot;
    int score;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousPos.x < 0)
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * movespeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            score++;

            if (score >= 5)
            {
                print("Level Complete");
            }
        }
        else if (collision.gameObject.tag == "danger")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
