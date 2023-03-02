using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangleMovement : MonoBehaviour
{
    private Vector3 targetPoint;
    public float moveSpeed = 5f;
    public GameObject pointPrefab;


    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //for random target point generation
            targetPoint = new Vector3(Random.Range(-8,8),Random.Range(4,-4), 0f);

            //for spawning the targetpoint prefab
            GameObject point = Instantiate(pointPrefab, targetPoint, Quaternion.identity);

            //For destroying the pointprefab after 2 seconds!
                Destroy(point, 2f);

            // Face towards the target point
            transform.up = targetPoint - transform.position;

        }

            //for moving the triangle to it cutrrent position to the point which will spawn randomly!
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }
}
