using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class VRImageLoader : MonoBehaviour
{
    public TextAsset imageListTextAsset; 
    public GameObject vrImagePrefab, LeftButtonPrefab, RightButtonPrefab, UpButtonPrefab, DownButtonPrefab;
    public static GameObject vrImage, rightButton, leftButton, upButton, downButton;
    public static Shader shader;
    public static Dictionary<string, List<string>> adjList;
    public static List<string> startImgNames;
    GameObject canvasObj;
    public AudioClip[] audioClips;
    public AudioSource myAudioSource;
    private static VRImageLoader instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        shader = Shader.Find("Unlit/Texture");
        canvasObj = GameObject.FindWithTag("canvas");
        adjList = new Dictionary<string, List<string>>();
        startImgNames = new List<string>();

        string[] lines = imageListTextAsset.text.Split('\n');
        string first_line = lines[0].Trim();
        int cnt = -2;
        int num_spots = int.Parse(first_line);
        int sec_flag = 0;
        foreach (string line in lines)
        {
            if(cnt == -2)
            {
                cnt++;
                continue;
            }
            if (!string.IsNullOrEmpty(line))
            {
                int flag = 0;
                for(int i=0; i<line.Length; i++)
                {
                    if(line[i] == ',')
                    {
                        flag = 1;
                        break;
                    }
                }
                if(flag == 0)
                {
                    cnt++;
                    sec_flag = 1;
                }
                else
                {
                    string[] values = line.Split(',');
                    string imageName = values[0].Trim();
                    List<string> value = new List<string>();
                    for (int i = 1; i < 6; i++)
                    {
                        value.Add(values[i].Trim());
                    }
                
                    value.Add(cnt.ToString());
                    value.Add(values[6].Trim());

                    if(sec_flag == 1)
                    {
                        startImgNames.Add(imageName);
                        sec_flag = 0;
                    }
                    adjList.Add(imageName, value);
                }
            }
            audioClips = Resources.LoadAll<AudioClip>("AudioClips");
            myAudioSource = GetComponent<AudioSource>();
        }
        vrImage = Instantiate(vrImagePrefab);
        vrImage.tag = "hello";
        Debug.Log("the tag is : " + vrImage.tag);
        rightButton = Instantiate(RightButtonPrefab);
        rightButton.SetActive(false);
        downButton = Instantiate(DownButtonPrefab);
        downButton.SetActive(false);
        leftButton = Instantiate(LeftButtonPrefab);
        leftButton.SetActive(false);
        upButton = Instantiate(UpButtonPrefab);
        upButton.SetActive(false);

        ImageLoader(startImgNames[0]);
        GameObject cur_spot_obj = GameObject.FindGameObjectWithTag("0");
        cur_spot_obj.GetComponent<Image>().color = Color.red;
    }


    public static void ImageLoader(string imgName)
    {
        string imageUrl = "Images/" + imgName;
        Material material = new Material(shader);

        // Load the image from the specified URL
        Coroutine coroutine = instance.StartCoroutine(LoadImage(imageUrl, texture =>
        {
            // Set the albedo texture property of the material
            material.SetTexture("_MainTex", texture);

            // Assign the material to a game object or renderer
            vrImage.GetComponent<Renderer>().material = material;
            vrImage.name = imgName+"_1";
            vrImage.transform.rotation = Quaternion.Euler(new Vector3(0, float.Parse(adjList[imgName][4]), 0));
            if (adjList[imgName][0] != "-1")
            {
                rightButton.SetActive(true);
            }
            else
            {
                RightController.active = false;
                rightButton.SetActive(false);
            }
            if (adjList[imgName][1] != "-1")
            {
                downButton.SetActive(true);
            }
            else
            {
                DownController.active = false;
                downButton.SetActive(false);
            }
            if (adjList[imgName][2] != "-1")
            {
                leftButton.SetActive(true);
            }
            else
            {
                LeftController.active = false;
                leftButton.SetActive(false);
            }
            if (adjList[imgName][3] != "-1")
            {
                upButton.SetActive(true);
            }
            else
            {
                UpController.active = false;
                upButton.SetActive(false);
            }

            if (adjList[imgName][6] != "-1")
            {
                int myInt = int.Parse(adjList[imgName][6]);
                VRImageLoader imageLoader1 = FindObjectOfType<VRImageLoader>();
                imageLoader1.myAudioSource.loop = true;
                imageLoader1.myAudioSource.clip = imageLoader1.audioClips[myInt - 1];
                imageLoader1.myAudioSource.Play();
            }
            else
            {
                VRImageLoader imageLoader1 = FindObjectOfType<VRImageLoader>();
                imageLoader1.myAudioSource.clip = null;
            }
        }));
    }


    public static IEnumerator LoadImage(string url, System.Action<Texture2D> callback)
    {
        // Load the image from the Resources folder
        Texture2D texture = Resources.Load<Texture2D>(url);

        // Invoke the callback with the loaded texture
        callback(texture);

        yield return null;
        }
        // public static void ImageLoader(string imgName, float fadeTime)
        // {
        //     string imageUrl = "Images/" + imgName;
        //     Material material = new Material(shader);

        //     // Load the image from the specified URL
        //     Coroutine coroutine = instance.StartCoroutine(LoadImage(imageUrl, texture =>
        //     {
        //         // Set the albedo texture property of the material
        //         material.SetTexture("_MainTex", texture);

        //         // Create a new renderer for the VR image
        //         Renderer renderer = vrImage.GetComponent<Renderer>();

        //         // Fade out the current image
        //         Material currentMaterial = renderer.material;
        //         instance.StartCoroutine(FadeMaterial(currentMaterial, 1f, 0f, fadeTime, () =>
        //         {
        //             // Assign the new material to the renderer
        //             renderer.material = material;

        //             // Fade in the new image
        //             instance.StartCoroutine(FadeMaterial(material, 0f, 1f, fadeTime, null));
        //         }));

        //         vrImage.name = imgName;
        //         vrImage.transform.rotation = Quaternion.Euler(new Vector3(0, float.Parse(adjList[imgName][4]), 0));
        //     if (adjList[imgName][0] != "-1")
        //     {
        //         rightButton.SetActive(true);
        //     }
        //     else
        //     {
        //         RightController.active = false;
        //         rightButton.SetActive(false);
        //     }
        //     if (adjList[imgName][1] != "-1")
        //     {
        //         downButton.SetActive(true);
        //     }
        //     else
        //     {
        //         DownController.active = false;
        //         downButton.SetActive(false);
        //     }
        //     if (adjList[imgName][2] != "-1")
        //     {
        //         leftButton.SetActive(true);
        //     }
        //     else
        //     {
        //         LeftController.active = false;
        //         leftButton.SetActive(false);
        //     }
        //     if (adjList[imgName][3] != "-1")
        //     {
        //         upButton.SetActive(true);
        //     }
        //     else
        //     {
        //         UpController.active = false;
        //         upButton.SetActive(false);
        //     }

        //     if (adjList[imgName][6] != "-1")
        //     {
        //         int myInt = int.Parse(adjList[imgName][6]);
        //         VRImageLoader imageLoader1 = FindObjectOfType<VRImageLoader>();
        //         imageLoader1.myAudioSource.loop = true;
        //         imageLoader1.myAudioSource.clip = imageLoader1.audioClips[myInt - 1];
        //         imageLoader1.myAudioSource.Play();
        //     }
        //     else
        //     {
        //         VRImageLoader imageLoader1 = FindObjectOfType<VRImageLoader>();
        //         imageLoader1.myAudioSource.clip = null;
        //     }
        //     }));
        // }

        // public static IEnumerator LoadImage(string url, System.Action<Texture2D> callback)
        // {
        //     // Load the image from the Resources folder
        //     Texture2D texture = Resources.Load<Texture2D>(url);

        //     // Invoke the callback with the loaded texture
        //     callback(texture);

        //     yield return null;
        // }

        // public static IEnumerator FadeMaterial(Material material, float startAlpha, float endAlpha, float fadeTime, System.Action onComplete)
        // {
        //     // Set the initial alpha value
        //     Color color = material.color;
        //     color.a = startAlpha;
        //     material.color = color;

        //     // Calculate the duration of the fade
        //     float duration = Mathf.Max(fadeTime, 0.01f);

        //     // Fade the material over time
        //     float startTime = Time.time;
        //     float endTime = startTime + duration;
        //     while (Time.time < endTime)
        //     {
        //         float t = (Time.time - startTime) / duration;
        //         color.a = Mathf.Lerp(startAlpha, endAlpha, t);
        //         material.color = color;
        //         yield return null;
        //     }

        //     // Set the final alpha value
        //     color.a = endAlpha;
        //     material.color = color;

        //     // Invoke the onComplete callback
        //     onComplete?.Invoke();
        // }

}