using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    public bool isTraveling;
    public float speed;

    void Start()
    {
        StartCoroutine(StopTravel());
        isTraveling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTraveling)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    private IEnumerator StopTravel()
    {
        yield return new WaitForSeconds(10f);
        isTraveling = false;
    }
}
