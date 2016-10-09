using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragCamera : MonoBehaviour 
{
	//
	// VARIABLES
	//
	public GameObject send_to;
	public RenderTexture text;
	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isRotating;	// Is the camera being rotated?
	private bool isZooming;		// Is the camera zooming?
	private float intensity;
	private float temp;
	public bool on;

	public void ChangeValue(float val){
		intensity = val;
	}

	public void Catch_Camera()
	{
		if (on) {
			Camera cam = gameObject.GetComponent<Camera> ();
			Texture2D temp = RTImage (cam);
			Sprite img = Sprite.Create (temp, (new  Rect (0, 0, temp.width, temp.height)), (new  Vector2 (0.5f, 0.5f)), 100.0f);
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
			this.gameObject.SetActive(false);
			on = false;
		}
		else
		{
			this.gameObject.SetActive(true);
			on = true;
		}
	}

	void Update () 
	{
		if (intensity == temp) {
			
			// Get the left mouse button
			if (Input.GetMouseButtonDown (0)) {
				if(Input.mousePosition.x > Screen.width/6 && Input.mousePosition.x < (Screen.width - Screen.width/6) ){
					// Get mouse origin
					mouseOrigin = Input.mousePosition;
					isRotating = true;
				}
			}
	
			// Get the right mouse button
			if (Input.GetMouseButtonDown (1)) {
				// Get mouse origin
				mouseOrigin = Input.mousePosition;
				isPanning = true;
			}
	
			// Get the middle mouse button
			if (Input.GetMouseButtonDown (2)) {
				// Get mouse origin
				mouseOrigin = Input.mousePosition;
				isZooming = true;
			}
	
			// Disable movements on button release
			if (!Input.GetMouseButton (0))
				isRotating = false;
			if (!Input.GetMouseButton (1))
				isPanning = false;
			if (!Input.GetMouseButton (2))
				isZooming = false;
	
			// Rotate camera along X and Y axis
			if (isRotating) {
				Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
		
				transform.RotateAround (transform.position, transform.right, -pos.y * turnSpeed);
				transform.RotateAround (transform.position, Vector3.up, pos.x * turnSpeed);
			}
	
			// Move the camera on it's XY plane
			if (isPanning) {
				Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
		
				Vector3 move = new Vector3 (pos.x * panSpeed, pos.y * panSpeed, 0);
				transform.Translate (move, Space.Self);
			}
	
			// Move the camera linearly along Z axis
			if (isZooming) {
				Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
		
				Vector3 move = pos.y * zoomSpeed * transform.forward; 
				transform.Translate (move, Space.World);
			}
		}
		temp = intensity;
	}
}