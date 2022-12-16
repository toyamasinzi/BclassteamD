using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] int _playerHP = 0;
    [SerializeField] bool _colorChange = false;
    [SerializeField] bool _gameStart = false;
    [SerializeField] Color _Rcolor = Color.red;
    [SerializeField] Color _Bcolor = Color.blue;
    [SerializeField] Color _Wcolor = Color.white;
    Vector2 _dir = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //if (_gameStart)
        //{
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            _dir = new Vector2(h,v);
            _rb.velocity = _dir * _moveSpeed;

            //if(_playerHP >= 100)
            //{
            //    //ゲームオーバーを呼び出す
            //}
        //}
    }
    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "enemy")
        {

        }
    }

}
