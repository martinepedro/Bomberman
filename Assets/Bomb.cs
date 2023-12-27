using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    private CircleCollider2D circleCollider;

    void Start()
    {
    }

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
        StartCoroutine(Explode());
        StartCoroutine(EnableCircleCollider());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnableCircleCollider()
    {
        yield return new WaitForSeconds(1);
        circleCollider.enabled = true;
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x - 1.0f, transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x - 2.0f, transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x + 1.0f, transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x + 2.0f, transform.position.y), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x, transform.position.y - 1.0f), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x, transform.position.y - 2.0f), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x, transform.position.y + 1.0f), Quaternion.identity);
        PhotonNetwork.Instantiate(explosionPrefab.name, new Vector2(transform.position.x, transform.position.y + 2.0f), Quaternion.identity);
        Destroy(gameObject);
    }
}
