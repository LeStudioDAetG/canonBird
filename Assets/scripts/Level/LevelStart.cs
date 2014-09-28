using UnityEngine;
using System.Collections.Generic;

public class LevelStart : LevelBase
{	
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
	
	public override void Init(Canon lastCanon, Vector4 coordonates)
	{
		// Last Canon must be null for the start
		base.Init (lastCanon, coordonates);
		PlaceFirstCanon();
	}


	void PlaceFirstCanon()
	{
		GameObject oCanon = (GameObject) Instantiate (GameManager.instance.canonBaseWeak);
		Canon canon = oCanon.GetComponent<Canon>();

		AddCanon (canon);

		canon.Place (startPosition_.x + startPosition_.w/2, startPosition_.y + 2);
	}
	
}
