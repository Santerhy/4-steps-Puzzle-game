using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameManager gameManager;
    public TransitionManager transitionManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.ResetStats();
        gameManager.StartMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EasyS() {
        gameManager.StartEasy();
        StartTransition();
    }

    public void NormalS() {
        gameManager.StartNormal();
        StartTransition();
    }

    private void StartTransition()
    {
        transitionManager.StartTransition("Gameplay");
    }
}
