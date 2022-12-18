using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] int _playerHP = 0;
    public void Damage()
    {
        _playerHP += 10;
        if (_playerHP >= 100)
        {
            GameObject gamemana = GameObject.Find("GameMnager");
            
        }
    }
}
