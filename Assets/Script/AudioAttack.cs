using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAttack : MonoBehaviour
{
    [SerializeField] AudioClip _se;
    private AudioSource _ad;

    void Start()
    {
        _ad = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            _ad.PlayOneShot(_se);
        }
    }
}
