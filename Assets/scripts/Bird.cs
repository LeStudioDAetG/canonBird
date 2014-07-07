using UnityEngine;

public class Bird : MonoBehaviour
{
    [HideInInspector]
    public Canon lastCanon;

    public void SetLastCanon(Canon canon)
    {
        lastCanon = canon;
    }
}