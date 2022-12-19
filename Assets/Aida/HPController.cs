using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] int _playerHP = 0;
    [SerializeField] GameManager _gameManager;
    [SerializeField] Text _Scoretext = default;

    void Update()
    {
        _Scoretext.text = _playerHP.ToString("d2") + "%";
    }
    public void Damage()
    {
        _playerHP += 10;
        if (_playerHP >= 100)
        {
            _gameManager.GameOver();
        }
    }
}
