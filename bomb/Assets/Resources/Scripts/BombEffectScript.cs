using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffectScript : MonoBehaviour
{
   public void Effect()
    {
        GetComponent<ParticleSystem>().Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Player")
        {
            // ������������̐F�������_���ɕς���
           // other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
