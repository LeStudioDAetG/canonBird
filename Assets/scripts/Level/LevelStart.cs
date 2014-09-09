using UnityEngine;
using System.Collections.Generic;

public class LevelStart : LevelBase
{	
	Transform startPosition_;
	
	//***************************************
	// Unity functions
	
	void Start()
	{
		
	}
	
	void Update()
	{
		
	}
	
	
	//***************************************
	// Unity functions
	
	void Init(Canon lastCanon, Transform startPosition)
	{
		// Last Canon must be null for the start

		PlaceFirstCanon();
	}


	void PlaceFirstCanon()
	{
		GameObject oCanon = (GameObject) Instantiate (GameManager.canonBaseWeak);
		Canon canon = oCanon.GetComponent<Canon>();


		AddCanon (canon);
	}
	
}