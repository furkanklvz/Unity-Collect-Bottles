using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    public AudioSource crashSound;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 20f));
    }

    // Update is called once per frame
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
        else if (collision.gameObject.tag == "case")
        {
            caseMovement.increase = "-3";
            caseMovement.score -= 3;
            crashSound.Play();
            transform.position = new Vector2(Random.Range(-7.59f, 7.59f), Random.Range(5.90f, 20f));
        }
    }
}
