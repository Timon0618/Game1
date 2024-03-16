using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SlectLevel : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _levelBtnPrefab;

    private Scene[] LevelScenes;
    private Button[] LevelButtons;

    private void Awake()
    {
        LevelScenes = new Scene[SceneManager.sceneCountInBuildSettings - 1];
        LevelButtons = new Button[SceneManager.sceneCountInBuildSettings - 1];
        FillLevelScenes();
    }

    private void Start()
    {
        FillLevelButtons();
    }

    private void FillLevelScenes()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            LevelScenes[i - 1] = SceneManager.GetSceneByBuildIndex(i);
        }
    }

    private void FillLevelButtons()
    {
        for (int i = 0; i < LevelScenes.Length; i++)
        {
            GameObject btnInstance;
            btnInstance = Instantiate(_levelBtnPrefab, transform);
            btnInstance.transform.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();

            LevelButtons[i] = btnInstance.GetComponent<Button>();
            LevelButtons[i].onClick.AddListener(() => LevelButtonClick(btnInstance));
        }

        SetButtonsAccessibility();

    }

    private void SetButtonsAccessibility()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            if (i > DataContainer.LastCompletedLevel)
            {
                LevelButtons[i].interactable = false;
            }
        }
    }

    public void LevelButtonClick(GameObject clicedButton)
    {
        SceneManager.LoadScene(int.Parse(clicedButton.transform.GetComponentInChildren<TMP_Text>().text));
    }

    public void BackButtonClick()
    {
        _menuPanel.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
