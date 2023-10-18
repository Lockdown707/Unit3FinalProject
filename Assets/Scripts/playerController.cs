using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public bool isDead;
    public float jumpForce;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

        // Update is called once per frame
        void Update()
    {
        transform.localScale = Vector3.one;

        if(Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }  
    }
    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        animator.SetTrigger("Die");
    }
}
