using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   
   

    [Header("Enemy Infomation")]
    [SerializeField] float health = 100;
    [SerializeField] int score = 100;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 8f;
    [SerializeField] GameObject LaserPrefab;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExp = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownandShoot();
    }

    private void CountDownandShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);


    }
    private void OnTriggerEnter2D(Collider2D collisionItem)
    {
        DamageDealer damageDealer = collisionItem.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            
            FindObjectOfType<GameSession>().AddToScore(score);
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExp);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
        }
    }
}
