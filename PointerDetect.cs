using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointerDetect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnMouseEnter");
		GetComponent<Text>().color = Color.red;
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		Debug.Log("OnMouseExit");
		GetComponent<Text>().color = Color.white;
    }
}
