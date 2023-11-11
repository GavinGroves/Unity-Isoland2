using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Utilities.EventHandler;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;
    public Text dialogueText;

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += OnShowDialogueEvent;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= OnShowDialogueEvent;
    }

    private void OnShowDialogueEvent(string dialogue)
    {
        if(dialogue != string.Empty)
            panel.SetActive(true);
        else
            panel.SetActive(false);

        dialogueText.text = dialogue;
    }
}