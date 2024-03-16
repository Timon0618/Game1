using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private Vector3 _levelStartPoint;
    private AudioController _audioController => GameObject.FindObjectOfType<AudioController>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = _levelStartPoint;
            _audioController.PlaySound(deathSound);
        }
    }
}
