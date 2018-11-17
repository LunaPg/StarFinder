using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quantityDisplay : MonoBehaviour {

    private Slider sliderAmount;
    public Text textAmount;
    // Use this for initialization
    void Start () {
        sliderAmount = GetComponent<Slider>();
        sliderAmount.value = 1; 
        textAmount.text = 1.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        textAmount.text = sliderAmount.value.ToString();
	}
}
