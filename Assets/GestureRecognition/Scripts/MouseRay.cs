using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour {

    [SerializeField]
    private Camera m_Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {


            Ray mouseRay = m_Camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(mouseRay.origin, mouseRay.direction * 10, Color.green, 50);

            RaycastHit hit;

            if (Physics.Raycast(mouseRay, out hit))
            {
                Debug.Log("Object hit: " + hit.transform.gameObject.name);
            }
        }
    }
}
