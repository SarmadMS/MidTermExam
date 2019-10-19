using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Name SarmadSiddiqi
//ID 300978624
public class OceanController : MonoBehaviour
{
    public float Speed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;

    // Start is called before the first frame update
    void Start()
    {
        //Reset();
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
        switch (SceneManager.GetActiveScene().name)
        { //Used SwitchCase to switch directions between levels

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
        { //Used SwitchCase to switch Reset's

            case "Main":
                transform.position = new Vector2(0.0f, resetPosition);
                break;

            case "Level2":
                transform.position = new Vector2(resetPosition, 0.0f);
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
                if (transform.position.y <= resetPoint)
                {
                    Reset();
                }
                break;

            case "Level2":
                if (transform.position.x <= resetPoint)
                {
                    Reset();
                }
                break;


        }
      
    }
}
