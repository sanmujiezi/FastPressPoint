
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigOS", menuName = "Scriptable Objects/LevelConfigOS")]
public class LevelConfigOS : ScriptableObject
{
    public List<LevelInfo> levelInfos = new();
}

[System.Serializable]
public class LevelInfo
{
    public int levelID;
    public int timeLimit;
    public int scoreLimit;
    public List<LevelBlockInfo> blockInfos = new();
}

[System.Serializable]
public class LevelBlockInfo
{
    public string nums;
    public int count;
}