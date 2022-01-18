using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float maxFallSpeed;

    public UnityEvent onWallHit;
    public UnityEvent onStart;

    Rigidbody2D myRigidbody;

    bool goingLeft;

    bool startGame;
    public bool dead;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!startGame)
            {
                startGame = true;

                myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

                onStart.Invoke();
            }

            myRigidbody.velocity = Vector2.zero;

            myRigidbody.AddForce(Vector2.up * jumpForce);
        }

        if (!goingLeft)
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
        }

        if (myRigidbody.velocity.y < -maxFallSpeed)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -maxFallSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            goingLeft = !goingLeft;

            if (!goingLeft)
            {
                transform.Rotate(new Vector3(0, -180, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, 180, 0));
            }

            onWallHit.Invoke();
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            dead = true;
            gameObject.SetActive(false);
        }
    }
}
