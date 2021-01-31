using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehabiourSingleton<DialogueManager>
{
    AudioSource src;

    [SerializeField] Dialogue[] dialogues;

    Dictionary<string, Dialogue> internalDialogues;

    Dialogue current;
    private void Awake()
    {
        src = GetComponent<AudioSource>();
        internalDialogues = new Dictionary<string, Dialogue>();
        foreach (var d in dialogues)
        {
            internalDialogues.Add(d.dialogueName, d);
        }
    }

    public void TriggerDialogue(string name)
    {
        src.Stop();
        if (!internalDialogues.ContainsKey(name)) return;
        current = internalDialogues[name];
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        foreach (var clip in current.lines)
        {
            src.clip = clip;
            src.Play();
            yield return new WaitUntil(() => src.isPlaying == false);
        }
        current = null;
    }
}
