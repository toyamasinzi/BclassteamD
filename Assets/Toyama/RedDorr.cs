using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDorr : MonoBehaviour
{
    [SerializeField] string _animStateName  = "";
    [SerializeField] Animator _anim;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(_gameManager._red && collision.gameObject.tag == "Attack")
        {
            _anim.Play(_animStateName);
        }
    }
}
