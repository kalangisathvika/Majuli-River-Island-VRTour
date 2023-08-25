using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Dictionary<string, List<string>> adjList;
    string imgName, rightImgName, downImgName, leftImgName, upImgName;

    public void ShiftRight()
    {
        string imgName_1 = VRImageLoader.vrImage.name;
        imgName = imgName_1.Remove(imgName_1.Length-2,2);
        rightImgName = VRImageLoader.adjList[imgName][0];

        if (rightImgName != "-1")
        {
            VRImageLoader.ImageLoader(rightImgName);
            miniMap(imgName,rightImgName);
        }
    }

    public void ShiftDown()
    {
        string imgName_1 = VRImageLoader.vrImage.name;
        imgName = imgName_1.Remove(imgName_1.Length-2,2);
        downImgName = VRImageLoader.adjList[imgName][1];

        if (downImgName != "-1")
        {
            VRImageLoader.ImageLoader(downImgName);
            miniMap(imgName,downImgName);
        }
    }

    public void ShiftLeft()
    {
        string imgName_1 = VRImageLoader.vrImage.name;
        imgName = imgName_1.Remove(imgName_1.Length-2,2);
        leftImgName = VRImageLoader.adjList[imgName][2];

        if (leftImgName != "-1")
        {
            VRImageLoader.ImageLoader(leftImgName);
            miniMap(imgName,leftImgName);
        }
    }

    public void ShiftUp()
    {
        string imgName_1 = VRImageLoader.vrImage.name;
        imgName = imgName_1.Remove(imgName_1.Length-2,2);
        upImgName = VRImageLoader.adjList[imgName][3];

        if (upImgName != "-1")
        {
            VRImageLoader.ImageLoader(upImgName);
            miniMap(imgName,upImgName);
        }
    }

    public void miniMap(string str1, string str2){
        GameObject curPin = GameObject.Find(str1);
        Debug.Log(curPin);
        GameObject nxtPin = GameObject.Find(str2);
        Debug.Log(nxtPin);
        Debug.Log(nxtPin.tag);
        // Debug.Log(nxtPin.name)
        curPin.GetComponent<Image>().color = Color.white;
        nxtPin.GetComponent<Image>().color = Color.red;
    }
}
