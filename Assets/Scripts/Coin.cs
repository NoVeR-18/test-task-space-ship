using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _speed = 7;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }
}
