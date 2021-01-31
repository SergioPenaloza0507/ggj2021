using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serilizable]
[CreateAssetMenu(fileName ="newDialogue", menuName ="Dialogues/new Dialogue")]
public class Dialogue : ScriptableObject
{
    public string dialogueName;
    public AudioClip[] lines;
}
