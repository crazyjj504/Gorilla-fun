using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    [Header("MADE BY VOLXTEN - PLS GIVE CREDIT :3")]

    public List<GameObject> objectsToEnable;
    public List<GameObject> objectsToDisable;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            foreach (GameObject obj in objectsToEnable)
            {
                if (obj != null)
                    obj.SetActive(true);
            }

            foreach (GameObject obj in objectsToDisable)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }
}
