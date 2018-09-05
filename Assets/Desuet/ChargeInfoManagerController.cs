using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeInfoManagerController : MonoBehaviour {

    public float toggleSpeed = 1;
    private ChargeController chargeController; 

    bool showHide = true;
    float hidePosition = 10;
    float showPosition = 190;
    float targetPos;
     public RectTransform buttonSpriteRectTransform; 
    RectTransform rectTransform;
    public Text chargePositionText; 
	// Use this for initialization
	void Start () {
        targetPos = 190; 
        rectTransform = GetComponent<RectTransform>();
        //buttonSpriteRectTransform =
	}
	
	// Update is called once per frame
	void Update () {
        float currentPos = rectTransform.anchoredPosition.y;
        if (Mathf.Abs(targetPos-currentPos)>0.1f){
            currentPos = Mathf.Lerp(currentPos, targetPos, Time.deltaTime * toggleSpeed);
            
        }
        rectTransform.anchoredPosition = new Vector2(0, currentPos);
        UpdateInterface(); 
	}
    void UpdateInterface() {
        if (chargeController !=null){
            string text = "Charge position = " +
                chargeController.transform.position.x.ToString() +
                                "," +
                                chargeController.transform.position.y.ToString() +
                                "," +
                                chargeController.transform.position.z.ToString();

            chargePositionText.text = text; 

        }
        else {
            chargePositionText.text = "No charge selected";
        }
    }
    public void ShowHideChargeInfoPanel(){
        if (showHide){
            showHide = false;
            targetPos = hidePosition;
            buttonSpriteRectTransform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else {
            showHide = true; 
            targetPos = showPosition; 
            buttonSpriteRectTransform.rotation = Quaternion.Euler(0, 0, -90);

        }
        
        
    }

    public void SetActiveCharge(ChargeController _chargeController){
        //Deactivate current actice 
        if (chargeController != null){
          //  chargeController.UnsetToActiveComponent();
        }
        chargeController = _chargeController;
        UpdateInterface(); 
    }
}
