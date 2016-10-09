using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ColorShift : MonoBehaviour {

	public static Renderer rend;
	public GameObject slider;
	public GameObject gui_image;
	private Texture2D curr_texture_image;
	public static List<Wrapper_Item_Full_Float> wrappers;
	private Wrapper_Item_Full_Float curr_texture;
	private float[][] temp_buffer_1;
	private float[][] temp_buffer_2;
	private float[][] cross_buffer;
	private float[][] switch_buffer;
	private Color last_color;
	private Texture2D blackTexture;
	private Texture2D mat_texture; 
	private int pixel_count;
	private string previous_texture;
	private string new_texture;
	private bool first;
	private GUIStyle style;


	void Start () {
		pixel_count = wrappers [0].texture.width * wrappers [0].texture.height;

		blackTexture = new Texture2D (wrappers [0].texture.width, wrappers [0].texture.height);
		mat_texture = new Texture2D (wrappers [0].texture.width, wrappers [0].texture.height);
		
		var pixel_arr = blackTexture.GetPixels();
		for (var i = 0; i < pixel_arr.Length; i++) {
			pixel_arr [i] = Color.black;
		}

		cross_buffer = new float[3][];
		cross_buffer[0] = new float[pixel_count];
		cross_buffer[1] = new float[pixel_count];
		cross_buffer[2] = new float[pixel_count];

		temp_buffer_1 = new float[3][];
		temp_buffer_1[0] = new float[pixel_count];
		temp_buffer_1[1] = new float[pixel_count];
		temp_buffer_1[2] = new float[pixel_count];

		switch_buffer = new float[3][];
		switch_buffer[0] = new float[pixel_count];
		switch_buffer[1] = new float[pixel_count];
		switch_buffer[2] = new float[pixel_count];

		temp_buffer_2 = new float[3][];
		temp_buffer_2[0] = new float[pixel_count];
		temp_buffer_2[1] = new float[pixel_count];
		temp_buffer_2[2] = new float[pixel_count];

		rend.material.mainTexture = BlendFirst (wrappers);
	}

	public void Reset(){
		pixel_count = wrappers [0].texture.width * wrappers [0].texture.height;
		
		blackTexture = new Texture2D (wrappers [0].texture.width, wrappers [0].texture.height);
		mat_texture = new Texture2D (wrappers [0].texture.width, wrappers [0].texture.height);
		
		var pixel_arr = blackTexture.GetPixels();
		for (var i = 0; i < pixel_arr.Length; i++) {
			pixel_arr [i] = Color.black;
		}
		
		cross_buffer = new float[3][];
		cross_buffer[0] = new float[pixel_count];
		cross_buffer[1] = new float[pixel_count];
		cross_buffer[2] = new float[pixel_count];
		
		temp_buffer_1 = new float[3][];
		temp_buffer_1[0] = new float[pixel_count];
		temp_buffer_1[1] = new float[pixel_count];
		temp_buffer_1[2] = new float[pixel_count];
		
		switch_buffer = new float[3][];
		switch_buffer[0] = new float[pixel_count];
		switch_buffer[1] = new float[pixel_count];
		switch_buffer[2] = new float[pixel_count];
		
		temp_buffer_2 = new float[3][];
		temp_buffer_2[0] = new float[pixel_count];
		temp_buffer_2[1] = new float[pixel_count];
		temp_buffer_2[2] = new float[pixel_count];
		gui_image.SetActive (false);
		slider.SetActive (false);
		rend.material.mainTexture = BlendFirst (wrappers);
	}

	void OnSetColor(object[] tempStorage)
	{
		//slider.SetActive (false);
		//slider.GetComponent<Slider> ().enabled = false;
		//slider.GetComponent<Slider> ().value = 0.0f;
		//slider.GetComponent<Slider> ().enabled = true;
		slider.SetActive (true);

		var a = 0;
		new_texture = tempStorage [1].ToString ();
	
		Color color = (Color)tempStorage[0];
		for(var i = 0;i < wrappers.Count; i++)
		{
			if(wrappers[i].texture.name == tempStorage [1].ToString ())
			{
				a = i;
			}
		}
		curr_texture = wrappers [a];

		gui_image.SetActive (true);
		gui_image.GetComponent<Image> ().overrideSprite = wrappers [a].sprite;
		gui_image.GetComponent<Image> ().color = Color.white;
		rend.material.mainTexture = UpdateBlend (color, curr_texture);
	}

	public void ChangeValue(float val){
		Color new_col = new Color (val, val, val);
		if (curr_texture != null) {
			rend.material.mainTexture = UpdateBlend (new_col, curr_texture);
		}
	}

	Texture2D UpdateBlend (Color col, Wrapper_Item_Full_Float set)
	{
		var pixel_array = mat_texture.GetPixels ();

		if (previous_texture == new_texture) {
			if (first) {
				for (var n = 0; n < pixel_count; n++) {
					temp_buffer_1 [0] [n] = temp_buffer_2 [0] [n] - set.intensity [n] * last_color.r * last_color.a + set.intensity [n] * col.r * col.a;
					temp_buffer_1 [1] [n] = temp_buffer_2 [1] [n] - set.intensity [n] * last_color.g * last_color.a + set.intensity [n] * col.g * col.a;
					temp_buffer_1 [2] [n] = temp_buffer_2 [2] [n] - set.intensity [n] * last_color.b * last_color.a + set.intensity [n] * col.b * col.a;
					
					pixel_array [n].r = temp_buffer_1 [0] [n];
					pixel_array [n].g = temp_buffer_1 [1] [n];
					pixel_array [n].b = temp_buffer_1 [2] [n];
					
					temp_buffer_2 [0] [n] = temp_buffer_1 [0] [n];
					temp_buffer_2 [1] [n] = temp_buffer_1 [1] [n];
					temp_buffer_2 [2] [n] = temp_buffer_1 [2] [n];
				}
			} else {
				for (var n = 0; n < pixel_count; n++) {
					temp_buffer_1 [0] [n] = temp_buffer_2 [0] [n] - set.intensity [n] * last_color.r * last_color.a + set.intensity [n] * col.r * col.a;
					temp_buffer_1 [1] [n] = temp_buffer_2 [1] [n] - set.intensity [n] * last_color.g * last_color.a + set.intensity [n] * col.g * col.a;
					temp_buffer_1 [2] [n] = temp_buffer_2 [2] [n] - set.intensity [n] * last_color.b * last_color.a + set.intensity [n] * col.b * col.a;
					
					pixel_array [n].r = temp_buffer_1 [0] [n];
					pixel_array [n].g = temp_buffer_1 [1] [n];
					pixel_array [n].b = temp_buffer_1 [2] [n];
					
					temp_buffer_2 [0] [n] = temp_buffer_1 [0] [n];
					temp_buffer_2 [1] [n] = temp_buffer_1 [1] [n];
					temp_buffer_2 [2] [n] = temp_buffer_1 [2] [n];
				}
			}
			first = false;
			last_color = col;
		} else {
			for (var n = 0; n < pixel_count; n++) {
				temp_buffer_1 [0] [n] = (temp_buffer_1 [0] [n] + set.intensity [n] * col.r * col.a);
				temp_buffer_1 [1] [n] = (temp_buffer_1 [1] [n] + set.intensity [n] * col.g * col.a);
				temp_buffer_1 [2] [n] = (temp_buffer_1 [2] [n] + set.intensity [n] * col.b * col.a);

				pixel_array [n].r = temp_buffer_1 [0] [n];
				pixel_array [n].g = temp_buffer_1 [1] [n];
				pixel_array [n].b = temp_buffer_1 [2] [n];

				temp_buffer_2 [0][n] = temp_buffer_1 [0] [n];
              	temp_buffer_2 [1][n] = temp_buffer_1 [1] [n];
              	temp_buffer_2 [2][n] = temp_buffer_1 [2] [n];
			}
			first = true;
			last_color = Color.black;
		}

		previous_texture = new_texture;
		mat_texture.SetPixels(pixel_array);
		mat_texture.Apply(true);
		return mat_texture;
	}

	Texture2D BlendFirst(List<Wrapper_Item_Full_Float> holders)
	{
		for (var i = 0; i < holders.Count; i++) {
			for (var n = 0; n < pixel_count; n++) {
				temp_buffer_1[0][n] += holders [i].intensity [n];
				temp_buffer_1[1][n] += holders [i].intensity [n];
				temp_buffer_1[2][n] += holders [i].intensity [n];
			}
		}

		var pixel_array = mat_texture.GetPixels();
		for(var n = 0; 	n < pixel_count; n++)
		{
			pixel_array[n].r = Convert.ToSingle (temp_buffer_1 [0] [n]);
			pixel_array[n].g = Convert.ToSingle (temp_buffer_1 [1] [n]);
			pixel_array[n].b = Convert.ToSingle (temp_buffer_1 [2] [n]);
			pixel_array[n].a = 1.0f;
		}

		mat_texture.SetPixels(pixel_array);
		mat_texture.Apply(true);
		return mat_texture;
	}

	void OnGetColor(object[] tempStorage)
	{
		//Debug.Log (tempStorage[0].GetType());
		//Debug.Log (tempStorage[0]);
		//Debug.Log (tempStorage[1].GetType());
		//Debug.Log (tempStorage[1]);
	}
}
