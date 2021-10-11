using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private float _speedGainPerSecond = 0.2f;
    [SerializeField] private float _turnSpeed = 125f;

    private int _steerValue;

    private bool _isMoving = false;

    void Update()
    {
        if(!_isMoving)
        {
            return;
        }
        _speed += _speedGainPerSecond * Time.deltaTime;
        transform.Rotate(0f, _turnSpeed * _steerValue * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }

    public void TogglePlay()
    {
        _isMoving = !_isMoving;
    }

    public bool IsMoving()
    {
        return _isMoving;
    }
}
