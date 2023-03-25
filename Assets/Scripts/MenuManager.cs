using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.ResetStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EasyS() { gameManager.StartEasy(); }

    public void NormalS() { gameManager.StartNormal(); }
}