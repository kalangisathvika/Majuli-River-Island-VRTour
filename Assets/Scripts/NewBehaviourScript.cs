using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace YoutubePlayer
{
    public class NewBehaviourScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public TextAsset imageListTextAsset;
        void Start()
        {
            string[] lines = imageListTextAsset.text.Split('\n');

            GetComponent<VideoPlayer>().PlayYoutubeVideoAsync(lines[0]);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}