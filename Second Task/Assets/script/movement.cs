using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector3 StartPosition;
    public Vector3 EndPosition;
    public float Height;
    public float Duration;
    private float startTime;
    public GameObject Targetprefab;



    void Start()
    {
        startTime = Time.time;
        StartPosition = transform.position;
        // EndPosition = new Vector3(Random.Range(-13,13),1,Random.Range(12,-17));
    }

    void Update()
 {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            startTime = Time.time;
            EndPosition = new Vector3(Random.Range(-13,13),1,Random.Range(12,-17));

            GameObject destinationPoint = Instantiate(Targetprefab,EndPosition,Quaternion.identity);

            Destroy(destinationPoint,Duration);
        }

            float timeFraction = Mathf.Clamp01((Time.time - startTime) / Duration);
            float currentHeight = Height * (timeFraction - timeFraction * timeFraction);
            transform.position = Vector3.Lerp(StartPosition, EndPosition, timeFraction) + Vector3.up * currentHeight;



            if (transform.position == EndPosition)
            {
                StartPosition = EndPosition;
            }

    }
}
