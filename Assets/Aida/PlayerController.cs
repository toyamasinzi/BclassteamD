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
    bool _leftAttack = false;
    bool _rightAttack = false;
    bool _damage = false;
    bool _cant = true;
    [SerializeField] float _timer = 0f;
    [SerializeField] float _interval = 5f;
    [SerializeField] bool _move = true;
    public void Start()
    {
        _gamemManager = GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    
    public void Update()
    {
        //if (_gamemManager._start)
        //{
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            _dir = new Vector2(h, v);
            _rb.velocity = _dir * _moveSpeed;
        //}
    }
    public void FixedUpdate()
    {  
      _rb.AddForce(_dir.normalized * _moveSpeed);
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            Debug.Log("Hit");
            Damage();  
        }
    }
    public void OnTriggerExit(Collider collision)
    { 
       _anim.SetBool("Damage", false);
        
    }
    
    public void LateUpdate()
    {
        //¶‰ñ“]
        if (Input.GetButton("Fire2") && !_rightAttack)
        {
            _timer += Time.deltaTime;
            if (_timer > _interval)
            {
                StartCoroutine(Coroutine());
            }
            else
            {
                _leftAttack = true;
                _anim.SetBool("RotateL", true);
            }
        }
@@@@//‰E‰ñ“]
        else if (Input.GetButton("Fire3") && !_leftAttack)
        {
            _timer += Time.deltaTime;
            if (_timer > _interval)
            {
                StartCoroutine(Coroutine());
            }
            else
            {
                _rightAttack = true;
                _anim.SetBool("RotateR", true);
            }
        }
        //‰ñ“]‚µ‚Ä‚¢‚È‚¢
        else
        {
            _timer -= Time.deltaTime;
            if( _timer <= 0)
            {
                _timer = 0;
            }
            _leftAttack = false;
            _rightAttack = false;
            _anim.SetBool("RotateL", false);
            _anim.SetBool("RotateR", false);
        }
    }
    public void Damage()
    {
        _playerHP += 10;
        if (_playerHP >= 100)
        {
            _gamemManager.GameOver();
        }
        _anim.SetBool("Damage", true);
    }

    public IEnumerator Coroutine()
    {
        _anim.SetBool("CantMove", true);
        _anim.SetBool("RotateL", false);
        _anim.SetBool("RotateR", false);
        yield return new WaitForSeconds(1.0f);
        _anim.SetBool("CantMove", false);
        _timer = 0;
    }
}
