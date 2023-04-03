using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Sprite muteImage, unmuteImage;
    public MusicPlayer musicPlayer;
    private Button muteButton;
    private bool muted;
    // Start is called before the first frame update
    void Start()
    {
        muteButton= GetComponent<Button>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        muted = musicPlayer.GetMusicStatus();
        if (muted)
            muteButton.image.sprite = muteImage;
        else
            muteButton.image.sprite = unmuteImage;
    }

    public void MuteMusic()
    {
        if (!muted)
        {
            muteButton.image.sprite = muteImage;
            musicPlayer.PlayMusic();
            muted = !muted;
        } else
        {
            muteButton.image.sprite = unmuteImage;
            musicPlayer.StopMusic();
            muted = !muted;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
