using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class IslandController : MonoBehaviour
{
    public float Speed = 0.05f;


    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void Move()
    {
        switch(SceneManager.GetActiveScene().name) {

            case "Main":
                Vector2 newPosition = new Vector2(0.0f, Speed);
            Vector2 currentPosition = transform.position;
            currentPosition -= newPosition;
            transform.position = currentPosition;

            break;

        case "Level2":

                Vector2 newPosition2 = new Vector2(Speed, 0.0f);
            Vector2 currentPosition2 = transform.position;
            currentPosition2 -= newPosition2;
            transform.position = currentPosition2;
            break;


        }
       
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        switch (SceneManager.GetActiveScene().name)
        {

            case "Main":
                float randomXPosition = Random.Range(boundary.Left, boundary.Right);
                transform.position = new Vector2(randomXPosition, boundary.Top);
                break;

            case "Level2":
                float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
                transform.position = new Vector2(boundary.Right, randomYPosition);
                break;


        }
       
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {

        switch (SceneManager.GetActiveScene().name)
        {

            case "Main":
                if (transform.position.y <= boundary.Bottom)
                {
                    Reset();
                }
                break;

            case "Level2":
                if (transform.position.x <= boundary.Left)
                {
                    Reset();
                }
                break;


        }
        
    }
}
