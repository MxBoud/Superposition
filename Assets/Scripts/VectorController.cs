using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VectorController : MonoBehaviour {
    public Vector2 origin; 
    public Vector2 vector;
    public Vector2 initHeadScale = new Vector3(1, 0.2f, 1);
    private float magnitude; 

    public GameObject tailSprite;
    public GameObject headSprite;


   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Update Have been called");
        magnitude = vector.magnitude; 
        tailSprite.transform.position = origin; 
        tailSprite.transform.localScale = new Vector3(magnitude-0.1f,0.2f,1);
        if (magnitude < 1f){
            headSprite.transform.localScale = initHeadScale*magnitude/1f; 
            tailSprite.transform.localScale = new Vector3(0.9f*magnitude, 0.2f*magnitude, 1);
        }
        else {
            headSprite.transform.localScale = initHeadScale; 
        }
        headSprite.transform.position =  origin + vector;
        float angle = Mathf.Atan2(vector.y, vector.x)*Mathf.Rad2Deg;
        tailSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle ));
        headSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
       // this.transform.rotation = Qu

	}


    public void SetVector(Vector2 _origin, Vector2 _vector,Color spriteColor) {
        origin = _origin;
        vector = _vector; 

        tailSprite.GetComponent<SpriteRenderer>().color = spriteColor;
        headSprite.GetComponent<SpriteRenderer>().color = spriteColor;
    }
}
