using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    bool sagaMiBakiyor;
    GameManager gameManager;

    public float moveSpeed;

    public Transform rayOrigin;

    public GameObject particlePrefab;



    Animator animController;



    private void Start()
    {
        moveSpeed = 2.0f;
        animController = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        sagaMiBakiyor = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            YonDegistir();
        }

        if (transform.position.y < -4)
        {
            gameManager.Restart();
        }

    }

    private void YonDegistir()
    {
        sagaMiBakiyor = !sagaMiBakiyor;

        if (sagaMiBakiyor)
            transform.rotation = Quaternion.Euler(0, -135, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }

    private void FixedUpdate()
    {
        if (!gameManager.isGameStarted) return;

        else
        {
            animController.SetTrigger("gameStarted");
            rb.position += transform.forward * Time.deltaTime*moveSpeed;

            if (!Physics.Raycast(rayOrigin.position, Vector3.down))
            {
                animController.SetTrigger("falling");
            }

        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cristal")
        {

            
            Destroy(other.gameObject);
            GameObject particle = Instantiate(particlePrefab, transform);
            Destroy(particle, 1);
            gameManager.makeScore();

        }
    }

}
