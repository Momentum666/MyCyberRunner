using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    [Header("UI Peferences")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Image speakerPortrait;
    [SerializeField] private Button continueButton;

    [Header("Setting")]
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private AudioClip typeSound;
    [SerializeField] private float soundInterval = 3f;

}