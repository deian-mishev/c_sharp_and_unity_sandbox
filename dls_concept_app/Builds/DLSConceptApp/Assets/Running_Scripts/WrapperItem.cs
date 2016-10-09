using UnityEngine;
using System.Linq;
using System;

using UnityEditor;

namespace DLSConceptAppVisual
{
	// Basically these are the mixxed channels with their setting changed by the GUI.

	public class WrapperItem {
		public static int original_text_number;
		private Texture2D _texture;
		private Sprite _sprite;
		private float _slider;
		private float[] red_channel; 
		private float[] green_channel; 
		private float[] blue_channel; 
		private float[] alpha_channel;
		private float[] int_channel;

		public WrapperItem(Texture2D imp_texture, bool primary = false)
		{
			this._slider = 0.0f;

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
				SetTextureImporterFormat (imp_texture, true);
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
				original_text_number++;
			}
		}


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


		private WrapperItem DeepCopy()
		{
			WrapperItem other = (WrapperItem) this.MemberwiseClone();
	
			Color[] pixel_array = other.texture.GetPixels ();		
			other.int_channel = new float[pixel_array.Length];
			for (var n = 0; n < pixel_array.Length; n++) {
				//int[] array1 = { pixel_array [n].r,  pixel_array [n].g, pixel_array [n].b };
				//other.int_channel [n] = (int)array1.Average();
				other.int_channel [n] = pixel_array [n].r;
			}
			return other;
		}

		public float slider
		{
			get {return this._slider;}
			set {this._slider = value;}
		}

		public float[] intensity
		{
			get {return this.int_channel;}
			set {this.int_channel = value;}
		}

		public Sprite sprite
		{
			get {return this._sprite;}
			set {this._sprite = value;}
		}

		public float[] red
		{
			get {return this.red_channel;}
			set {this.red_channel = value;}
		}

		public float[] green
		{
			get {return this.green_channel;}
			set {this.green_channel = value;}
		}
		
		public float[] blue
		{
			get {return this.blue_channel;}
			set {this.blue_channel = value;}
		}

		public float[] alpha
		{
			get {return this.alpha_channel;}
			set {this.alpha_channel = value;}
		}

		public Texture2D texture
		{
			get {return this._texture;}
			set {this._texture = value;}
		}
	}
}