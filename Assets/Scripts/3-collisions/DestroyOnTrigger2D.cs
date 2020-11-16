using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] string HealTag;     
    [SerializeField] int life;

    private void OnTriggerEnter2D(Collider2D other) {

        if (life > 0 && other.tag == triggeringTag)
        {
            life--;
            Destroy(other.gameObject);
        }
        else if (other.tag == triggeringTag && enabled && other.tag != "Player")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.tag == HealTag)
        {
            life++;
            Destroy(other.gameObject);
        }
        
    }
}
