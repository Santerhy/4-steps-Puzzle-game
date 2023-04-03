using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    public Animator helpPanelAnimator;
    bool playOpen = false, ableToInteract = true;
    public GameObject helpPanel, clickPreventPanel;
    private float clipTime;
    private PuzzleGenerator puzzleGenerator;

    private void Start()
    {
        puzzleGenerator = FindObjectOfType<PuzzleGenerator>();
    }

    public void OpenPanel()
    {
        if (!playOpen && ableToInteract)
        {
            helpPanel.SetActive(true);
            helpPanelAnimator.SetTrigger("Open");
            playOpen = !playOpen;
            ableToInteract = false;
            clickPreventPanel.SetActive(true);
            puzzleGenerator.helpMenuOpen = true;
            StartCoroutine(HaltActions());
        } else if (playOpen && ableToInteract)
        {
            helpPanelAnimator.SetTrigger("Close");
            playOpen = !playOpen;
            ableToInteract = false;
            clickPreventPanel.SetActive(false);
            puzzleGenerator.helpMenuOpen = false;
            StartCoroutine(HaltActions());
        }

    }

    IEnumerator HaltActions()
    {
        if (clipTime == 0)
            clipTime = helpPanelAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(clipTime);
        ableToInteract = true;
    }
}
