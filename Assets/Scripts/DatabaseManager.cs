using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Firestore;

using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class DatabaseManager : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    

>>>>>>> Stashed changes


    public Text ContentText;
<<<<<<< Updated upstream
    public GameObject UIPanel;
    public GameObject UIAnchor;
    private string userID;
    private Dictionary<string, int> test;

    private DatabaseReference dbReference;
    private FirebaseFirestore _firebaseDB;

    Dictionary<string, object> balloonDatas = new Dictionary<string, object>();
    Dictionary<string, Dictionary<string, object>> allballoonComments = new Dictionary<string, Dictionary<string, object>>();
    private IEnumerator Start()
    {
        //userID = SystemInfo.deviceUniqueIdentifier;
        //userID = GameManager.instance.getUserID();
        //Debug.Log(userID);
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        _firebaseDB = FirebaseFirestore.DefaultInstance;


        userID = "wqSd10BqshaCYYj5VrQXpY6Ac8F2";
        StartCoroutine(FetchAllBalloonData());
        Debug.Log("fetching user balloon data");
        yield return new WaitForSeconds(1f);
        Debug.Log("get balloons " + balloonDatas.Count);


        StartCoroutine(FetchAllBalloonComments());
        yield return new WaitForSeconds(1f);
        Debug.Log("read all comments");


        string test = "user has works: \n";
=======
    public Text BallonsInfos;

    private string userID;

    private DatabaseReference dbReference;
    private FirebaseFirestore _firebaseDB;

    private void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
       
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        _firebaseDB = FirebaseFirestore.DefaultInstance;

        
        
        Dictionary<string, object> balloonDatas = FetchAllBalloonData("2W5f5A8aCfP04SV5h7qRErW7U1W2");

        Debug.Log(balloonDatas);
        /*
        Dictionary<string, Dictionary<string, object>> allballoonComments = FetchAllBalloonComments(balloonDatas); string test = "user has works: \n";

>>>>>>> Stashed changes
        foreach (KeyValuePair<string, Dictionary<string, object>> bd in allballoonComments)
        {
            test += "artwork: " + bd.Key + "\n";
            foreach (KeyValuePair<string, object> bdc in bd.Value)
            {
                test += "\t comments are: " + bdc.Value + "\n";
            }
        }
        ContentText.text = test;
<<<<<<< Updated upstream
        Debug.Log(test);
        CreatePanel();
    }

    private void CreatePanel()
    {
        int offset = 1450;
        int gap = 1050;
        foreach (KeyValuePair<string, Dictionary<string, object>> bd in allballoonComments)
        {
            GameObject panelInstance = Instantiate(UIPanel);
            panelInstance.transform.SetParent(UIAnchor.GetComponent<Transform>(), false);
            panelInstance.transform.localPosition += new Vector3(0, offset, 0);
            offset -= gap;

            Transform panel_trans = panelInstance.transform.Find("Panel_artWork");
            GameObject id = panel_trans.Find("Panel_ID").Find("Text").gameObject;
            GameObject comment = panel_trans.Find("Panel_Comments").Find("Text").gameObject;

            id.GetComponent<TextMeshProUGUI>().text = bd.Key;
            string comments = "comments are \n";
            foreach (KeyValuePair<string, object> bdc in bd.Value)
            {
                comments += bdc.Key +"\t comments are: " + bdc.Value + "\n";
            }
            comment.GetComponent<TextMeshProUGUI>().text = comments;

        }
    }


    private void Update()
    {
       //Debug.Log("     -------"+balloonDatas.Count);
    }
=======

        */
    }


>>>>>>> Stashed changes



    //given a userID return all its playlist
<<<<<<< Updated upstream
    public IEnumerator FetchAllBalloonData()
    {
        CollectionReference collectionRef = _firebaseDB.Collection("balloons");
        var task = collectionRef.GetSnapshotAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
                // Handle the error
        }
        else
        {
            QuerySnapshot snapshot = task.Result;
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                   Dictionary<string, object> data = document.ToDictionary();
                   if (data["user_id"].ToString() == userID)
                   {
                        balloonDatas[data["balloon_id"].ToString()] = data;
                   }
                }
            }

        }

    }


    public IEnumerator FetchAllBalloonComments()
    {
        var userContentData = dbReference.Child("user").GetValueAsync();
        yield return new WaitUntil(predicate: () => userContentData.IsCompleted);
        if (userContentData != null)
        {
            DataSnapshot snapshot = userContentData.Result;
            foreach (var bd in balloonDatas)
            {
                string bdID = bd.Key;
                allballoonComments[bdID] = new Dictionary<string, object>();
                foreach (DataSnapshot user in snapshot.Children)
                {
                    foreach (DataSnapshot userBallonComment in user.Children)
                    {
                        if (userBallonComment.Key.ToString() == bdID)
                        {
                            allballoonComments[bdID].Add(user.Key.ToString(), userBallonComment.Child("content").Value);
                            Debug.Log("read :____" + userBallonComment.Child("content").Value);
=======
    public Dictionary<string, object> FetchAllBalloonData(string userID)
    {
        CollectionReference collectionRef = _firebaseDB.Collection("balloons");
        Dictionary<string, object> userBalloonDatas = new Dictionary<string, object>();
        collectionRef.GetSnapshotAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error
            }
            else
            {
                QuerySnapshot snapshot = task.Result;
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();
                        // Access the data as needed
                        //Debug.Log(data["user_id"]);
                        if (data["user_id"].ToString() == userID)
                        {
                            userBalloonDatas[data["balloon_id"].ToString()] = data;
>>>>>>> Stashed changes
                        }
                    }
                }
            }
<<<<<<< Updated upstream
           
        }
        else
        {
        }
        
    }

=======




        });
        return userBalloonDatas;

    }


    public Dictionary<string, Dictionary<string, object>> FetchAllBalloonComments(Dictionary<string, object> balloonDatas)
    {
        Dictionary<string, Dictionary<string, object>> allBalloonsComments = new Dictionary<string, Dictionary<string, object>>();
        foreach (var bd in balloonDatas)
        {
            string bdID = bd.Key;
            Dictionary<string, object> bdc = GetAllBallonInfo(bdID);
            allBalloonsComments.Add(bd.Key, bdc);
        }
        return allBalloonsComments;
    }


