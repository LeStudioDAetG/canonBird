using UnityEngine;
using System.Collections.Generic;

public class LevelBase : MonoBehaviour
{
	private List<Canon> canons_;
	private Canon lastCanon;

	Transform startPosition_;
	
//***************************************
// Unity functions

	void Start()
	{
		canons_ = new List<Canon> ();
	}
	
	void Update()
	{
		
	}


//***************************************
// Our Fonctions
	
	void Init(Canon lastCanon, Transform startPosition)
	{
		
	}

	protected void AddCanon(Canon canon)
	{
		canons_.Add(canon);
	}

}