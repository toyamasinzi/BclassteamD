using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageAnimation : MonoBehaviour
{
    [SerializeField] float _gage = 0.63f;
    [SerializeField] Image _image;
    [SerializeField] PlayerController _player;
    void Start()
    {
        _image = GetComponent<Image>();
    }


    void Update()
    {
        _image.fillAmount = _gage / _player._timer;
    }
}
