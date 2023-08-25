using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader
{   
    private class LoadingMonoBehaviour : MonoBehaviour{ }
    public enum Scene{
        SampleScene,
        LoadScene,
        StartScene,
    }
    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;
    public static void Load(Scene scene){
        SceneManager.LoadScene(Scene.LoadScene.ToString());
        onLoaderCallback = () =>{
            GameObject loadingGameObject = new GameObject("loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
            SceneManager.LoadSceneAsync(scene.ToString());
        };
    }  
    private static IEnumerator LoadSceneAsync(Scene scene){
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while(!loadingAsyncOperation.isDone){
            yield return null;
        }
    }
    public static float GetLoadingProgress(){
        if(loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            GameObject loadingGameObject = new GameObject("loading Game Object");
            
            return 1f;
        }
    }

    public static void LoaderCallback(){

        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback=null;
        }

    }
}
