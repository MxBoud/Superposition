using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class ActiveObjectManager : MonoBehaviour {
	public SceneManager sceneManager; 
	public bool background; 
	public GameObject activeIndicator; 


	// Use this for initialization
	void Start () {
		if (sceneManager == null) {
			sceneManager = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown() {
        sceneManager.SceneObjectMouseDown();
		
		if (!background) {
			sceneManager.SetActiveObject (this); 
            Debug.Log(this);

		} else {
			sceneManager.SetActiveObject (null); 
            Debug.Log("BackGround");
		}

	}

	public void SetIndicatorActive() {
		if (activeIndicator != null) {
			activeIndicator.SetActive (true); 
		}

		
	}
	public void SetIndicatorUnactive() {
		if (activeIndicator != null) {
			activeIndicator.SetActive (false);
		}
	}
	void OnMouseOver(){ // If the current selection is active toggle inspector
        if (activeIndicator.activeSelf){
            //To do : Program a cooldown
            if (Input.GetMouseButtonDown(1))
            {
                sceneManager.ToggleInspector();

            }
        }

	}

   // public void OnPointerClick(PointerEventData eventData)
    //{
        //Debug.Log(eventData);
        //throw new System.NotImplementedException();
    //}
}
