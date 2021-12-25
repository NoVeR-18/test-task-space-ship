using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{

    public static float scrollSpeed;
    private Transform _curObject;
    private Vector2 _speedMinMax = new Vector2 (1.5f,8);
    void Start()
    {
        _curObject = GetComponent<Transform>();
    }


    void Update()
    {
        scrollSpeed = Mathf.Lerp(_speedMinMax.x, _speedMinMax.y, Difficulty.GetDifficultyPercent());
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime, Space.Self);
        if(_curObject.position.y <= -Camera.main.orthographicSize *2f )
        {
            _curObject.position = new Vector2(_curObject.position.x, (Camera.main.orthographicSize *2f)-0.01f);
        }
            
    }
}
