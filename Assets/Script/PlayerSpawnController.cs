using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    public static PlayerSpawnController instance;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<GameObject> playerList = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }
    public void AddedList(GameObject ob)
    {
        playerList.Add(ob);
    }
    
}
