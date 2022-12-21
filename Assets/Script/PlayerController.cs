using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̕����I�����̕ϐ�
    /// </summary>
    Rigidbody _rb;
    [SerializeField] float _moveSpeed = 10f;
    public Vector2 _dir = default;
    /// <summary>
    /// �A�j���[�V���������邩�����Ȃ����̔���
    /// </summary>
    bool _leftAttack = false;
    bool _rightAttack = false;
    /// <summary>
    /// ��]����
    /// </summary>
    [SerializeField] float _timer = 0f;
    [SerializeField] float _interval = 5f;

    int i = 0; //�F��ς���ϐ�

    /// <summary>
    /// �Q�b�g�R���|�[�l���g����ϐ�
    /// </summary>
    Material _mat;
    HPController _HP;
    Animator _anim;

    [SerializeField] GameManager _gamemManager;
    [SerializeField] Material _childMt;

    public static PlayerState _currentState = PlayerState.Default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _mat = this.GetComponent<Renderer>().material;
        _HP = this.GetComponent<HPController>();
        _childMt = transform.GetChild(0).GetComponent<Renderer>().material;


    }
    void Update()
    {
        if (_gamemManager._start == false)
        {
            return;
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _dir = new Vector2(h, v);
        _rb.velocity = _dir * _moveSpeed;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            if (i == 0)
            {
                i++;
                ChangeState(PlayerState.Red);
                Debug.Log(i);
            }
            else if (i == 1)
            {
                i++;
                ChangeState(PlayerState.Blue);
                Debug.Log(i);
            }
            else
            {
                i = 0;
                ChangeState(PlayerState.White);
                Debug.Log(i);
            }
        }
        Rotate();
    }

    void ChangeState(PlayerState nextState)
    {
        _currentState = nextState;

        switch (_currentState)
        {
            case PlayerState.Default:
                 _childMt.color = Color.white;
                break;
            case PlayerState.Red:
                _mat.color = Color.red;
                _childMt.color = Color.red;
                break;
            case PlayerState.Blue:
                _mat.color = Color.blue;
                _childMt.color = Color.blue;
                break;
            case PlayerState.White:
                _mat.color = Color.white;
                _childMt.color = Color.white;
                break;
        }
    }
        /// <summary>
    /// �G�ɂ���������_���[�W�A�j���[�V�������n�܂�HP�����鏈��
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            _anim.SetBool("Damage", true);
            _HP.Damage();
        }
    }
    /// <summary>
    /// �G�ɂ������ĂȂ���΃_���[�W�A�j���[�V�������Ȃ�
    /// </summary>
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _anim.SetBool("Damage", false);
        }
    }

    /// <summary>
    /// ��莞�Ԃ��ƃv���C���[�������Ȃ��Ȃ�
    /// </summary>
    public IEnumerator AnimationCoroutine()
    {
        _anim.SetBool("CantMove", true);
        _anim.SetBool("RotateL", false);
        _anim.SetBool("RotateR", false);
        yield return new WaitForSeconds(1.0f);
        _anim.SetBool("CantMove", false);
        _timer = 0;
    }

    /// <summary>
    /// ��]�A�j���[�V����
    /// </summary>
    public void Rotate()
    {
        //����]
        if (Input.GetButton("Fire1") && !_rightAttack)
        {
            _timer += Time.deltaTime;
            if (_timer > _interval)
            {
                StartCoroutine(AnimationCoroutine());
            }
            else
            {
                _leftAttack = true;
                _anim.SetBool("RotateL", true);
            }
        }
        //�E��]
        else if (Input.GetButton("Fire2") && !_leftAttack)
        {
            _timer += Time.deltaTime;
            if (_timer > _interval)
            {
                StartCoroutine(AnimationCoroutine());
            }
            else
            {
                _rightAttack = true;
                _anim.SetBool("RotateR", true);
            }
        }
        //��]���Ă��Ȃ�
        else
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = 0;
            }
            _leftAttack = false;
            _rightAttack = false;
            _anim.SetBool("RotateL", false);
            _anim.SetBool("RotateR", false);
        }
    }
}
