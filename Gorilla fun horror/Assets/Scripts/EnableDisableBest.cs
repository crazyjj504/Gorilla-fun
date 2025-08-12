using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableBest : MonoBehaviour
{
    [Header("MADE BY LISTY: PLEASE CREDIT")]
    [SerializeField]
    private List<GameObject> objectsEnable = new List<GameObject>();

    [SerializeField]
    private List<GameObject> objectsDisable = new List<GameObject>();

    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HandTag))
        {
            foreach (GameObject obj in objectsDisable)
            {
                obj.SetActive(false);
            }
            
            foreach (GameObject obj in objectsEnable)
            {
                obj.SetActive(true);
            }
        }
    }
}
