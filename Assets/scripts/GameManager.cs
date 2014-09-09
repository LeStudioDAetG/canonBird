using UnityEngine;

public class GameManager : MonoBehaviour 
{
	private bool touching_ = false;

	private Bird bird_;
	private OurCamera cam_;

	static private float lastDeltaTime_;

	static public Canon canonBaseWeak;
	static public Canon canonBaseMedium;
	static public Canon canonBaseStrong;

//***************************************
// Unity functions

	void Start()
	{
		Debug.Log("Init GM");
		//Rigidbody rb = GetComponent<Rigidbody>();

		bird_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>();
		cam_ = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OurCamera>();

		cam_.SetTarget(bird_);
	}

    void Update()
    {
		lastDeltaTime_ = Time.deltaTime;
		if (ScreenJustTouched() && bird_ != null)
        {
			bird_.Shoot();
        }
    }

//***************************************
// Unity functions

	void StartNewGame()
	{
		cam_.Reset();
	}


//***************************************
// Unity functions

	static public float getDeltaTime()
	{
		return lastDeltaTime_; 
	}
	
    private bool ScreenJustTouched()
    {
        int count = 0;
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
        if (Input.GetMouseButton(0))
        {
            count = 1;
        }
#else
			count = Input.touchCount;
#endif
		if (count > 0 && !touching_)
        {
			touching_ = true;
            return true;
        }
        else if (count > 0)
        {
			touching_ = false;
        }
        
        return false;
    }

}
