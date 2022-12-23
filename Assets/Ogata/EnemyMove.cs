using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject target;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        target = GameObject.Find("testplay");
    }

    // Update is called once per frame
    void Update()
    {
       if(target.GetComponent<PlayMove>().isArea == true)
            {
            transform.LookAt(target.transform);
            transform.position += transform.forward * speed;
        }
    }
}
