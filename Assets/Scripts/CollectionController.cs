using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    [SerializeField] private Transform mainCube;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        transform.position = new Vector3(mainCube.position.x, 0.5f, mainCube.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            gameManager.ScoreUp();
            Destroy(other.gameObject);
        }
    }

}
