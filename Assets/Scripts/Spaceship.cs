using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {
  // 移動スピード
  public float speed;
  public float shotDelay;
  public GameObject bullet;
  public GameObject explosion;

  private Animator animator;

  void Start () {
    // アニメーターコンポーネントを取得
    animator = GetComponent<Animator> ();
  }
  public void Explosion () {
    Instantiate (explosion, transform.position, transform.rotation);
  }
  public void Shot (Transform origin) {
    Instantiate (bullet, origin.position, origin.rotation);
  }
  public Animator GetAnimator() {
    return animator;
  }
  // 機体の移動
  /*public void Move (Vector2 direction) {
    GetComponent<Rigidbody2D>().velocity = direction * speed;
  }*/
}
