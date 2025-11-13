using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerhealth : MonoBehaviour
{
    AudioSource audioSource;
    //what sound do we want to play
    public AudioClip DamageSound;
    //store the players health
    public float health = 10;
    float maxHealth;
    //we need a reference to our healthbar game object
    public Image healthBar;
    //if we collide with  something tagged as Enemy, take damage
    //if health gets too low, we die (reload the level)
    public bool IsDead = true;
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (audioSource != null && DamageSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(DamageSound);
            }
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health gets too low, we die (reload the level)
            if (health <= 0)
            {
                //reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (audioSource != null && DamageSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(DamageSound);
            }
            Destroy(collision.gameObject);
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health gets too low, we die (reload the level)
            if (health <= 0)
            {
                //reload the level
                // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }
    float deathTimer = 0;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("isDead", true);
            }
            //if we should die, we first want to play the death animation for a second
            deathTimer += Time.deltaTime;
            //note the length of your death animation may vary. default value here is 1 second.
            //NOTE: we moved the destroy code from below to here. if you don't remove it down below,
            //your death  animation will not play
            if (deathTimer > 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }




        }
    }
}