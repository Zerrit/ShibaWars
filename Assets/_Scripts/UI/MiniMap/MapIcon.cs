using UnityEngine;

public class MapIcon : MonoBehaviour
{
    public float positionIndex;
    public bool isUsedIcon;

    public void InstalPositionIndex(float index)
    {
        positionIndex = index;
        isUsedIcon = true;
    }

    public void DisableUnnecessity()
    {
        gameObject.SetActive(false);
    }
}
