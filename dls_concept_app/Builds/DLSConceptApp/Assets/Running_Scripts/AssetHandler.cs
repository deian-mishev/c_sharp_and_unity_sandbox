using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace DLSConceptAppHandling
{
	public class AssetHandler {

		private List<Texture2D> textures;
		private GameObject room_geometry;
		private GameObject source;
		private Renderer rend;

		public AssetHandler(string folder, Camera cam) {
			InitAssets (folder);
			Model_Importer ();
			SetCamera (cam);
		}

		public List<Texture2D> _tex {
			get {return this.textures;}
		}

		public Renderer _rend {
			get {return this.rend;}
		}

		public void Reset(){
			MonoBehaviour.Destroy (room_geometry);
			Model_Importer ();
		}

		public void InitAssets (string folder) {
		
			textures = new List<Texture2D>(); 
			source = new GameObject();
			
			var assets = Resources.LoadAll(folder);
			for(var i = 0; i < assets.Length ; i++)
			{
				if (assets[i].GetType() == typeof(Texture2D))
				{
					Texture2D texture = assets[i] as Texture2D;
					textures.Add(texture);
				}
				else if (assets[i].GetType() == typeof(GameObject))
				{
					source = assets[i] as GameObject;
				}
			}
		}

		private void Model_Importer() {

			room_geometry = MonoBehaviour.Instantiate(source);

			if (room_geometry.transform.GetChild(0).gameObject.GetComponent<MeshRenderer> () == null) {
				room_geometry.transform.GetChild(0).gameObject.AddComponent<MeshRenderer> ();
			}
			if (room_geometry.transform.GetChild(0).gameObject.GetComponent<MeshCollider> () == null) {
				room_geometry.transform.GetChild(0).gameObject.AddComponent<MeshCollider> ();
			}

			room_geometry.transform.position = Vector3.zero;
			rend = room_geometry.transform.GetChild(0).gameObject.GetComponent<MeshRenderer> ();
			rend.material = Resources.Load ("materials/unlit_surface_material", typeof(Material)) as Material;
		}

		private void SetCamera(Camera cam) {
			cam.transform.position = rend.bounds.center;
			cam.enabled = true;
		}
	}
}