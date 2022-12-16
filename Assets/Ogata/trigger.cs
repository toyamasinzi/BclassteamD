using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChase : MonoBehaviour
{
    private GameObject target;
    public float speed;

    void Start()
    {
        speed = 0.05f;
        target = GameObject.Find("testplay");
    }

    void Update()
    {
        if (target.GetComponent<CubeMove>().isArea == true)
        {
            GetComponent<Renderer>().material.color = Color.red;
            transform.LookAt(target.transform);
            transform.position += transform.forward * speed;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}