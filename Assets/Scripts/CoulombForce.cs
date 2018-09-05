using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoulombForce  {
    public static Vector2 Fab(Vector2 originA, Vector2 originB,float qA,float qB){
        float r = (originB - originA).magnitude;
		Vector2 dir; 
		if (r == 0) {//We dont want to divide by 0! 
			r = 0.0001f; 
			dir = Vector2.right; 

		}
		else {
			dir = -(originB - originA).normalized;
		}
        float fMag = 10*qA * qB / Mathf.Pow(r, 2);
  

        return fMag * dir;

       }
	
}
