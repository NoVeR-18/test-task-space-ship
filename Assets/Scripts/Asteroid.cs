﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _speedMinMax = new Vector2(7, 13);

    void Start()
    {
        _speed = Mathf.Lerp(_speedMinMax.x, _speedMinMax.y, Difficulty.GetDifficultyPercent());
    }


    void Update()
    {

        transform.Rotate(new Vector3(0f, 0f, 4f * Time.deltaTime));
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }
}
