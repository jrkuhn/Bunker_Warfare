using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
    /*
    public float zoom;
    public float zoomSpeed = 2;
    public float zoomMax = -2f;
    public float zoomMin = -10f;
    */
    // Use this for initialization
    void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
     
  /*
        zoom += Input.GetAxis("Mouse ScrollWheel") + zoomSpeed;
      
        if (zoom > zoomMin)
        {
            zoom = zoomMin;
        }

        if (zoom < zoomMax)
        {
            zoom = zoomMax;
        }

        transform.position = new Vector3(zoom, zoom, zoom); */
        transform.position = player.transform.position + offset;
	}
}
