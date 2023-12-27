using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float speedX, speedY;
    private float vertical;
    private float moveSpeed = 4f;

    [SerializeField] Rigidbody2D rb;

    public GameObject bombPrefab;

    PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PhotonNetwork.Instantiate(bombPrefab.name, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
            rb.velocity = new Vector2(speedX, speedY);
        }
    }
}
