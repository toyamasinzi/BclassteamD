using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    public bool isArea;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }


    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CollisionDetector")
        {
            isArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CollisionDetector")
        {
            isArea = false;
        }
    }
}