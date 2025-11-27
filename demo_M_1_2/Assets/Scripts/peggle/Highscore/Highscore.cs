using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class HighscoreList
{
    public Highscore[] items;
}

[Serializable]
public class Highscore
{
    public string id;
    public string name;
    public string score;
    public string time;
    public string source;

    public override string ToString()
    {
        return $"[name: {name}, score: {score}]";
    }
}
