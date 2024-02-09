using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    public float baseSpeed;
    private float _speed;
    private bool _playerOnAscensor;
    public GameObject end;

    private void Start()
    {
        _playerOnAscensor = false;
    }

    void Update()
    {
        _speed = baseSpeed * Time.deltaTime;

        if (_playerOnAscensor)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, end.transform.position, _speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")) 
        {
            Debug.Log("go");
            _playerOnAscensor = true;
        }
    }
}
