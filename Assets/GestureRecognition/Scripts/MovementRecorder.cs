using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRecorder : MonoBehaviour
{

    [SerializeField]
    private Transform m_objectToRecord;

    //private List<Vector3> m_positionData = new List<Vector3>();
    //private List<Quaternion> m_rotationData = new List<Quaternion>();
    private List<Vector3> m_posRelativeToTransform = new List<Vector3>();

    [SerializeField]
    private Transform m_relativeTargetTransform;
    [SerializeField]
    private Transform m_tempRelativeToTransform;

    [SerializeField]
    private DataHandler m_dataHandler;

    private bool m_recordingStarted = false;

    void Awake()
    {
        if (m_objectToRecord == null)
        {
            m_objectToRecord = this.gameObject.transform;
        }

        if(m_relativeTargetTransform == null)
        {
            Debug.LogError("Player Hip is not set!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) || m_recordingStarted == true)
        {
            RecordData();
        }

        if (Input.GetKeyDown(KeyCode.A))
            StartRecording();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.R))
            StopRecording();
    }

    void RecordData()
    {
        //m_positionData.Add(m_objectToRecord.position);
        //m_rotationData.Add(m_objectToRecord.rotation);
        m_posRelativeToTransform.Add(getLocalizedPoint(m_objectToRecord.position));
    }

    //This will get points in relation to a users head.
    public Vector3 getLocalizedPoint(Vector3 myDumbPoint)
    {
        if(m_tempRelativeToTransform == null)
        {
            Debug.LogError("Player hip is null");
            return new Vector3(0,0,0);
        }
        m_tempRelativeToTransform.position = m_relativeTargetTransform.position;
        m_tempRelativeToTransform.rotation = Quaternion.Euler(0, m_relativeTargetTransform.eulerAngles.y, 0);
        return m_tempRelativeToTransform.InverseTransformPoint(myDumbPoint);
    }

    public void StartRecording()
    {
        m_recordingStarted = true;
        Debug.Log("Recording started");
    }

    public void StopRecording()
    {
        m_recordingStarted = false;
        Debug.Log("Recording stopped");

        //Flush
        if (m_posRelativeToTransform.Count > 0)
        {
            m_dataHandler.HandleRecordedData(m_posRelativeToTransform);
            m_posRelativeToTransform.RemoveRange(0, m_posRelativeToTransform.Count);
            m_posRelativeToTransform.Clear();
        }
    }
}
