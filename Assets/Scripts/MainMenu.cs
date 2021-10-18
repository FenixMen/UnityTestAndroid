using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class MainMenu : MonoBehaviour
{

    public string url = "http://mychicken.site/include/api/autorize.php";
    public Text message;
    public Text user;
    public Text userId;
    public Text loginFromUser;
    public Text passwordFromUser;
    public InputField EnterLogin;
    public InputField EnterPassword;

    public void login()
    {
        if(EnterLogin.text == "")
        {
            message.text = "Поле не может быть пустым";
            //Debug.Log("Поле не может быть пустым");
        }
        else
        {
            
            loginFromUser.text = EnterLogin.text;
            passwordFromUser.text = EnterPassword.text;
            //Фишка юнити. Простой и удобный способ запускать функции, которые должны работать параллельно в течение некоторого времени.
            StartCoroutine(SendRequest());
            //Debug.Log(loginFromUser.text);
        }
    }

    private void Start()
    {
    }





    [System.Serializable]
    public struct PostStruct
    {
        public string message;
        public string user;
        public string userId;       
    }

    
    /*
    [System.Serializable]
    public struct Respone
    {
        public PostStruct[] post;

    }*/



    // Update is called once per frame
    public void Update()
    {

    }

    public void ButtonToServer()
    {
        login();
        
    } 

    private IEnumerator SendRequest()
    {
        WWWForm formdata = new WWWForm();

        formdata.AddField("login", loginFromUser.text);
        formdata.AddField("password", EnterPassword.text);

        UnityWebRequest request = UnityWebRequest.Post(url, formdata);

        yield return request.SendWebRequest();

        Debug.Log("Ответ сервера - " + request.downloadHandler.text);

        PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

        //Debug.Log("answer1 = " + postFromServer.answer1);
        message.text = postFromServer.message;
        user.text = postFromServer.user;
        userId.text = postFromServer.userId;
       // Debug.Log("answer2 = " + postFromServer.answer2);

    }

    





















    //IEnumerator что бы можно было получить ответ от сервера (нужено подключить System.Collections;)  позволяет использовать yield - ожидание
    /* private IEnumerator SendPHP()
     {
         WWWForm form = new WWWForm();
         form.AddField("Message", "Запрос из программы");

         using (UnityWebRequest www = UnityWebRequest.Post("http://mychicken.site/test/test.php", form))
         {
             yield return www.SendWebRequest();

             if (www.result != UnityWebRequest.Result.Success)
             {
                 Debug.Log(www.error);

             }
             else
             {
                 if (www.isDone)
                 {
                     //www.GetType();
                    // FromServer = JsonUtility.FromJson<Game>(www.downloadHandler.text);
                     // MoneyTxt.text = JsonUtility.ToJson(playerInstance, true);
                     Debug.Log("Ответ сервера - " + www.downloadHandler);
                     //AnswerList answerList = new AnswerList();
                    // answerList = JsonUtility.FromJson<AnswerList>(www.downloadHandler.text);
                     //return answerList;
                     // var answer = JsonUtility.FromJson<T>(www.downloadHandler.text);
                 }
             }
         }
     }*/

}






