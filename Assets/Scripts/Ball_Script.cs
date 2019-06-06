using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform extraLifePowerUp;
    public Transform speedPowerUp;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gm.gameOver)
        {
            return;
        }

        if(!inPlay) { transform.position = paddle.position; }
        if(Input.GetButtonDown("Jump") && !inPlay)
        { inPlay = true;
            rb.AddForce(Vector2.up * speed); }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            Debug.Log("ball hit the bottom of the screen");

            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);



        }
       
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            Brick_Script brickScript = collision.gameObject.GetComponent<Brick_Script>();
            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {

                int randChance = Random.Range(1, 101);
                if (randChance < 20)
                {
                    Instantiate(extraLifePowerUp, collision.transform.position, collision.transform.rotation);

                }
                if (randChance > 80)
                {

                    Instantiate(speedPowerUp, collision.transform.position, collision.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);

                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(brickScript.points);
                gm.UpdateNumberOfBricks();

                Destroy(collision.gameObject);
            }
        }
    }


}
