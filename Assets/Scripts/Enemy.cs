using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  // Start is called before the first frame update
  public int hp = 1;
  Spaceship spaceship;
  IEnumerator Start() {
    spaceship = GetComponent<Spaceship> ();
    /*spaceship.*/Move (transform.up * -1);
    while (true) {
      // 子要素を全て取得する
      for (int i = 0; i < transform.childCount; i++) {
        Transform shotPosition = transform.GetChild(i);
        // ShotPositionの位置/角度で弾を撃つ
        spaceship.Shot (shotPosition);
      }
      // shotDelay秒待つ
      yield return new WaitForSeconds (spaceship.shotDelay);
    }
  }

  public void Move (Vector2 direction) {
    GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
  }

  // Update is called once per frame
  void OnTriggerEnter2D (Collider2D c) {
    // レイヤー名を取得
    string layerName = LayerMask.LayerToName(c.gameObject.layer);
    // レイヤー名がBullet (Player)以外の時は何も行わない
    if(layerName != "Bullet (Player)") return;
    Transform playerBulletTransform = c.transform.parent;
    Bullet bullet = playerBulletTransform.GetComponent<Bullet>();
    hp = hp - bullet.power;
    // 弾の削除
    Destroy(c.gameObject);
    if (hp <= 0) {
      // 爆発
      spaceship.Explosion();
      // エネミーの削除
      Destroy(gameObject);
    } else {
      spaceship.GetAnimator().SetTrigger("Damage");
    }
  }
}
