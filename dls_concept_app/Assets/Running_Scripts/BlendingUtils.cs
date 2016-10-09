using UnityEngine;
using System.Collections;	

public class BlendingUtils : MonoBehaviour {

	public Texture2D firstTexture;
	public Texture2D secondTexture;
	public Texture2D thirdTexture;
	public static GameObject source;
	private Texture2D newTexture;
	private bool triggerChange = false;
	private float changeCount = 1.0f;

	void Start () {
		Debug.Log (source);
		source.GetComponent<Renderer>().material = Resources.Load("materials/TextureChange", typeof(Material)) as Material;
		source.GetComponent<Renderer>().material.SetFloat( "_Blend", 1 );
	}

	public void changeTexture(float myArg) {
		StartCoroutine(MyMethod(0.3f)); 

		if(myArg == 1) {
			newTexture = firstTexture;
		} else if (myArg == 2){
			newTexture = secondTexture;
		} else if (myArg == 3){
			newTexture = thirdTexture;
		}
		
		source.GetComponent<Renderer>().material.mainTexture = newTexture;
		triggerChange = true;
	}
	
	IEnumerator MyMethod(float sec) {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(sec);
		Debug.Log("After Waiting 2 Seconds");
	}

	void Update () {
		if(triggerChange == true) {
			changeCount = changeCount - 0.05f;
			source.GetComponent<Renderer>().material.SetFloat( "_Blend", changeCount );

			if(changeCount <= 0) {
				triggerChange = false;
				changeCount = 1.0f;
				source.GetComponent<Renderer>().material.SetTexture ("_Texture2", newTexture);
				source.GetComponent<Renderer>().material.SetFloat( "_Blend", 1);
			}
		}
	}
}
