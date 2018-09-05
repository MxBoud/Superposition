using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SceneSettingsManager:MonoBehaviour{
	[SerializeField]
	public static bool showNetVector {
		get {
			return _showNetVector; 
		}
		set {
			_showNetVector = value;
			//BroadcastMessage ("SceneSettingManagerChanged", SendMessageOptions.DontRequireReceiver); 
		}
	}
	private static bool _showNetVector = true; 
	public bool showVectorPairs = true; 
	public bool allVectorsAtOrigin{
		get {
			return _allVectorsAtOrigin; 
		}
		set {
			_allVectorsAtOrigin = value;
			//BroadcastMessage ("SceneSettingManagerChanged", SendMessageOptions.DontRequireReceiver); 
		}
	}
	private bool _allVectorsAtOrigin = true; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
