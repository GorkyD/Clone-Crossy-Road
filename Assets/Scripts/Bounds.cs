using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float lerpTime;
    private float currentLerpTime;
    private float perc = 1;

    [HideInInspector] public bool justJump;
    private bool firstInput;

    private Vector3 endPosition;
    private Vector3 currentPosition;

    [SerializeField] private TerrainGenerator terrainGenerator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (perc == 1)
            {
                lerpTime = 2;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
        }

        currentPosition = gameObject.transform.position;        

        if (Input.GetKeyDown(KeyCode.W) && endPosition == gameObject.transform.position)
        {
            Move(new Vector3(0, 0, 0), new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
        }
        if (Input.GetKeyDown(KeyCode.S) && endPosition == gameObject.transform.position)
        {
            Move(new Vector3(0, 180, 0), new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
        }
        if (Input.GetKeyDown(KeyCode.D) && endPosition == gameObject.transform.position)
        {
            Move(new Vector3(0, 90, 0), new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
        }
        if (Input.GetKeyDown(KeyCode.A) && endPosition == gameObject.transform.position)
        {
            Move(new Vector3(0, -90, 0), new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
        }

        if (firstInput == true)
        {
            currentLerpTime += Time.deltaTime * 4f;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(currentPosition,endPosition,perc);
            if (perc > 0.8)
            {
                perc = 1;
            }
            if(Mathf.Round(perc) == 1)
            { 
                justJump = false;
            }
        }     
    }
    private void Move(Vector3 euler, Vector3 position)
    {

        gameObject.transform.localEulerAngles = euler;
        endPosition = position;
        terrainGenerator.SpawnTerrain(false, gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }
}


