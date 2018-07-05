using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCapper : MonoBehaviour {

    [SerializeField]
    private Text fpsText;

    public int TargetFPS = 30;

	// Use this for initialization
	void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = TargetFPS;
        StartCoroutine(_CapFPS());

    }

    // Update is called once per frame
    void Update () {
        int fps = (int)(1.0f / Time.smoothDeltaTime);
        fpsText.text = fps.ToString();
        //    Debug.Log(System.DateTime.Now.ToString());
    }

    private IEnumerator _CapFPS()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/TargetFPS);
            Debug.Log(System.DateTime.Now.ToString());
        }
        
    }
}
