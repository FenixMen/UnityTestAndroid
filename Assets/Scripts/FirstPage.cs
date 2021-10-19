using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPage : MonoBehaviour
{

    public Text user;
    public Text userId;

   

    // Start is called before the first frame update
    void Start()
    {
        user.text = SessionDate.user;
        userId.text = SessionDate.userId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
