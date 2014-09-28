using UnityEngine;
using System.Collections.Generic;

public class LevelBase : MonoBehaviour
{
	private List<Canon> canons_ = new List<Canon> ();
	private Canon lastCanon;

	protected Vector4 startPosition_;
	
//***************************************
// Unity functions

	void Start()
	{
		// canons_ = new List<Canon> ();
	}
	
	void Update()
	{
		
	}


//***************************************
// Our Fonctions
	
	public virtual void Init(Canon lastCanon, Vector4 coordonates)
	{
		startPosition_ = coordonates;
	}

	public void AddCanon(Canon canon)
	{
		canons_.Add(canon);
	}

}