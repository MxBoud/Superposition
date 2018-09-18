using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChargeContainer : MonoBehaviour
{
    public GameObject chargePrefab;
    private GameObject chargeContainer;
    public List<GameObject> chargeList;


    // Use this for initialization
    void Start()
    {
        chargeContainer = this.gameObject;
        chargeList = new List<GameObject>();
        int childCount = chargeContainer.transform.childCount;
        if (childCount > 0)
        {
            for (int j = 0; j < childCount; j++)
            {
                chargeList.Add(chargeContainer.transform.GetChild(j).gameObject);
            }
        }
    }


    public void AddCharge()
    {
        GameObject newCharge = Instantiate(chargePrefab, chargeContainer.transform);
        //TODO use
        //ChargeController newChargeController = newCharge.GetComponent<ChargeController>();
        //newChargeController = Instantiate(activeObject.GetComponent<ChargeController>());
        newCharge.GetComponent<ChargeController>().spriteColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        chargeList.Add(newCharge);
        UpdateIOOfAllCharges();

    }
    public void RemoveCharge(GameObject chargeToRemove)
    {
        chargeList.Remove(chargeToRemove);
        Destroy(chargeToRemove);

    }
    public void UpdateIOOfAllCharges() {
        foreach (GameObject charge in chargeList){
            charge.GetComponent<ChargeController>().UpdateChargeList();
        }
    }
}