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
    /// �v���C���[�̐F��ς��邽�߂̕ϐ�
    /// </summary>
    [SerializeField] Color _Rcolor = Color.red;
    [SerializeField] Color _Bcolor = Color.blue;
    [SerializeField] Color _Wcolor = Color.white;

    /// <summary>
    /// �A�j���[�V���������邩�����Ȃ����̔���
    /// </summary>
    bool _Lrotate = false;
    bool _Rrotate = false;
    bool _leftAttack = false;
    bool _rightAttack = false;
    bool _damage = false;
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

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _mat = this.GetComponent<Renderer>().material;
        _HP = this.GetComponent<HPController>();
        _gamemManager._white = true;
    }
    /// <summary>
    /// �v���C���[����ƐF��ς��鏈��
    /// </summary>
    void Update()
    {
        if (_gamemManager._start)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            _dir = new Vector2(h, v);
            _rb.velocity = _dir * _moveSpeed;


            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("R");
                if (i == 0)
                {
                    i++;
                    Red();
                    Debug.Log(i);
                }
                else if (i == 1)
                {
                    i++;
                    Blue();
                    Debug.Log(i);
                }
                else
                {
                    i = 0;
                    White();
                    Debug.Log(i);
                }
            }
        }
    }
    /// <summary>
    /// �G�ɂ���������_���[�W�A�j���[�V�������n�܂�HP�����鏈��
    /// </summary>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            StartCoroutine(DamageCoroutine());
            _HP.Damage();
        }
    }
    /// <summary>
    /// �G�ɂ������ĂȂ���΃_���[�W�A�j���[�V�������Ȃ�
    /// </summary>
    //public void OnTriggerExit(Collider collision)
    //{
    //   _anim.SetBool("Damage", false);
    //}

    /// <summary>
    /// �v���C���[����]�����鏈��
    /// </summary>
    public void LateUpdate()
    {
        if(_gamemManager._start)
        Rotate();
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

    public IEnumerator DamageCoroutine()
    {
        _anim.SetBool("Damage", true);
        yield return new WaitForSeconds(1.0f);
        _anim.SetBool("Damage", false);
    }
    

    /// <summary>
    /// �v���C���[�̐F���ԂɂȂ�
    /// </summary>
    public void Red()
    {
        _gamemManager._red = true;
        _gamemManager._white = false;
        _gamemManager._blue = false;
        if (_gamemManager._red)
        {
            _mat.color = _Rcolor;
        }
    }

    /// <summary>
    /// �v���C���[�̐F���ɂȂ�
    /// </summary>
    public void Blue()
    {
        _gamemManager._red = false;
        _gamemManager._white = false;
        _gamemManager._blue = true;
        if (_gamemManager._blue)
        {
            _mat.color = _Bcolor;
        }
    }

    /// <summary>
    /// �v���C���[�̐F�����ɂȂ�
    /// </summary>
    public void White()
    {
        _gamemManager._red = false;
        _gamemManager._white = true;
        _gamemManager._blue = false;
        if (_gamemManager._white)
        {
            _mat.color = _Wcolor;
        }
    }

    /// <summary>
    /// ��]�A�j���[�V����
    /// </summary>
    public void Rotate()
    {
        //����]
        if (Input.GetButton("Fire2") && !_rightAttack)
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
        else if (Input.GetButton("Fire3") && !_leftAttack)
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
