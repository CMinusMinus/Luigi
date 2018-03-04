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

			// Object[] levels = 
			TextAsset[] textLevels = Resources.LoadAll<TextAsset>("Levels/GeneratedAssets"); //new TextAsset[levels.Length];
			// for(int ii = 0; ii < levels.Length; ii++) {
			// 	textLevels[ii] = (TextAsset)levels[ii];
			// }

			// Debug.Log(textLevels.Length);
			List<OgmoLevel> levelList = new List<OgmoLevel>();
			for (int ii = 0; ii < textLevels.Length; ii++) {	
				levelList.Add(new OgmoLevel(textLevels[ii]));
			}

			// foreach(OgmoLevel level in levelList){
				
			// }

			// Debug.Log(levelList.ToString());
		
			OgmoLevel firstLevel = levelList[0];

			OgmoLayer Ground = firstLevel.layers["Ground"];

			Debug.Log(Ground.tiles[0,0]);
			                                            

		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
}