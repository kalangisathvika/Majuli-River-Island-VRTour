using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class playandpause : MonoBehaviour
{
    public GameObject pause;
    public GameObject play;
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        play.SetActive(false);
        pause.SetActive(true);
    }

   public void ppclick()
   {
        if(play.activeSelf)
        {
            pause.SetActive(true);
            play.SetActive(false);
            
            videoPlayer.Play();
        }
        else if(pause.activeSelf)
        {
            Debug.Log(play.activeSelf + "  " + pause.activeSelf);
            pause.SetActive(false);
            Debug.Log(play.activeSelf + "  " + pause.activeSelf);
            play.SetActive(true);
            Debug.Log(play.activeSelf + "  " + pause.activeSelf);
            videoPlayer.Pause();
            Debug.Log(play.activeSelf + "  " + pause.activeSelf);
        }
   }

}
