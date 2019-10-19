using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

//Name SarmadSiddiqi
//ID 300978624
public class CloudController : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
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
        Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        switch (SceneManager.GetActiveScene().name) //Used SwitchCase to switch directions between levels
        {
            case "Main":
                horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
                verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

                float randomXPosition = Random.Range(boundary.Left, boundary.Right);
                transform.position = new Vector2(randomXPosition, Random.Range(boundary.Top, boundary.Top + 2.0f));
                break;

            case "Level2":

                horizontalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
                verticalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

                float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
                transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomYPosition);
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
        { //Used SwitchCase to switch Reset's

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
