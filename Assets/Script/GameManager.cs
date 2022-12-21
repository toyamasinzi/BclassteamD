using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _start = false;//�{�^���̏������Ăяo������true
    

    void Start()
    {
        GameStart();
    }

    /// <summary>
    /// �Q�[���X�^�[�g���̃{�^�����͑҂�
    /// </summary>
    public void GameStart()
    {
        StartCoroutine(Hoge());
        IEnumerator Hoge()
        {
            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));
            _start = true;
        }
    }
    /// <summary>
    /// �Q�[���I�[�o���̏���
    /// </summary>
    public void GameOver()
    {

    }
}
public enum PlayerState
{
    Default = 0,
    Red = 1,
    Blue = 2,
    White = 3,
}
