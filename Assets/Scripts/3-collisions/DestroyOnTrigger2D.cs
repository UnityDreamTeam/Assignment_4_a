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
        if (other.tag == HealTag)
        {
            switch (life)
            {
                case 2: {
                        GameObject.FindGameObjectWithTag("Heart3").GetComponent<Renderer>().enabled = true;
                        GameObject.FindGameObjectWithTag("Heart2").GetComponent<Renderer>().enabled = true;
                        GameObject.FindGameObjectWithTag("Heart1").GetComponent<Renderer>().enabled = true;
                    }
                    break;
                case 1:
                    {
                        GameObject.FindGameObjectWithTag("Heart3").GetComponent<Renderer>().enabled = true;
                        GameObject.FindGameObjectWithTag("Heart2").GetComponent<Renderer>().enabled = true;
                    }break;
				case 0:
                    {
                        GameObject.FindGameObjectWithTag("Heart3").GetComponent<Renderer>().enabled = true;
                    }break;
            }
            if (life < 3)
              life++;
            Destroy(other.gameObject);
        }
        else if (life > 0 && other.tag == triggeringTag)
        {
            switch (life) {
                case 3: {
                        GameObject.FindGameObjectWithTag("Heart1").GetComponent<Renderer>().enabled = false;
                    } break;
                case 2:
                    {
                        GameObject.FindGameObjectWithTag("Heart1").GetComponent<Renderer>().enabled = false;
                        GameObject.FindGameObjectWithTag("Heart2").GetComponent<Renderer>().enabled = false;
                    }
                    break;
                case 1:
                    {
                        GameObject.FindGameObjectWithTag("Heart1").GetComponent<Renderer>().enabled = false;
                        GameObject.FindGameObjectWithTag("Heart2").GetComponent<Renderer>().enabled = false;
                        GameObject.FindGameObjectWithTag("Heart3").GetComponent<Renderer>().enabled = false;
                    }
                    break;

            }
            
            life--;
            Destroy(other.gameObject);
        }

        else if (other.tag == triggeringTag && enabled)
        {
            
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        
    }
}
