using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private Canon currentCanon;

    void Update()
    {
        if (ScreenJustTouched() && currentCanon != null)
        {
            currentCanon.Fire();
        }
    }

    private bool touching = false;
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
        if (count > 0 && !touching)
        {
            touching = true;
            return true;
        }
        else if (count > 0)
        {
            touching = false;
        }
        
        return false;
    }

    public void SetCurrentCanon(Canon canon)
    {
        currentCanon = canon;
    }
}
