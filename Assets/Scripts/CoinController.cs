using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public static int CoinScore = 0;

    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text BestScore;

    private void Update()
    {
        Score.text = CoinScore.ToString();
        BestScore.text = "Best Score: "+PlayerPrefs.GetInt("Score").ToString();
    }

    public void GoToMenu()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Asteroid").Concat(GameObject.FindGameObjectsWithTag("Coin")).ToArray();
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

}
