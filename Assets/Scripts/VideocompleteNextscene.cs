using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideocompleteNextscene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button skipbutton;
    // Start is called before the first frame update
    void Start()
    {
         videoPlayer.loopPointReached += OnVideoEndReached;
    }

    void OnVideoEndReached(VideoPlayer videoPlayer)
    {
        Debug.Log("Video ended!");
        skipbutton.onClick.Invoke();
    }
}
