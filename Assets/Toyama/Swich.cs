using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] string _animStateName = "Move";

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("11111");
        if (collision.gameObject.tag == "Player")
        {
            _animator.Play(_animStateName);

        }
    }
}
