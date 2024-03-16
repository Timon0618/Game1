using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContolls : MonoBehaviour
{

    public void MenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
