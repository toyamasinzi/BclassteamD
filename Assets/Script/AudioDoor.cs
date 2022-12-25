using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDoor : MonoBehaviour
{
    [SerializeField] AudioClip _se;
    private AudioSource _ad;

    void Start()
    {
        _ad = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            _ad.PlayOneShot(_se);
        }
    }
}

