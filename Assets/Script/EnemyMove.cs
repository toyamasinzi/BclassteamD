using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject _player = default;
    [SerializeField] float _speed = 1f;
    private Rigidbody _rb = default;
    [SerializeField] float _dis = 1;
    [SerializeField] GameManager _gm;
    [SerializeField] HPController _hp;
    [SerializeField] float _damege = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (_gm._start == false)
        {
            return;
        }
        Debug.DrawLine(transform.position, _player.transform.position);
        if(Vector3.Distance(transform.position, _player.transform.position) < _dis)
        {
            Vector3 targeting = (_player.transform.position - transform.position).normalized;//�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
            _rb.velocity = new Vector3(targeting.x * _speed, targeting.y * _speed);//�v���C���[�ǂ�
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _hp.Damage(_damege);
            gameObject.SetActive(false);
        }
    }
}
