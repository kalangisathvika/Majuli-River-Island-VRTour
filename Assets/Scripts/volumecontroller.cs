using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class volumecontroller : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider volumeSlider;


    private void Start()
    {
        volumeSlider.value = 0.7f;
        videoPlayer.SetDirectAudioVolume(0, volumeSlider.value);
     
    }

    public void OnVolumeChanged()
    {
        videoPlayer.SetDirectAudioVolume(0, volumeSlider.value);
    }

   
}