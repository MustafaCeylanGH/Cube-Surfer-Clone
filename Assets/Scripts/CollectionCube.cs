using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCube : MonoBehaviour
{
    private Transform mainCube;
    private Transform collectionController;   
    private float scaleY;
    private bool isCubeColleted;
    private bool isCollidedScorePlane;


    private void Start()
    {
        mainCube = GameObject.Find("MainCube").transform;
        collectionController = GameObject.Find("CollectionController").transform;        

        scaleY = mainCube.localScale.y;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectionController") && !isCubeColleted)
        {
            mainCube.position = new Vector3(mainCube.position.x, mainCube.position.y + scaleY, mainCube.position.z);
            transform.position = new Vector3(mainCube.position.x, collectionController.position.y, mainCube.position.z);
            transform.SetParent(mainCube);
            isCubeColleted = true;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {            
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.SetParent(null);
            mainCube.position = new Vector3(mainCube.position.x, mainCube.position.y - scaleY, mainCube.position.z);                     
            transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z-scaleY);              
        }

        if (other.gameObject.CompareTag("ScorePlane")&&!isCollidedScorePlane)
        {
           
            isCollidedScorePlane = true;
            transform.SetParent(null);            
            transform.position = new Vector3(transform.position.x,other.gameObject.transform.position.y, other.gameObject.transform.position.z - 3*scaleY);
            transform.localScale = new Vector3(transform.localScale.x, other.gameObject.GetComponent<Transform>().localScale.y,transform.localScale.z);
        }
    }
}
