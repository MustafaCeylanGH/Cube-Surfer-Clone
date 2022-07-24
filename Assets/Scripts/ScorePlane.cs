using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlane : MonoBehaviour
{
    [SerializeField] private int planeIndex;
    [SerializeField] private GameObject yourScoreImg;
    private GameManager gameManager;
    private PlayerController playerController;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MainCube")
        {
            if (playerController.isPlayerStop)
            {
                gameManager.score *= planeIndex-1;
                yourScoreImg.SetActive(true);
                gameManager.yourScoreText.text= "Your Score: " + gameManager.score.ToString();
            }          
        }        
    }
}
