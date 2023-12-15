using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    int currentLevel = 0;
    int maxLevel;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrenLevel", 0);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            currentLevel = 0;
        }
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        LoadLevel();

    }
    void Update()
    {

    }
}
