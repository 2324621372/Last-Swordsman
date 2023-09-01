using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    Vector3 currentTransform;
    void Start()
    {
        currentTransform = GetComponent<Transform>().position;
        FindObjectOfType<PlayerHealtHandler>().gameObject.transform.position = currentTransform;
    }


}
