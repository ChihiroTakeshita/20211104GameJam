using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloor : MonoBehaviour
{
    [SerializeField] string _playerTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_playerTag))
        {
            var player = collision.gameObject.GetComponent<PlayerLifeManager>();
            player.Damage();
        }
    }
}
