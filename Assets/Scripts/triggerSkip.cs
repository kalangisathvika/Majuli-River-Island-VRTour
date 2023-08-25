﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class triggerSkip : MonoBehaviour
{
    public GameObject LoaderUI;
    public Slider progressSlider;
    public GameObject SceneLoaderCanvas;
    public VideoPlayer videoPlayer;
    public void LoadScene(int index)
    {
        videoPlayer.Pause();
        SceneLoaderCanvas.SetActive(true);
        StartCoroutine(LoadScene_Coroutine(index));
    }

    public void OnSkipBoat(InputAction.CallbackContext context)
    {
        LoadScene(3);
    }
    
    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
 
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
 
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
