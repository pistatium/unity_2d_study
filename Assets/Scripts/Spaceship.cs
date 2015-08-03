using UnityEngine;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
	// 移動スピード
	public float speed;
	
	// 弾を撃つ間隔
	public float shotDelay;
	
	// 弾のPrefab
	public GameObject bullet;
	
	// 弾を撃つかどうか
	public bool canShot;

	// 弾の作成
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}
	
	// 機体の移動
	public void Move (Vector2 direction)
	{
		GetComponent<Rigidbody2D>().velocity = direction * speed;
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