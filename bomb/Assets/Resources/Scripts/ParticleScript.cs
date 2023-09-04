using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    private ParticleSystem particle;

    public void Particle()
    {
		// パーティクルシステムのインスタンスを生成する。
		ParticleSystem newParticle = Instantiate(particle);
		// パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
		newParticle.transform.position = this.transform.position;
		// パーティクルを発生させる。
		newParticle.Play();
		// インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
		// ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
		Destroy(newParticle.gameObject, 5.0f);
	}
}
