using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Note : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 4;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start () {
        rb.velocity = new Vector2(0, -speed);
    }
}