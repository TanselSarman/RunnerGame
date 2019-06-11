using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{

    public float offset = 0.707f;
    public Vector3 lastPos = Vector3.zero;
    public GameObject wallPrefab;
    int counter;
    public Transform player;


    public void createNewWalls()
    {
        InvokeRepeating("createWalls", 1, Time.deltaTime);

    }

   

    void createWalls()
    {

        float distance = Vector3.Distance(lastPos,player.position);
        float screenHeight = Camera.main.orthographicSize;

        if (distance > screenHeight*2+2) return;




        int chance = Random.Range(0, 100);
        GameObject wall;
        Vector3 newPos = Vector3.zero;


        if (chance < 50)
        {
            newPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z+offset);


        }
        else
        {
            newPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z-offset);
        }

        wall = Instantiate(wallPrefab, newPos, Quaternion.Euler(0,45,0));

        lastPos = wall.transform.position;
        counter++;

        if (counter % Random.Range(5,9) == 0)
        {

            wall.transform.GetChild(0).gameObject.SetActive(true);
        }

        
    }
}
