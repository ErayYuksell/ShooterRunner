using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    int currentLevel;
    int maxLevel = 5;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadLevel();
    }
    public void LoadLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        SceneManager.LoadScene(currentLevel);
    }

    //public void GetLevel()
    //{
    //    SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel", 0));
    //}
    //public void LoadLevel()
    //{
    //    StartCoroutine(WaitLoadLevel());
    //}
    //public IEnumerator WaitLoadLevel()
    //{
    //    yield return new WaitForSeconds(3f);
    //    SceneManager.LoadScene(currentLevel);
    //}

    public void NextLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            currentLevel = 0;
        }
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        LoadLevel();
    }

}
