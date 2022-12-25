using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager _gm;
    [SerializeField] GameObject _cl;
    [SerializeField] GameObject _text;
    [SerializeField] string _scene;

    bool _clear = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _gm._start = false;
            _text.SetActive(true);
            _cl.SetActive(true);
            _clear = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && _clear)
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
