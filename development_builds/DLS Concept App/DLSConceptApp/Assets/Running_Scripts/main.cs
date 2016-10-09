using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class main : MonoBehaviour {

	private DLSConceptAppHandling.AssetHandler Asset_Handler;
	private DLSConceptAppHandling.CameraHandling Camera_Handler;
	private DLSConceptAppVisual.ColorShift ColorShift;
	private DLSConceptAppVisual.GUIHandler Gui_Handler;

	void Start () 
	{
		GameObject cam_obj = GameObject.Find ("MainCamera");
		Camera cam = cam_obj.GetComponent<Camera>();
		Camera_Handler = (DLSConceptAppHandling.CameraHandling)cam_obj.GetComponent("CameraHandling");
		Camera_Handler.Init();
		Asset_Handler = new DLSConceptAppHandling.AssetHandler("www", cam);
		Gui_Handler = new DLSConceptAppVisual.GUIHandler(Asset_Handler._tex);
		ColorShift = new DLSConceptAppVisual.ColorShift(Asset_Handler._rend, Gui_Handler._wrappers);
	}
	
	void OnGUI ()
	{
		foreach(var elem in Gui_Handler._mColorPickerList)
		{
			elem._DrawGUI();
		}
	}
	
	public void ChangeValue(float val){
		ColorShift.ChangeValue(val);
	}
	
	private void OnSetColor(object[] tempStorage)
	{
		ColorShift.PublicColorShift(tempStorage);
	}

	private void OnGetColor(object[] tempStorage)
	{
		//Debug.Log("Init :" + tempStorage[1].ToString());
	}
	
	void Restart() 
	{
		foreach (var elem in Gui_Handler._mColorPickerList) {
			elem.NotifyColor(Color.gray);
		}
		Camera_Handler.Reset();
		ColorShift.Reset();
	}
}