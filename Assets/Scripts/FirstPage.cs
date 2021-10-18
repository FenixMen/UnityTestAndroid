using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FirstPage : MonoBehaviour
{
    public static Text user;
    public static Text userId;
    public static Text message;

    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        public string user;
        public string userId;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
