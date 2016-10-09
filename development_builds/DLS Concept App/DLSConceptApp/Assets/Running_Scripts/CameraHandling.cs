using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DLSConceptAppHandling
{
	public class CameraHandling : MonoBehaviour {
		private Camera cam;
		private GameObject backplate1, backplate2, send_to;
		private bool isPanning, isRotating, isZooming;

		public float turnSpeed = 4.0f;		
		public float panSpeed = 4.0f;		
		public float zoomSpeed = 4.0f;	

		private float intensity;
		private float temp;
		
		private Vector3 mouseOrigin;
		public bool on;

		public void Init(){
			cam = this.gameObject.GetComponent<Camera> ();
			send_to = GameObject.Find("CaptureImage");
			backplate1 = GameObject.Find ("CaptureImage_backplate_1");
			backplate2 = GameObject.Find ("CaptureImage_backplate_2");
			backplate1.SetActive(false);
			backplate2.SetActive(false);
			send_to.SetActive (false);
		}

		public void Reset() {
			backplate1.SetActive(false);
			backplate2.SetActive(false);
			send_to.SetActive (false);
		}

		public void ChangeValue(float val){
			intensity = val;
		}

		public void Catch_Camera(){
			if (on) {
				Texture2D temp = RTImage (cam);
				Sprite img = Sprite.Create (temp, (new  Rect (0, 0, temp.width, temp.height)), (new  Vector2 (0.5f, 0.5f)), 100.0f);
				backplate1.SetActive(true);
				backplate2.SetActive(true);
				send_to.SetActive (true);
				send_to.GetComponent<Image> ().color = Color.white;
				send_to.GetComponent<Image> ().overrideSprite = img;
			}
		}

		Texture2D RTImage(Camera cam){
			cam.targetTexture = new RenderTexture (1024, 1024, 16);
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

		void Update (){
			if (intensity == temp) {
				   
				if (Input.GetMouseButtonDown (0)) {
					if(Input.mousePosition.x > Screen.width/6 && Input.mousePosition.x < (Screen.width - Screen.width/6) ){
						mouseOrigin = Input.mousePosition;
						isRotating = true;
					}
				}
				if (Input.GetMouseButtonDown (1)) {
					mouseOrigin = Input.mousePosition;
					isPanning = true;
				}
				if (Input.GetMouseButtonDown (2)) {
					mouseOrigin = Input.mousePosition;
					isZooming = true;
				}
				if (!Input.GetMouseButton (0))
					isRotating = false;
				if (!Input.GetMouseButton (1))
					isPanning = false;
				if (!Input.GetMouseButton (2))
					isZooming = false;
				if (isRotating) {
					Vector3 pos = cam.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
					transform.RotateAround (transform.position, transform.right, -pos.y * turnSpeed);
					transform.RotateAround (transform.position, Vector3.up, pos.x * turnSpeed);
				}
				if (isPanning) {
					Vector3 pos = cam.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
					Vector3 move = new Vector3 (pos.x * panSpeed, pos.y * panSpeed, 0);
					transform.Translate (move, Space.Self);
				}
				if (isZooming) {
					Vector3 pos = cam.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
					Vector3 move = pos.y * zoomSpeed * transform.forward; 
					transform.Translate (move, Space.World);
				}
				if (Input.GetKey("escape"))
					Application.Quit();
			}
			temp = intensity;
		}
	}
}