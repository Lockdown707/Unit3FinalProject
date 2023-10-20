using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public bool isDead;
    public float jumpForce;
    public ParticleSystem explosionParticle;
    public ParticleSystem jetParticle;
    public AudioClip deadSound;
    public AudioClip flapSound;
    private AudioSource playerAudio;
    public AudioSource backgroundAudio;
    public Rigidbody prefabRb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();   
    }

        // Update is called once per frame
        void Update()
    {
        transform.localScale = Vector3.one;

        if(Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(flapSound);
        }  
    }
    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        animator.SetTrigger("Die");
        explosionParticle.Play();
        playerAudio.PlayOneShot(deadSound);
        backgroundAudio.Stop();
        jetParticle.Stop();
        prefabRb = collision.gameObject.GetComponent<Rigidbody>();
        prefabRb.isKinematic = true;

    }
}
