using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Bound bound; 
	private float zPosition; 
	private float zTargetPosition; 
	public float zMin = 3f; 
	public float zMax = 50f;
	public float zScrollSpeed = 10; 
	public Camera thisCamera;
    public float translateSpeed = 1; 
	Vector3 cameraTargetPosition; 


	// Use this for initialization
	void Start () {
		thisCamera = GetComponent<Camera>();
		zTargetPosition = thisCamera.orthographicSize;
		cameraTargetPosition = thisCamera.transform.position;
	}



	// Update is called once per frame
	void Update () {
		
		zTargetPosition= Mathf.Clamp (zTargetPosition-Input.mouseScrollDelta.y, zMin, zMax); 
		zPosition = Mathf.Lerp (zPosition, zTargetPosition, zScrollSpeed * Time.deltaTime);
		thisCamera.orthographicSize = zPosition;
		//Debug.Log (zTargetPosition); 


        if (Input.GetKey(KeyCode.W)){
			cameraTargetPosition += Vector3.up * translateSpeed * Time.deltaTime; 

        }
		if (Input.GetKey(KeyCode.S)){
			cameraTargetPosition += Vector3.down * translateSpeed * Time.deltaTime; 
		}
		if (Input.GetKey(KeyCode.A)){
			cameraTargetPosition += Vector3.left * translateSpeed * Time.deltaTime; 
		}
		if (Input.GetKey(KeyCode.D)){
			cameraTargetPosition += Vector3.right * translateSpeed * Time.deltaTime; 
		}

		cameraTargetPosition.x = Mathf.Clamp (cameraTargetPosition.x, bound.xMin, bound.xMax); 
		cameraTargetPosition.y = Mathf.Clamp (cameraTargetPosition.y, bound.yMin, bound.yMax); 

		thisCamera.transform.position = Vector3.Lerp (thisCamera.transform.position, cameraTargetPosition, Time.deltaTime * 10); 

	}

}

[System.Serializable]
public class Bound {
	public float xMin; 
	public float xMax; 
	public float yMin; 
	public float yMax; 
}
