using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject startPanel;
    GameObject playerObject;
    PlayerController playerController;
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
        playerController.movementModule.StartGame();
        startPanel.SetActive(false);
    }

    void Update()
    {

    }
}
