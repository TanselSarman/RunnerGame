using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{

    

    // Update is called once per frame
    void Update()
    {
        Vector3 distance =GameObject.Find("Player").transform.position-transform.position;
        float screenHeight = Camera.main.orthographicSize;

        if (distance.z > screenHeight) 
        {
            Destroy(gameObject);
        }
    }
}
