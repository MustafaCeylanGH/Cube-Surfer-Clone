using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float swipeSpeed;
    private float moveX;
    [SerializeField] private float xLeftBoundary, xRightBoundary;
    public bool isPlayerStop;
    private GameManager gameManager;    

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();       
    }

    private void Update()
    {
        PlayerMove();
        Swipe();
        MoveBoundary();
    }
    private void PlayerMove()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    private void Swipe()
    {
        moveX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Translate(moveX * swipeSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void MoveBoundary()
    {
       float xPos=Mathf.Clamp(transform.position.x, xLeftBoundary, xRightBoundary);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScorePlane"))
        {
            moveSpeed = 0;
            isPlayerStop = true;
            Time.timeScale = 0.0f;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

}
