using UnityEngine;
//using UnityEditor;
using System.Linq;
using System;

public class Wrapper_Item_Full_Float {
	public static int original_text;
	private Texture2D _texture;
	private Sprite _sprite;
	private float[] red_channel; 
	private float[] green_channel; 
	private float[] blue_channel; 
	private float[] alpha_channel;
	private float[] int_channel; 

	public Wrapper_Item_Full_Float(Texture2D imp_texture, bool primary = false)
	{
		if (!primary) {
			Color[] pixel_array = imp_texture.GetPixels ();
	
			this.red_channel = new float[pixel_array.Length];
			this.green_channel = new float[pixel_array.Length];
			this.blue_channel = new float[pixel_array.Length];
			this.alpha_channel = new float[pixel_array.Length];

			for (var n = 0; n < pixel_array.Length; n++) {
				this.red_channel [n] = (pixel_array [n].r);
				this.green_channel [n] = (pixel_array [n].g);
				this.blue_channel [n] = (pixel_array [n].b);
				this.alpha_channel [n] = (pixel_array [n].a);
			}
			this._texture = imp_texture;
		} else {
			//SetTextureImporterFormat (imp_texture, true);
			Color[] pixel_array = imp_texture.GetPixels ();
			
			this.alpha_channel = new float[pixel_array.Length];
			this.int_channel = new float[pixel_array.Length];

			for (var n = 0; n < pixel_array.Length; n++) {
				float[] array1 = { pixel_array [n].r,  pixel_array [n].g, pixel_array [n].b };
				this.int_channel [n] = (float)array1.Average();
				this.alpha_channel [n] = (pixel_array [n].a);
			}
			this._texture = imp_texture;
			this._sprite = Sprite.Create (imp_texture, (new  Rect (0, 0, imp_texture.width, imp_texture.height)), (new  Vector2 (0.5f, 0.5f)), 1.0f);
			original_text++;
		}
	}

	/*
	private void SetTextureImporterFormat( Texture2D texture, bool isReadable)
	{
		if ( null == texture ) return;
		string assetPath = AssetDatabase.GetAssetPath( texture );
		var tImporter = AssetImporter.GetAtPath( assetPath ) as TextureImporter;
		if ( tImporter != null )
		{
			tImporter.textureType = TextureImporterType.Advanced;
			tImporter.isReadable = isReadable;

			tImporter.maxTextureSize = 800;
			tImporter.wrapMode = TextureWrapMode.Clamp;
			tImporter.textureFormat = TextureImporterFormat.ARGB32;
			
			AssetDatabase.ImportAsset( assetPath );
			AssetDatabase.Refresh();
		}
	}
	*/

	public Wrapper_Item_Full_Float DeepCopy()
	{
		Wrapper_Item_Full_Float other = (Wrapper_Item_Full_Float) this.MemberwiseClone();

		Color[] pixel_array = other.texture.GetPixels ();
		
		other.int_channel = new float[pixel_array.Length];
		
		for (var n = 0; n < pixel_array.Length; n++) {
			//int[] array1 = { pixel_array [n].r,  pixel_array [n].g, pixel_array [n].b };
			//other.int_channel [n] = (int)array1.Average();
			other.int_channel [n] = pixel_array [n].r;
		}
		return other;
	}

	public float[] intensity
	{
		get {return int_channel;}
		set {int_channel = value;}
	}

	public Sprite sprite
	{
		get {return _sprite;}
		set {_sprite = value;}
	}

	public float[] red
	{
		get {return red_channel;}
		set {red_channel = value;}
	}

	public float[] green
	{
		get {return green_channel;}
		set {green_channel = value;}
	}
	
	public float[] blue
	{
		get {return blue_channel;}
		set {blue_channel = value;}
	}

	public float[] alpha
	{
		get {return alpha_channel;}
		set {alpha_channel = value;}
	}

	public Texture2D texture
	{
		get {return _texture;}
		set {_texture = value;}
	}
}
