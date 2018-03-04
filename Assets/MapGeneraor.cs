using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ogmo {
	public class MapGeneraor : MonoBehaviour {

		public GameObject square;
		int width;
		int height;

		string levelFolder = "Levels";

		Object[] levels = Resources.LoadAll(levelFolder + "/GeneratedAssets", typeof(TextAsset));

		List<OgmoLevel> levels = new List<OgmoLevel>();
		for (int ii = 0; ii < rooms.Length; ii++){	
			levels.Add(new OgmoLevel(rooms[ii] as OgmoLevel);
		}	

		// Use this for initialization
		void Start () {
			/*
			Instantiate(square,new Vector3(1,1,0),Quaternion.identity);
			Instantiate(square,new Vector3(2,1,0),Quaternion.identity);
			Instantiate(square,new Vector3(1,2,0),Quaternion.identity);
			Instantiate(square,new Vector3(2,2,0),Quaternion.identity);
			*/


		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}