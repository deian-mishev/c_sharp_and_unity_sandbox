using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

public class MaxToUnity : MonoBehaviour {

	private List<ColorPicker> mColorPickerList;
	private ColorPicker colorPicker;
	private float counter;
	private GameObject source;

	public void Reset(){
		Destroy (source);
		model_importer ();
		foreach (ColorPicker elem in mColorPickerList) {
			elem.NotifyColor(Color.gray);
		}
		ColorShift.wrappers = init_textures();
		var hello = GameObject.Find ("Script Controller").GetComponent<ColorShift> ();
		hello.Reset ();
	}

	void Awake()
	{
		model_importer ();
		set_camera ();
		handle_gui ();
	}

	void OnGUI ()
	{
		foreach(var elem in mColorPickerList)
		{
			elem._DrawGUI();
		}
	}
	
	List<Wrapper_Item_Full_Float> init_textures()
	{
		List<Wrapper_Item_Full_Float> Image_Wrappers = new List<Wrapper_Item_Full_Float>();
		var textures = Resources.LoadAll("surface_textures");
		
		for(var i = 0; i < textures.Length ; i++)
		{	
			Texture2D texture = textures[i] as Texture2D;
			Wrapper_Item_Full_Float item = new Wrapper_Item_Full_Float(texture, primary: true);
			Image_Wrappers.Add(item);
		}
		return Image_Wrappers;
	}

	void set_camera()
	{
		GameObject cam = GameObject.Find ("MainCamera");
		GameObject cont = GameObject.Find ("FPSController");
		Renderer rend = source.GetComponent<MeshRenderer> ();
		cam.transform.position = rend.bounds.center;
		cont.transform.position = rend.bounds.center;
		cont.SetActive (false);
		cam.SetActive (true);
	}

	void model_importer()
	{
		source = Instantiate (Resources.Load (("fbx/model"), typeof(GameObject))) as GameObject;

		Renderer rend = source.GetComponent<MeshRenderer> ();

		source.transform.position = Vector3.zero;
		if (source.GetComponent<MeshRenderer> () == null) {
			source.AddComponent<MeshRenderer> ();
		}

		if (source.GetComponent<MeshCollider> () == null) {
			source.AddComponent<MeshCollider> ();
		}

		source.transform.position = Vector3.zero;
		rend.material = Resources.Load ("materials/unlit_surface_material", typeof(Material)) as Material;

		ColorShift.rend = rend;
	}

	void handle_gui()
	{
		int counter = 20;
		colorPicker = GameObject.FindObjectOfType<ColorPicker> ();
		List<Wrapper_Item_Full_Float> wrappers = init_textures();
		mColorPickerList = new List<ColorPicker>();

		for (int i = 0; i < wrappers.Count; i++) {
			ColorPicker colorPicker_clone = (ColorPicker) Instantiate(colorPicker);
			colorPicker_clone.drawOrder = i;
			colorPicker_clone.Title = wrappers [i].texture.name; 
			colorPicker_clone.startPos.y = counter;
			mColorPickerList.Add(colorPicker_clone);
			counter += 25;
		}

		mColorPickerList = mColorPickerList.OrderBy(item => item.drawOrder).ToList ();
		mColorPickerList.Reverse ();

		ColorShift.wrappers = wrappers;
	}
}
