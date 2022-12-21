using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] PlayerState _state = PlayerState.Default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && PlayerController._currentState == _state)
        {
            other.gameObject.SetActive(false);
        }
    }
}
