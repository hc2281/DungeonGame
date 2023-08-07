using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
