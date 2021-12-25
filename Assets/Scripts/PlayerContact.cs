using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContact : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameMenu;
    [SerializeField]
    private GameObject _loseMenu;
    [SerializeField]
    private AudioClip _coin;
    [SerializeField]
    private AudioClip _blowUp;
    private new AudioSource _audio;

    private PlayerController Player;

    private void Start()
    {
        Player = GetComponent<PlayerController>();
        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Coin")
        {
            CoinController.CoinScore += 1;
            _audio.PlayOneShot(_coin);
            Destroy(triggerCollider.gameObject);
        }
        if (triggerCollider.tag == "Asteroid")
        {
            LoseMenuCall();
        }
    }

    private void LoseMenuCall()
    {
        if (CoinController.CoinScore > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", CoinController.CoinScore);
        }
        _audio.PlayOneShot(_blowUp);
        _gameMenu.SetActive(false);
        Player.InputChange(0);
        _loseMenu.SetActive(true);
        transform.position = new Vector3(0, 0, 0);
    }
}
