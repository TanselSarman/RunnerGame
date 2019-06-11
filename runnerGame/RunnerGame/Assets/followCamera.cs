using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{

    Vector3 fark;
    public Transform character;

    private void Start()
    {

        fark = character.position - transform.position;


    }

    private void LateUpdate()
    {
        transform.position = character.position - fark;
    }


}
