using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    [SerializeField] private int _levelTimerDelay = 3;
    [SerializeField] private GameObject _levelResultPanel;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _coinsResultText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;

            _levelResultPanel.SetActive(true);

            _coinsResultText.text = DataContainer.CoinsCountPerLevel.ToString();
            DataContainer.CoinsCountSummary += DataContainer.CoinsCountPerLevel;
            DataContainer.CoinsCountPerLevel = 0;

            DataContainer.LastCompletedLevel = SceneManager.GetActiveScene().buildIndex;

            if (SceneManager.sceneCountInBuildSettings - 1 > DataContainer.LastCompletedLevel)
            {
                StartCoroutine(TimerToNextLevel(DataContainer.LastCompletedLevel + 1));
            }
            else StartCoroutine(TimerToNextLevel(0));
        }
    }

    private IEnumerator TimerToNextLevel(int levelIndex)
    {
        for (int i = _levelTimerDelay; i > 0; i--)
        {
            _timerText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
    }
}
