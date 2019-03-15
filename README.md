[2Dシューティング](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game-jp)  

1. [スプライトとスプライトアニメーションの作成](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/creating-sprites-and-sprite-animations?playlist=46524)  
  - Sprite  
    キャラクターやアイテムなどの2Dグラフィックスオブジェクト  
    Space Ship は .png 形式  
  - Pixels Per Units  
    x pixels の大きさが 1*1 m^2 四方に入る？  
  - SpriteEditor  
    Grid By Cell Size を用いて分割  
  - Animation  
    分割した画像でgifを作成？

2. [プレイヤーの移動](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/moving-the-player?playlist=46524)  
  - [Rigidbody2Dクラス](https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody2D.html?_ga=2.80300946.420736588.1552306918-1395381044.1552306918)  
    2D物理演算のためのクラス  
  - [Inputクラス](https://docs.unity3d.com/ja/current/ScriptReference/Input.html?_ga=2.48464035.420736588.1552306918-1395381044.1552306918)  
    キーボード、JoyStickなどのコントローラの入力を処理するクラス  
  - Rigidbody2D を Player Prefab などにアタッチ
  > Apply Root Motion  
    3Dモデルに対するアニメーション制御  

  - [Vector2クラス](https://docs.unity3d.com/ja/current/ScriptReference/Vector2.html)  
  ```
    float x = Input.GetAxisRaw("Horizontal");
    // float x は左入力で-1、右入力で1、その他0。引数が"Vertial"の時上下  
    Vector2 direction = new Vector2(x, y).normalized;  
    // 移動の向き。.normalizedで移動距離を1に制限
  ```


3. [プレイヤーから弾を撃つ](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/shooting-shots-from-the-player?playlist=46524)  
  - 両翼から弾が出るように工夫  
  - [Coroutine](https://docs.unity3d.com/ja/current/Manual/Coroutines.html?_ga=2.111366017.420736588.1552306918-1395381044.1552306918)  
    コ実行を停止して Unity へ制御を戻し、その次のフレームで停止したところから続行することができる関数  
    `IEnumerator function(){}`で記述される  
    ```
      Player.cs
      0.05s毎に弾を発射
      IEnumerator Start(){
        while (true) {
          // 弾をプレイヤーと同じ位置/角度で作成
          Instantiate(bullet, transform.position, transform.rotation);
          // 0.05秒待つ
          yield return new WaitForSeconds (0.05f);
        }
      }
    ```  
    start 時に実行され、0.05s起きに処理をUnityに反映  
  - Layer  
    表示順をEdit->Projection Settings... からSorting Layorを変更  
    各オブジェクトのInspector->Sprite Renderer->Sorting Layerを変更

4. [敵を作成しよう](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/creating-enemies?playlist=46524)
  - [RequireComponent](https://docs.unity3d.com/ja/current/ScriptReference/RequireComponent.html?_ga=2.105988614.420736588.1552306918-1395381044.1552306918)  
    RequireComponent を使ったスクリプトをゲームオブジェクトにアタッチすると、自動的にそのゲームオブジェクトに必要なコンポーネントが加えられる  
    ```
    [RequireComponent(typeof(Rigidbody2D))] // この一文
    public class Spaceship : MonoBehaviour{
    }
    ```
  - スクリプトの使い回し  
    Player と Bullet に共通している変数などを class Spaceship に定義  
    そのクラスを Player.cs, Enemy.cs 内で読み込むことで変数、関数を使いまわせる（オブジェクト指向）  
  > [transform](https://docs.unity3d.com/ja/2018.3/ScriptReference/Transform.html)  
    Component.transformのこと、着目しているオブジェクトの向きや位置  
    子に方向の情報を持たせるとそちらに弾を打つことができる

5. [当たり判定とアニメーションイベントとレイヤー](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/colliders-animations-and-layers?playlist=46524)  
  - Collidor  
    当たり判定は Compornent から追加、形に応じて  
    Trigerにすると通過する、しないとぶつかって座標が交差しない
    > DestroyAreaとプレイヤーが衝突して、Player.csのOnTriggerEnter2Dが呼び出され即消える

  - Layer毎に当たり判定  
    - [Layer](https://docs.unity3d.com/ja/2018.3/Manual/Layers.html)
    ```
    当たったオブジェクトのレイヤーを取得
    string layerName = LayerMask.LayerToName(c.gameObject.layer);
    ```
  - Destroy

6. [背景を作る](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/creating-the-background?playlist=46524)  
  - 背景のスクロール


7. [Wave型の仕組み作り](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/spawning-waves?playlist=46524)

8. [BGMをつける](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/adding-audio?playlist=46524)  
  - Stage  
    BGMをD&D  
  - Shoot  
    ComponentにAudioSourceを追加、ドラッグ

9. [プレイヤーの移動制限と様々な修正](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/limiting-player-movement-and-other-corrections?playlist=46524)
  - View Port  
    [カメラ](https://docs.unity3d.com/ja/2018.3/ScriptReference/Camera.html)が写る範囲  
  - 移動の方法

10. [タイトルをつける]()

11. [エネミーのHP、弾の攻撃力、アニメーションの追加](https://unity3d.com/jp/learn/tutorials/projects/2d-shooting-game/adding-enemy-hp-shot-power-and-animations?playlist=46524)
  - 
***  
links  
[Documentation](https://docs.unity3d.com/ja/current/Manual/index.html)  
[Script Reference](https://docs.unity3d.com/ja/current/ScriptReference/index.html)  
