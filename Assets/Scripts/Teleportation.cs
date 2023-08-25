using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
    public GameObject maxiMap;
    List<string> startImgNames;
    public GameObject namonimap,rawanaparmap,naya,jugun,kamalabaritown,bhogpur,auniati,kamalabarighat;
     List<GameObject> myList = new List<GameObject>();
    private void Start(){
        myList.Add(rawanaparmap);
        myList.Add(naya);
        myList.Add(jugun);
        myList.Add(kamalabaritown);
        myList.Add(bhogpur);
        myList.Add(auniati);
        myList.Add(namonimap);
        myList.Add(kamalabarighat);
    }

    public void teleport()
    {
        string imgName_1 = VRImageLoader.vrImage.name;
        string cur_loc_ball = imgName_1.Remove(imgName_1.Length-2,2);
        string cur_spot = VRImageLoader.adjList[cur_loc_ball][5];
        GameObject cur_spot_obj = GameObject.FindGameObjectWithTag(cur_spot);
        GameObject curSpot = GameObject.Find(cur_loc_ball);
        curSpot.GetComponent<Image>().color = Color.white;
        //curPin.GetComponent<Image>().color = Color.white;
        cur_spot_obj.GetComponent<Image>().color = Color.black;
        startImgNames = VRImageLoader.startImgNames;
        string currentTag = gameObject.tag;
        gameObject.GetComponent<Image>().color = Color.red;
        TeleportController.active[int.Parse(cur_spot)] = false;
        maxiMap.SetActive(false);
        Debug.Log(currentTag);
        Debug.Log(int.Parse(currentTag));
        Debug.Log(startImgNames[int.Parse(currentTag)]);
        VRImageLoader.ImageLoader(startImgNames[int.Parse(currentTag)]);
        GameObject teleSpot = GameObject.Find(startImgNames[int.Parse(currentTag)]);
        //Debug.Log(startImgNames[int.Parse(currentTag)]);
        //teleSpot.GetComponent<Image>().color = Color.red;
        minimapupdater(int.Parse(cur_spot),int.Parse(currentTag));
    }
    public void minimapupdater(int curspot,int nextspot)
    {
        // string currentmintag=curspot+"_min";
        // string nextmintag=nextspot+"_min";
        // Debug.Log(currentmintag);
        // Debug.Log(nextmintag);
        // GameObject curminimap = GameObject.FindGameObjectWithTag(currentmintag);
        // GameObject nextminimap = GameObject.FindGameObjectWithTag(nextmintag);
        // Debug.Log(nextminimap);
        // Debug.Log(curminimap);
        // curminimap.SetActive(false);
        // nextminimap.SetActive(true);
        GameObject first=myList[curspot];
        Debug.Log(first);
        first.SetActive(false);
         GameObject second=myList[nextspot];
        second.SetActive(true);

    }
}
