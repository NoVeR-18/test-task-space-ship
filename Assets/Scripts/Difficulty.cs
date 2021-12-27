using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{

    static float SecToMaxDiff = 60;
    
    private static float _timer = 0;
        
    private void OnDisable()
    {
        _timer = 0;
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01( _timer/ SecToMaxDiff);
    }
    public static void SetDifficulty(float SecToMax = 60)
    {
        SecToMaxDiff = SecToMax;
    }
}
