using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BallScript ball;
    public int points;// Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 && ball.ballIsalive)
        {
        logic.addScore(points);
        }
    }
}

