using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;
	
	IEnumerator Start ()
	{
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
		
		// ローカル座標のY軸のマイナス方向に移動する
		spaceship.Move (transform.up * -1);

		// canShotがfalseの場合、ここでコルーチンを終了させる
		if (spaceship.canShot == false) {
			yield break;
		}

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

	// ぶつかった瞬間に呼び出される
	void OnTriggerEnter2D (Collider2D c)
	{
		// 弾の削除
		Destroy(c.gameObject);

		// プレイヤーを削除
		Destroy (gameObject);
	}
}