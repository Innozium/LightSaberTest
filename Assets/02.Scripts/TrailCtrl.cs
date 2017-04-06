using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCtrl : MonoBehaviour {

    private Transform tr;
    private TrailRenderer trailRenderer;

    private bool is_DownCheck;
    private float firstTime = 0.0f;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0))
        {
            if (!is_DownCheck) is_DownCheck = true;
            //print("dd");
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            clickPosition.z = 0;

            //print(Input.mousePosition);
            //print(clickPosition);

            tr.position = clickPosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            is_DownCheck = false;
            firstTime = 0.0f;
            trailRenderer.time = 0.1f;
        }

        if(is_DownCheck)
        {
            firstTime += Time.deltaTime;
        }

        if(firstTime > 0.5f)
        {
            if (trailRenderer.time < 0.5f) trailRenderer.time += 0.1f;
            else if (trailRenderer.time >= 0.5f) trailRenderer.time = 0.4f;
        }

	}
}
