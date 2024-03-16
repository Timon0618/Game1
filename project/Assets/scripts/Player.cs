using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip[] Sounds;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    private Rigidbody2D _rigidbody;
    private bool _canJump = true;

    private AudioController _audioController => GameObject.FindObjectOfType<AudioController>();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*Muvement();*/

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        PhysicMovement();
    }

    private void PhysicMovement()
    {
        float horizontalDirection = Input.GetAxis("Horizontal") * _moveSpeed;
        _rigidbody.velocity = new Vector2(horizontalDirection, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_canJump == true)
        {
            _canJump= false;
            _rigidbody. AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _audioController.PlaySound(Sounds[0]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _canJump = true;
        }
        if (!collision.gameObject.CompareTag("DeadZone"))
        {
            _audioController.PlaySound(Sounds[1]);
        }
    }

}
