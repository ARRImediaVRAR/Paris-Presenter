using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edwon.VR;
using Edwon.VR.Gesture;
public class DataHandler : MonoBehaviour {

    [SerializeField]
    private string m_gestureName = "Test Gesture";
    private string m_fileLocation;

    enum PresentationState { FirstScene, SecondScene, ThirdScene };
    PresentationState m_currentPresentationState;
    // Use this for initialization

    void Start () {
        m_currentPresentationState = PresentationState.FirstScene;
    }

    // Update is called once per frame
    void Update () {
	}

    public void HandleRecordedData(List<Vector3> recordedData)
    {
        CreateFile(recordedData);
    }

    void CreateFile(List<Vector3> recordedData)
    {
        m_fileLocation = Application.streamingAssetsPath + Config.NEURAL_NET_PATH + "CustomGesture" + "/Gestures/";
        
        System.IO.Directory.CreateDirectory(m_fileLocation);

        if (recordedData.Count >= 1)
        {
            DataExample saveMe = new DataExample();
            saveMe.gestureName = m_gestureName;
            saveMe.gestureData = recordedData;
            saveMe.timeSinceStart = Time.time.ToString();
      //      saveMe.timestamp = System.DateTime.Now.ToString();
            saveMe.speechData = "";
            saveMe.state = m_currentPresentationState.ToString();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(m_fileLocation + m_gestureName + ".txt"))
            {
                file.WriteLine(JsonUtility.ToJson(saveMe, true));
            }
        }
    }
}