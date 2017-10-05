using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "test" , "left","up" };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;

    public GameObject bouleRouge;

    protected PhraseRecognizer recognizer;
    protected string word = "test";

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("here");
        word = args.text;
        
        switch (word)
        {
            case "test":
                GameObject labouboule = Instantiate(bouleRouge);
                labouboule.transform.position = new Vector3(0, 1, -5);
                break;
        }
    }

    private void Update()
    {
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
