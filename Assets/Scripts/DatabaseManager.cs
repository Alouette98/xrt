using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using System;

public class DatabaseManager : MonoBehaviour
{
    public InputField UserID;
    public InputField BalloonName;
    public InputField Content;

    public Text BalloonNameText;
    public Text ContentText;

    private string userID;
    private Dictionary<string, int> test;
    private DatabaseReference dbReference;
    private void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
       
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        test = new Dictionary<string, int>();

        UserID.text = "iota11";
        BalloonName.text = "ball_1";
        Content.text = "just for test";
    }
    public void CreatUser()
    {
        Comment newComment = new Comment(BalloonName.text, Content.text);
        string json = JsonUtility.ToJson(newComment);
        if (UserID.text.Length > 0)
        {
            userID = UserID.text;
        }
        dbReference.Child("user").Child(userID).Child(newComment.balloonID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetName(Action<string> onCallback)
    {
        var userNameData = dbReference.Child("user").Child(userID).Child(BalloonName.text).Child("balloonID").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if(userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallback.Invoke(snapshot.Value.ToString());
        }
        else
        {
            onCallback.Invoke("no user founded");
        }
    }

    public IEnumerator GetContent(Action<string> onCallback)
    {
        var userContentData = dbReference.Child("user").Child(userID).Child(BalloonName.text).Child("content").GetValueAsync();

        yield return new WaitUntil(predicate: () => userContentData.IsCompleted);

        if(userContentData != null)
        {
            DataSnapshot snapshot = userContentData.Result;
            onCallback.Invoke(snapshot.Value.ToString());
        }
        else
        {
            onCallback.Invoke("no comment founded");
        }
    }

    public IEnumerator GetAllBalloonContent(Action<string> onCallback)
    {
        var userContentData = dbReference.Child("user").GetValueAsync();

        yield return new WaitUntil(predicate: () => userContentData.IsCompleted);

        if (userContentData != null)
        {
            string allComments = "";
            DataSnapshot snapshot = userContentData.Result;
            foreach(DataSnapshot user in snapshot.Children)
            {
                foreach(DataSnapshot userBallonComment in user.Children)
                {
                    if(userBallonComment.Key.ToString() == BalloonName.text)
                    {
                        allComments += user.Key.ToString() + " : " + userBallonComment.Child("content").Value + "\n";
                    }
                }
            }

            onCallback.Invoke(allComments);
        }
        else
        {
            onCallback.Invoke("no comment founded");
        }


    }


    public IEnumerator GetUserAllContent(Action<string> onCallback)
    {
        var userContentData = dbReference.Child("user").GetValueAsync();

        yield return new WaitUntil(predicate: () => userContentData.IsCompleted);

        if (userContentData != null)
        {
            string allComments = "";
            DataSnapshot snapshot = userContentData.Result;
            foreach (DataSnapshot user in snapshot.Children)
            {
                if (user.Key == UserID.text)
                {
                    foreach (DataSnapshot userBallonComment in user.Children)
                    {
                        allComments += userBallonComment.Key.ToString() + " : " + userBallonComment.Child("content").Value + "\n";
                    }
                }
                
            }

            onCallback.Invoke(allComments);
        }
        else
        {
            onCallback.Invoke("no comment founded");
        }


    }


    public void GetUserBalloonInfo()
    {
        StartCoroutine(GetName((string balloonID) => {
            BalloonNameText.text = "ballonID: " + balloonID;
        }));

        StartCoroutine(GetContent((string content) => {
            ContentText.text = "comment: " + content;
        }));
    }

    public void GetAllBallonInfo()
    {

        StartCoroutine(GetAllBalloonContent((string allContent) => {
            ContentText.text = "this balloon's all Comment: \n" + allContent;
        }));
    }
    public void GetUserAllInfo()
    {

        StartCoroutine(GetUserAllContent((string allContent) => {
            ContentText.text = "this user's all Comment: \n" + allContent;
        }));
    }
}
