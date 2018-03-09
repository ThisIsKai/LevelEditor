using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelEditor : MonoBehaviour {	// LevelEditor Script
	
	public string levelFile = "level1.txt";																		// the file with the level building text
		
	public float tileWidth = 1f;																				// the width of the prefab
	public float tileHeight = 1f;																				// the height of the prefab

	public GameObject floorPrefab;																				// _
	public GameObject wallPrefab; 																				// i
	public GameObject playerPrefab;																				// o
	public GameObject blockPrefab;																				// x
	public GameObject dangerPrefab;																				// w


	void Start () {																								// START FUNCTION
	string levelString = File.ReadAllText(Application.dataPath + Path.DirectorySeparatorChar + levelFile);		// reading the file into string.
	string[] levelLines = levelString.Split('\n');																// splitting the string into lines.
			int width = 0;
			
		for (int row = 0; row < levelLines.Length; row++) {														// iterating over the lines.
				string currentLine = levelLines[row];
				width = currentLine.Length;

			for (int col = 0; col < currentLine.Length; col++) {												// iterating over all the chars in a line.
					char currentChar = currentLine[col];

																												// ** BLOCK MAKING STUFF **
				if (currentChar == 'x') { 																		// IF the character in the file is 'x'					
					GameObject blockObj = Instantiate(blockPrefab);												// THEN instantiate a block
						blockObj.transform.parent = transform;													// AND get the transform
						blockObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);			// AND put it here
					} // end if block

																												// ** PLAYER MAKING STUFF **
				else if (currentChar == 'o') {																	// ELSE IF the character in the file is 'o'
					GameObject playerObj = Instantiate(playerPrefab);											// THEN instantiate the player
						playerObj.transform.parent = transform;													// AND get the transform
						playerObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);			// AND put it here
					} // end if player

																												// ** WALL MAKING STUFF **
				else if (currentChar == 'i') {																	// ELSE IF the character in the file is 'i'
					GameObject wallObj = Instantiate(wallPrefab);												// THEN instantiate the wall
					wallObj.transform.parent = transform;														// AND get the transform
					wallObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);				// AND put it here
				} // end if wall
																												// ** FLOOR MAKING STUFF **
					else if (currentChar == '_') {																// ELSE IF the character in the file is '_' 
					GameObject floorObj = Instantiate(floorPrefab);												// THEN instantiate the floor
					floorObj.transform.parent = transform;														// AND get the transform
					floorObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);				// AND put it here
				} // end if floor

																												// ** DANGER MAKING STUFF **
					else if (currentChar == 'w') { 																// ElSE IF the character in the file is 'w', THEN
					if (Random.value <= 0.5f) {																	// IF the random number is bigger than .5,(here we are giving it 50/50
																												// chances because random.value returns a number between 0 and 1) 
							GameObject dangerObj = Instantiate(dangerPrefab); 									// THEN instantiate the danger thing
							dangerObj.transform.parent = transform;												// AND get the transform
							dangerObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);		// AND put it here
						} // end else if 50/50 chance
					} // end if danger stuff
				} // end inside for loop
			} // end outside for loop

			float myX = -(width*tileWidth)/2f + tileWidth/2f;
			float myY = (levelLines.Length*tileHeight)/2f - tileHeight/2f;
			transform.position = new Vector3(myX, myY, 0);

			// ~~ If we were centering the level by moving the camera
			// ~~ float cameraY = -(levelLines.Length*tileHeight)/2f + tileHeight/2f;
			// ~~ float cameraX = (width*tileWidth)/2f - tileWidth/2f;
			// ~~ Camera.main.transform.position = new Vector3(cameraX, cameraY, -10);

		} // END START

	} // END LEVEL EDITOR SCRIPT
