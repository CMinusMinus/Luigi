using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ogmo {
	public class MapGeneraor : MonoBehaviour {

		public GameObject square;
		public GameObject kill;
		public GameObject player;
		int width;
		int height;
	

		// Use this for initialization
		void Start () {
			
			// Instantiate(square,new Vector3(1,1,0),Quaternion.identity);
			// Instantiate(square,new Vector3(2,1,0),Quaternion.identity);
			// Instantiate(square,new Vector3(1,2,0),Quaternion.identity);
			// Instantiate(square,new Vector3(2,2,0),Quaternion.identity);
			
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
			OgmoLayer Hazards = firstLevel.layers["Hazards"];
			OgmoLayer Entities = firstLevel.layers["Entities"];

			for (int ii = 0; ii < Ground.tiles.GetLength(0); ii++) {
				for (int jj = 0; jj < Ground.tiles.GetLength(1); jj++) {
					if (Ground.tiles[ii, jj] == 1) {
						//Debug.Log(Ground.tiles[ii, jj] + " X: "+ ii + " Y: " + jj);
						Instantiate(square,new Vector2(ii, Ground.tiles.GetLength(1)-jj),Quaternion.identity);
					}
					else if(Hazards.tiles[ii,jj] == 1){
						Instantiate(kill,new Vector2(ii, Ground.tiles.GetLength(1)-jj),Quaternion.identity);
					}
				}
			}
			foreach (OgmoEntity entity in Entities.entities)
			{
				Debug.Log(entity.x + " , " + entity.y);
				Instantiate(player, new Vector3(entity.x/32,entity.y/32,0),Quaternion.identity);
			}

			                                            

		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
}