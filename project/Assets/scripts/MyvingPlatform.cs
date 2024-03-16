using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyvingPlatform : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    private Vector3 _targetPoint;

    private void Awake()
    {
        transform.position = _startPoint;
        _targetPoint= _endPoint;
    }

    private void Update()
    {
        if (transform.position != _targetPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
        }
        else if (transform.position == _startPoint)
        {
            _targetPoint = _endPoint;
        }
        else if (transform.position == _endPoint)
        {
            _targetPoint = _startPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
