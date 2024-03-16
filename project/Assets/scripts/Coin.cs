using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
     private TMP_Text _coinsText;
    private AudioController _audioController => GameObject.FindObjectOfType<AudioController>();

    private void Start()
    {
        _coinsText = GameObject.Find("CoinsCounterText").GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
/*            DataContainer.CouinsCount++;
*/            DataContainer.CoinsCountPerLevel++;
            UpdateCoinsCounter();
            _audioController.PlaySound(collectSound, destroyed: true, destroyedPosition: transform.position);
            Destroy(gameObject);
        }
    }

    private void UpdateCoinsCounter()
    {
        _coinsText.text = $"Coins: {DataContainer.CoinsCountPerLevel}";
    }
}
