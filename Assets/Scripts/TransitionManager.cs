using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public Animator transitionAnimator;
    public Image ls, rs, hidingImage;
    public GameManager gameManager;
    public string nextScene;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        transitionAnimator.SetTrigger("SceneStart");
        hidingImage.gameObject.SetActive(false);
    }

    public void StartTransition(string sceneName) {
        nextScene = sceneName;
        rs.gameObject.SetActive(true);
        ls.gameObject.SetActive(true);
        transitionAnimator.SetTrigger("StartTransition"); 
    }

    public void LoadNextSecene()
    {
        hidingImage.gameObject.SetActive(true);
        SceneManager.LoadScene(nextScene);
    }

    public void EndTransition()
    {
        rs.gameObject.SetActive(false);
        ls.gameObject.SetActive(false);
        Debug.Log(rs.gameObject.activeInHierarchy);
    }
}
