using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMoveContr : MonoBehaviour
{
    [SerializeField]
    private bool _startMovement;

    private float _moveSpeed = 3f;

    public bool startMovement
    {
        get
        {
            return _startMovement;
        }
        set
        {
            _startMovement = value;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_startMovement == true)
        {
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }
}
