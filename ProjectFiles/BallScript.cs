using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float Bouncestrength;
    public LogicScript logic;
    public bool ballIsalive = true;

     // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ballIsalive){
            myRigidbody.velocity = Vector2.up*Bouncestrength;
        }
        if(transform.position.y < -3.7 || transform.position.y > 3.7){
            logic.CheckScore();
            logic.UpdateMedal();
            logic.gameOver();
            ballIsalive = false;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision){
        logic.CheckScore();
        logic.UpdateMedal();
        logic.gameOver();
        ballIsalive = false;
    }
}
