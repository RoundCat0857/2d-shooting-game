﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  public int speed = 10;
  public float lifeTime = 5;
  public int power = 1;
  // Start is called before the first frame update
  void Start() {
    GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    Destroy (gameObject, lifeTime);
  }

  // Update is called once per frame
}
