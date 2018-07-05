using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edwon.VR;
using Edwon.VR.Gesture;
public class DataHandler : MonoBehaviour {

    public GestureRecognizer m_currentRecognizer;
    public Trainer m_currentTrainer;


    VRGestureSettings gestureSettings;
    VRGestureSettings GestureSettings
    {
        get
        {
            if (gestureSettings == null)
            {
                gestureSettings = Utils.GetGestureSettings();
            }
            return gestureSettings;
        }
    }

    // Use this for initialization
    void Start () {
        gestureSettings = Utils.GetGestureSettings();

        Debug.Log("Current neural network: " + GestureSettings.currentNeuralNet);

        if (gestureSettings == null)
        {
            Debug.LogError("Gesture settings null");
        }

        Debug.Log("Number of gestures in the bank : " + gestureSettings.gestureBank.Count);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void HandleRecordedData(List<Vector3> recordedData)
    {
        string newGestureName = "CustomGesture " + (gestureSettings.gestureBank.Count + 1);

        gestureSettings.CreateGesture(newGestureName, false);

        //  gestureSettings.CreateNewNeuralNet(newNeuralNetworkName + gestureSettings.gestureBank.Count);

        m_currentTrainer = new Trainer(gestureSettings.currentNeuralNet, GestureSettings.gestureBank);
        m_currentTrainer.CurrentGesture = GestureSettings.FindGesture(newGestureName);

        m_currentTrainer.TrainLine(recordedData, Handedness.Right);
        m_currentTrainer.TrainRecognizer();

        Debug.Log("Recorded data length : " + recordedData.Count);

        //Recognizing
        //currentRecognizer.RecognizeLine(capturedLine, hand, this);

    }
}
