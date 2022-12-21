using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorr : MonoBehaviour
{
    [SerializeField] string _animStateName  = "";
    [SerializeField] Animator _anim;
    [SerializeField] PlayerState _state = PlayerState.Default;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attack" && PlayerController._currentState == _state)
        {
            _anim.Play(_animStateName);
        }
    }
}
