using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	static public GameManager instance;
	static private float lastDeltaTime_;

	private bool touching_ = false;

	private Bird bird_;
	private OurCamera cam_;

	public GameObject canonBaseWeak;
	public GameObject canonBaseMedium;
	public GameObject canonBaseStrong;
	
	public LevelStart lvlStart;

	private bool wasTouching_;

//***************************************
// Unity functions

	void Start()
	{
		Debug.Log("Init GM");
		//Rigidbody rb = GetComponent<Rigidbody>();
		instance = this;
		wasTouching_ = false;

		bird_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>();
		cam_ = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OurCamera>();

		cam_.SetTarget(bird_);

		// Need to find a way to know what space we have to display level
		/*
		Camera camLogic = cam_.GetComponents<Camera> ();
		camLogic.ViewportToWorldPoint ();
		*/

		StartNewGame ();
	}

    void Update()
    {
		lastDeltaTime_ = Time.deltaTime;
		if (!ScreenJustTouched() && wasTouching_ && bird_ != null)
        {
			bird_.Shoot();
        }
    }

//***************************************
// Unity functions

	void StartNewGame()
	{
		cam_.Reset();

		// Compute Level size
		Vector4 levelSize = new Vector4 ();
		//levelSize.x = cam_.GetComponents<Camera>().S
		levelSize.x = -6; // Start x
		levelSize.y = -4; // Start y
		levelSize.w = 12; // Width
		levelSize.z = 50; // Height

		lvlStart.Init (null, levelSize);
	}


//***************************************
// 

	static public float getDeltaTime()
	{
		return lastDeltaTime_; 
	}
	
    private bool ScreenJustTouched()
    {
        int count = 0;
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
		if (Input.GetMouseButtonDown(0))
        {
            count = 1;
        }
#else
			count = Input.touchCount;
#endif
		wasTouching_ = touching_;
		if (count > 0 && !touching_)
        {
			touching_ = true;
            return true;
        }
        else
        {
			touching_ = false;
        }
        
        return false;
    }

}
