using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class VoiceCommands : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject GreenIndicator;
    public GameObject BlueIndicator;
    public GameObject RedIndicator;
    public GameObject YellowIndicator;
    public GameObject PinkIndicator;

    public GameObject TestCube;
    public GameObject ResetPos;
    public GameObject Player;
    public GameObject Hand;

    private void Start()
    {
        GreenIndicator.SetActive(false);
        RedIndicator.SetActive(false);
        BlueIndicator.SetActive(false);
        YellowIndicator.SetActive(false);
        PinkIndicator.SetActive(false);
        actions.Add("hike", Hike);
        actions.Add("reset", Reset);
        actions.Add("test", Test);
        actions.Add("chris is really dumb", Mitochondria);
        actions.Add("i like vegetables", Sick);
        actions.Add("why are you gay", Gay);
        actions.Add("this is a test", TestSentence);
        actions.Add("I fell off the map", ResetPosition);
        actions.Add("Give me the cube", TestingCube);



        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedCommand;
        keywordRecognizer.Start();
    }

    private void RecognizedCommand(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Test()
    {
        GreenIndicator.SetActive(true);
        YellowIndicator.SetActive(true);
        BlueIndicator.SetActive(true);
        RedIndicator.SetActive(true);
        PinkIndicator.SetActive(true);
    }
    private void Hike()
    {
        GreenIndicator.SetActive(true);

    }

    private void Reset()
    {
        GreenIndicator.SetActive(false);
        RedIndicator.SetActive(false);
        BlueIndicator.SetActive(false);
        YellowIndicator.SetActive(false);
        PinkIndicator.SetActive(false);
    }

    private void Mitochondria()
    {
        RedIndicator.SetActive(true);
    }
    
    private void Sick()
    {
        PinkIndicator.SetActive(true);
    }
    
    private void Gay()
    {
        BlueIndicator.SetActive(true);
    }
   
    private void TestSentence()
    {
        YellowIndicator.SetActive(true);
    }

    private void ResetPosition()
    {
        Player.transform.position = ResetPos.transform.position;
    }

    private void TestingCube()
    {
        TestCube.transform.position = Hand.transform.position;
    }

}
