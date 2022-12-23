using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    [SerializeField] PlayerState _state = PlayerState.Default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack" && PlayerController._currentState == _state)
        {
            gameObject.SetActive(false);
        }
    }
}