>>>>>>> Stashed changes
    public Dictionary<string, object> GetAllBallonInfo(string balloonID)
    {
        Dictionary<string, object> curBDComment = new Dictionary<string, object>();
        StartCoroutine(GetAllBalloonContent((Dictionary<string, object> pullComment) => { curBDComment = pullComment; }, balloonID));
<<<<<<< Updated upstream
        Debug.Log(balloonID + " has : "+ curBDComment.Count);
=======
>>>>>>> Stashed changes
        return curBDComment;
    }

    public IEnumerator GetAllBalloonContent(Action<Dictionary<string, object>> onCallback, string balloonID)
    {
        var userContentData = dbReference.Child("user").GetValueAsync();
        Dictionary<string, object> curBDComment = new Dictionary<string, object>();
        yield return new WaitUntil(predicate: () => userContentData.IsCompleted);

        if (userContentData != null)
        {
            DataSnapshot snapshot = userContentData.Result;
            foreach (DataSnapshot user in snapshot.Children)
            {
                foreach (DataSnapshot userBallonComment in user.Children)
                {
                    if (userBallonComment.Key.ToString() == balloonID)
                    {
                        curBDComment.Add(user.Key.ToString(), userBallonComment.Child("content").Value);
<<<<<<< Updated upstream
                        Debug.Log("read :____" + userBallonComment.Child("content").Value);
=======
>>>>>>> Stashed changes
                    }
                }
            }
            onCallback.Invoke(curBDComment);
        }
        else
        {
        }


    }


    /*
    public void CreatUser()
    {
        Comment newComment = new Comment(BalloonName.text, Content.text);
@ -37,13 +149,14 @@ public class DatabaseManager : MonoBehaviour
            userID = UserID.text;
        }
        dbReference.Child("user").Child(userID).Child(newComment.balloonID).SetRawJsonValueAsync(json);
<<<<<<< Updated upstream
    }
=======
>>>>>>> Stashed changes
    }*/


    /*
    public IEnumerator GetName(Action<string> onCallback)
    {
        var userNameData = dbReference.Child("user").Child(userID).Child(BalloonName.text).Child("balloonID").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);
        if(userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
@ -53,8 +166,8 @@ public class DatabaseManager : MonoBehaviour
        {
            onCallback.Invoke("no user founded");
        }
<<<<<<< Updated upstream
    }

=======
>>>>>>> Stashed changes
    }*/
    /*
    public IEnumerator GetContent(Action<string> onCallback)
    {
        var userContentData = dbReference.Child("user").Child(userID).Child(BalloonName.text).Child("content").GetValueAsync();
@ -70,40 +183,11 @@ public class DatabaseManager : MonoBehaviour
        {
            onCallback.Invoke("no comment founded");
        }
<<<<<<< Updated upstream
    }
    }*/

    public IEnumerator GetAllBalloonContent(Action<string> onCallback)
    {
        var userContentData = dbReference.Child("user").GetValueAsync();

        yield return new WaitUntil(predicate: () => userContentData.IsCompleted);

        if (userContentData != null)
        {
            string allComments = "";
            DataSnapshot snapshot = userContentData.Result;
            foreach (DataSnapshot user in snapshot.Children)
            {
                foreach (DataSnapshot userBallonComment in user.Children)
                {
                    if (userBallonComment.Key.ToString() == "to modify")
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
=======
    }*/
>>>>>>> Stashed changes



    /*
    public IEnumerator GetUserAllContent(Action<string> onCallback)
    {
        var userContentData = dbReference.Child("user").GetValueAsync();
@ -134,9 +218,9 @@ public class DatabaseManager : MonoBehaviour
        }


<<<<<<< Updated upstream
    }

=======
>>>>>>> Stashed changes
    }*/

    /*
    public void GetUserBalloonInfo()
    {
        StartCoroutine(GetName((string balloonID) => {
@ -148,18 +232,14 @@ public class DatabaseManager : MonoBehaviour
        }));
    }

<<<<<<< Updated upstream
    public void GetAllBallonInfo()
    {
=======
>>>>>>> Stashed changes
   


    public void GetUserAllInfo()
    {

        StartCoroutine(GetUserAllContent((string allContent) => {
            ContentText.text = "this user's all Comment: \n" + allContent;
        }));
<<<<<<< Updated upstream
    }
    }*/
}
=======
    }*/
}
>>>>>>> Stashed changes
