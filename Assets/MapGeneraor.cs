using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ogmo {
	public class MapGeneraor : MonoBehaviour {

		public GameObject square;
		int width;
		int height;
	

		// Use this for initialization
		void Start () {
			/*
			Instantiate(square,new Vector3(1,1,0),Quaternion.identity);
			Instantiate(square,new Vector3(2,1,0),Quaternion.identity);
			Instantiate(square,new Vector3(1,2,0),Quaternion.identity);
			Instantiate(square,new Vector3(2,2,0),Quaternion.identity);
			*/
			string levelFolder = "Levels";

			Object[] levels = Resources.LoadAll(levelFolder + "/GeneratedAssets", typeof(TextAsset));
			TextAsset[] textLevels = new TextAsset[levels.Length];
			for(int ii = 0; ii < levels.Length; ii++) {
				textLevels[ii] = (TextAsset)levels[ii];
			}
			List<OgmoLevel> levelList = new List<OgmoLevel>();
			for (int ii = 0; ii < textLevels.Length; ii++) {	
				levelList.Add(new OgmoLevel(textLevels[ii]));
			}

		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}