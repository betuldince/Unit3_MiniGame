using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jump=100;
    public float gravityModifier;
    Animator anim;
    Rigidbody rb;
    public bool isGrounded=false;
    public bool isGameOver = false;
    public ParticleSystem explosion;
    public ParticleSystem dirt;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity =  new Vector3(0, -gravityModifier, 0); ;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded&&!isGameOver)
        {
            rb.AddForce(Vector3.up * jump,ForceMode.Impulse);
            isGrounded = false;
            anim.SetTrigger("Jump_trig");
            dirt.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
            
        }
        if (isGameOver)
        {
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            dirt.Play();
        }else if(collision.gameObject.tag=="Obstacles"){
            isGameOver = true;
            explosion.Play();
            dirt.Stop();
            audioSource.PlayOneShot(crashSound, 1.0f);
        }
                
    }
}
