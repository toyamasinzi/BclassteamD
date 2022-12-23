using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool _start = false;//ボタンの処理が呼び出されるとtrue
    [SerializeField] GameObject _taitl;
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _push;
    [SerializeField] string _scene;

    bool _check = false;

    void Start()
    {
        GameStart();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && _check)
        {
            SceneManager.LoadScene(_scene);
        }
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
            _taitl.SetActive(false);
            _start = true;
        }
    }
    /// <summary>
    /// ゲームオーバ時の処理
    /// </summary>
    public void GameOver()
    {
        _gameOver.SetActive(true);
        _push.SetActive(true);
        _start = false;
        _check = true;
    }
}
public enum PlayerState
{
    Default = 0,
    Red = 1,
    Blue = 2,
    White = 3,
}
