using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _start = false;
    public bool _white = false;
    public bool _red = false;
    public bool _blue = false;

    void Start()
    {
        
    }
    void Update()
    {

    }
    public void GameStart()
    {
        StartCoroutine(Hoge());
        IEnumerator Hoge()
        {
            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));
            _start = true;
        }
    }
    public void GameOver()
    {

    }
}
