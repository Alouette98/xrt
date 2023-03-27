using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string name;
    public int gold;

    public User(string name, int gold)
    {
        this.name = name;
        this.gold = gold;
    }


}

public class Comment
{
    public string balloonID;
    public string content;

    public Comment(string balloonID, string content)
    {
        this.balloonID = balloonID;
        this.content = content;
    }
}
