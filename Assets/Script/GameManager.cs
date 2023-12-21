using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject startPanel;
    GameObject playerObject;
    PlayerController playerController;
    [SerializeField] GameObject successPanel;
    [SerializeField] TextMeshProUGUI successText;
    [SerializeField] GameObject failPanel;
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
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObject.GetComponent<PlayerController>();
    }
    public void StartGame()
    {
        playerController.movementModule.SetCanMove(true);
        playerController.movementModule.StartGame();
        startPanel.SetActive(false);
    }
    public void SuccessFinishGame()
    {
        successPanel.SetActive(false);
        LevelController.Instance.NextLevel();
    }
    public void FailFinishGame()
    {
        failPanel.SetActive(false);
        LevelController.Instance.LoadLevel();
    }
    public void SuccessPanelActive(int value)
    {
        successPanel.SetActive(true);
        successText.text = value.ToString() + "x";
    }
    public void FailurePanelActive()
    {
        failPanel.SetActive(true);
    }

}
