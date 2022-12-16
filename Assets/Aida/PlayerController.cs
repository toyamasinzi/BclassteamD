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
    bool _Lrotate = false;
    bool _Rrotate = false;
    public Vector2 _dir = default;
    GameManager _gamemManager;
    Animator  _anim;

    void Start()
    {
        _gamemManager = GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //if (_gamemManager._start)
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

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "enemy")
        {

        }
    }
    void LateUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            _anim.SetBool("RotateL",_Lrotate);

        }
        else if (Input.GetButton("Fire3"))
        {
            _anim.SetBool("RotateR",_Rrotate);
        }
    }
}
