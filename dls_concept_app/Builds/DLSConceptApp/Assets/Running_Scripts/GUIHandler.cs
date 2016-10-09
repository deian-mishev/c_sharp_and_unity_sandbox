using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DLSConceptAppVisual
{
	public class GUIHandler {

		private List<ColorPicker> mColorPickerList;
		private ColorPicker ColorPicker;
		private List<WrapperItem> wrappers;
		private WrapperItem curr_texture;

		public GUIHandler(List<Texture2D> tex) {
			int counter = 20;
			ColorPicker = GameObject.FindObjectOfType<ColorPicker> ();
			mColorPickerList = new List<ColorPicker>();

			wrappers = CreateWrappers(tex);

			for (int i = 0; i < wrappers.Count; i++) {
				ColorPicker colorPicker_clone = (ColorPicker) MonoBehaviour.Instantiate(ColorPicker);
				colorPicker_clone.drawOrder = i;
				colorPicker_clone.Title = wrappers [i].texture.name; 
				colorPicker_clone.startPos.y = counter;
				mColorPickerList.Add(colorPicker_clone);
				counter += 25;
			}
			mColorPickerList = mColorPickerList.OrderBy(item => item.drawOrder).ToList ();
			mColorPickerList.Reverse ();
		}

		public List<ColorPicker> _mColorPickerList
		{
			get {return this.mColorPickerList;}
		}
		
		public List<WrapperItem> _wrappers
		{
			get {return this.wrappers;}
		}

		List<WrapperItem> CreateWrappers(List<Texture2D> tex) {
			List<WrapperItem> Image_Wrappers = new List<WrapperItem>();
			for(var i = 0; i < tex.Count() ; i++)
			{
				if (tex[i].GetType() == typeof(Texture2D))
				{
					Texture2D texture = tex[i] as Texture2D;
					WrapperItem item = new WrapperItem(texture, primary: true);
					Image_Wrappers.Add(item);
				}
			}
			return Image_Wrappers;
		}
	}
}
