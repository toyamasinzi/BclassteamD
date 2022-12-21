using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _start = false;//ボタンの処理が呼び出されるとtrue
    

    void Start()
    {
        GameStart();
    }

    /// <summary>
    /// ゲームスタート時のボタン入力待ち
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
    /// ゲームオーバ時の処理
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
