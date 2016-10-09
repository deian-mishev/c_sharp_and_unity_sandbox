using UnityEngine;
using System;
using System.Collections;

public class CameraRunner : MonoBehaviour {

	private Camera main_camera;
	private GameObject main_img;
	private	GameObject selected;
	private Camera selected_camera;
	private obj_handler selected_handler;
	private bool send_ray = true;

	public void Jello(){
		send_ray = false;
		float img_width = main_img.GetComponent<RectTransform> ().rect.width;
		float img_height = main_img.GetComponent<RectTransform> ().rect.height;
		float x = (Math.Abs(((Screen.width - 5.0f) - Input.mousePosition.x) - img_width))/img_width;
		float y = (Math.Abs(((Screen.height - 5.0f) - Input.mousePosition.y) - img_height))/img_height;
		Vector3 mousePosition = new Vector3(x,y, 0);

		RaycastHit hit;
		Ray ray = selected_camera.ViewportPointToRay(mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
		if (Physics.Raycast(ray,out hit))
		{
			//GameObject objectHit = hit.transform.gameObject;
			selected_handler.StartMove (hit.point);
		}
	}

	void Start(){
		Messenger<GameObject>.AddListener("was_selected", OnClick);
		main_camera = GetComponent<Camera>();
		main_img = GameObject.Find ("RawImage");
		main_img.SetActive (false);
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && send_ray) {
			RaycastHit hit;
			Ray _ray = main_camera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (_ray, out hit)) {
				GameObject objectHit = hit.transform.gameObject;
				bool foo = objectHit.CompareTag("Luminaire") ? true : false;
				main_img.SetActive (foo);
				Messenger<GameObject>.Broadcast("selected", objectHit);
			}
		}
		send_ray = true;
	}

	void OnClick(GameObject obj){
		selected = obj;
		selected_camera = selected.transform.FindChild ("CubeCamera").gameObject.GetComponent<Camera>();
		selected_handler = (obj_handler) selected.GetComponent(typeof(obj_handler));
	}
}
