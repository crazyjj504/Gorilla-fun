using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    [Tooltip("Objects to toggle on and off in play mode")]
    public GameObject[] targetObjects;

    [Tooltip("Key to press to toggle the objects")]
    public KeyCode toggleKey = KeyCode.T;

    private bool objectsEnabled = true;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            objectsEnabled = !objectsEnabled;
            SetObjectsActive(objectsEnabled);
        }
    }

    private void SetObjectsActive(bool isActive)
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(isActive);
        }
    }
}