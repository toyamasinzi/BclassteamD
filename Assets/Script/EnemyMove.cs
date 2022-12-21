using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject _player = default;
    [SerializeField] float _speed = 1f;
    private Rigidbody _rb = default;
    [SerializeField] float _dis = 1;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Debug.DrawLine(transform.position, _player.transform.position);
        if(Vector3.Distance(transform.position, _player.transform.position) < _dis)
        {
            Vector3 targeting = (_player.transform.position - transform.position).normalized;//プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
            _rb.velocity = new Vector3(targeting.x * _speed, targeting.y * _speed);//プレイヤー追う
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
