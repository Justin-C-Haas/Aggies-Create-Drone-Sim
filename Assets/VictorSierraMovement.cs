using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VictorSierraMovement : MonoBehaviour
{

    // class members
    public bool initialized = false;
    private Vector2 direction;
    public float theta;
    private float timer = 0f;
    public int multiplier;
    private float movementSpeed = 1f;
    public int iterative = 2;
    public int iterative_static;



    // Start is called before the first frame update
    void Start()
    {
        while (!initialized) {
            
        }
        // begin direction positive x axis for 1 unit
        direction = new Vector2(1f, 0f);
        //current_pos = new Vector2(0f, 0f);
        transform.Translate(direction * movementSpeed * Time.deltaTime);
        Debug.Log("start");
        theta = (120f/180) * Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Debug.Log(timer);

        // check if 4 seconds have passed
        if (timer >= 2f)
        {

            Debug.Log("Checkpoint");

            // increment iterative variable
            iterative++;
            
            // update vectors components
            float deltax = (direction[0] * Mathf.Cos(theta) + direction[1] * Mathf.Sin(theta));
            float deltay = (direction[0] * -1f * Mathf.Sin(theta) + direction[1] * Mathf.Cos(theta));
            
            Debug.Log("deltas");
            Debug.Log(deltax);
            Debug.Log((direction[0] * Mathf.Cos(theta) + direction[1] * Mathf.Sin(theta)));
            Debug.Log(deltay);
            Debug.Log((direction[0] * -1f * Mathf.Sin(theta) + direction[1] * Mathf.Cos(theta)));

            // create new vector
            direction = new Vector2(deltax, deltay);

            // reset clock
            timer = 0;
        }

        if (iterative % 2 == 0)
        {
            multiplier = 2;
        }
        else
        {
            multiplier = 1;
        }

        // checks whether it is time to begin new pass. not complete yet
        if (iterative == iterative_static * 4)
        {
            iterative_static = iterative;
        }
      
        transform.Translate(direction[0] * multiplier * Time.deltaTime * movementSpeed, direction[1] * multiplier * Time.deltaTime * movementSpeed, 0 * Time.deltaTime * movementSpeed,  Space.Self);
        //Debug.Log(iterative);
        // Debug.Log("Timer");
        // Debug.Log(timer);
        // Debug.Log("dirx");
        // Debug.Log(direction[0]);
        // Debug.Log("diry");
        // Debug.Log(direction[1]);
    }
}


