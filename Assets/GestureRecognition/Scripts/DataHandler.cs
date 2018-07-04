using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleRecordedData(List<Vector3> recordedData)
    {
        Debug.Log("Number of position data : " + recordedData.Count);
    }

}
