using UnityEngine;
using System.Collections;

public class Grow_OnMouseOver : MonoBehaviour 
{
	public void Grow(GameObject val){

		StartCoroutine(WaitAndPrint(val));
	}

	IEnumerator WaitAndPrint(GameObject val) {

		var temp = val.GetComponent<RectTransform> ().position;
		
		val.GetComponent<RectTransform> ().sizeDelta = new Vector2( 500, 500);
		val.GetComponent<RectTransform> ().position = new Vector2( Screen.width/4, Screen.height/2);
		
		yield return new WaitForSeconds(4.0f);
		
		val.GetComponent<RectTransform> ().sizeDelta = new Vector2( 80, 80);
		val.GetComponent<RectTransform> ().position = temp;
	}
}