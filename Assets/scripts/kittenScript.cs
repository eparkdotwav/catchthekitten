using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittenScript : MonoBehaviour
{
    public float speed = 5f;
    public Transform player;
    public AudioSource audioSource;
    public float maxDistance = 10.0f;

    private Rigidbody2D _rbody;
    private Vector2 _randomVelocity;

    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _rbody.GetComponent<BoxCollider2D>().enabled = true;
        ChangeVelocity();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float volume = 1.0f - (distance / maxDistance);
        volume = Mathf.Clamp01(volume); // Ensure the volume stays within [0, 1]
        audioSource.volume = volume;
    }

    void FixedUpdate()
    {
        _rbody.velocity = _randomVelocity * speed;
    }

    private void ChangeVelocity()
    {
        _randomVelocity = Random.insideUnitCircle.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Vector2 reflectedVelocity = Vector2.Reflect(_randomVelocity, collision.contacts[0].normal);
            _randomVelocity = reflectedVelocity.normalized;
        }
        
        if (collision.gameObject.CompareTag("sarang"))
        {
            _rbody.velocity = new Vector2(0,0);
            _rbody.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
