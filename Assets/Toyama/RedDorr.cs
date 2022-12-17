using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDorr : MonoBehaviour
{
    [SerializeField] string _animStateName  = "";
    [SerializeField] Animator _anim;
    [SerializeField] GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attack" && _gameManager._red)
        {
            _anim.Play(_animStateName);
        }
    }
}
