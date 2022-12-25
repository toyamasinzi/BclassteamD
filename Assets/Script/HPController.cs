using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] float _playerHP = 0;
   
    [SerializeField] GameManager _gameManager;
    [SerializeField] Text _Scoretext = default;

    void Update()
    {
        _Scoretext.text = _playerHP.ToString("00") + "%";
    }
    public void Damage(float i)
    {
        _playerHP += i;
        if (_playerHP >= 100)
        {
            _gameManager.GameOver();
        }
    }
}
