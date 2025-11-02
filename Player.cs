using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player : MonoBehaviour
{
    private float playerSpeed;

    private float horizontalInput;

    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;

    private float verticalScreenLimit = -3f;

    public GameObject bulletPrefab;

    void Start()

    {
        playerSpeed = 6f;

    }

    void Update()
    {
        Movement();
        Shooting();
    }


    void Shooting()

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    void Movement()
    {
        // Read input
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        // Move player

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        // Get current position

        Vector3 pos = transform.position;

        // Wrap horizontally

        if (pos.x > horizontalScreenLimit)

            pos.x = -horizontalScreenLimit;

        else if (pos.x < -horizontalScreenLimit)

            pos.x = horizontalScreenLimit;



        // Stop vertically (stay in lower half)

        pos.y = Mathf.Clamp(pos.y, verticalScreenLimit, 0);



        // Apply position

        transform.position = pos;

    }

}
