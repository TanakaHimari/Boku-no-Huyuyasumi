using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

//ScriptableObject‚ğì¬‚·‚é
[CreateAssetMenu(fileName = "New Data", menuName = "StoryData")]
public class StoryData : ScriptableObject
{
    public List<Story> stories = new List<Story>();
}
public class Story

{
    [TextArea] public string StoryText;
}