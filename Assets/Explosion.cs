using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Disappear());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        Destroy(collision.gameObject);
    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.45f);
        Destroy(gameObject);
    }
}
