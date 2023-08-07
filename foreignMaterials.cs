using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foreignMaterials : MonoBehaviour
{
    public AudioSource smash;
    void Start()
    {
        transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 20f));
    }

    void Update()
    {
        transform.Translate(0f, -bottle.fallingSpeed * Time.deltaTime, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 20f));
        }
        if (collision.gameObject.tag == "case")
        {  
            caseMovement.increase = "-1";
            caseMovement.score--;
            smash.Play();
            transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 20f));
        }
    }
}
