using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelCars : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        StartCoroutine(Getfaster());
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private IEnumerator Getfaster()
    {
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
        yield return new WaitForSeconds(60f);
        speed = speed * 1.1f;
    }
}
