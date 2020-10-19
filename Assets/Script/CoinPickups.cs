using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = FindObjectOfType<Player>();
        if (other != player) { return; }
        
        if(other == player)
        {
            Destroy(gameObject);
            
        }
    }

}
