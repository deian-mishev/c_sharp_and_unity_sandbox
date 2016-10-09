using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FPS_FIX : MonoBehaviour {

	public GameObject send_to;
	public RenderTexture text;
	public bool on;

	public void Catch_Camera()
	{
		if (on) {
			Camera cam = gameObject.GetComponent<Camera> ();
			Texture2D temp = RTImage (cam);
			Sprite img = Sprite.Create (temp, (new  Rect (0, 0, temp.width, temp.height)), (new  Vector2 (0.5f, 0.5f)));
			send_to.SetActive (true);
			send_to.GetComponent<Image> ().color = Color.white;
			send_to.GetComponent<Image> ().overrideSprite = img;
		}
	}
	
	Texture2D RTImage(Camera cam) {
		cam.targetTexture = text;
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = cam.targetTexture;
		cam.Render();
		Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
		image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
		image.Apply();
		RenderTexture.active = currentRT;
		cam.targetTexture = null;
		return image;
	}

	public void Switch()
	{
		if(on){
			this.transform.parent.gameObject.SetActive(false);
			on = false;
		}
		else
		{
			this.transform.parent.gameObject.SetActive(true);
			on = true;
		}
	}
}
