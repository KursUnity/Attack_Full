using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject HP;
    public float HPValue;
    public float Speed;
    public Animator Anim;
    private bool _isStopped;

    private void Start()
    {
        Anim.SetBool("isWalking", true);
        HP.transform.localScale = new Vector3(HPValue, 0.1f, 0.05f);
    }

    void Update()
    {
        if (!_isStopped)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed * Time.deltaTime);
        }

    }

    public void TakeDamage()
    {
        HPValue -= 0.3f;
        HP.transform.localScale = new Vector3(HPValue, 0.1f, 0.05f);

        if (HPValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _isStopped = true;
            Anim.SetBool("isWalking", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _isStopped = true;
            Anim.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter(Collision collision)
    {
        Debug.Log("AS");

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _isStopped = false;
            Anim.SetBool("isWalking", true);
        }   
    }
}
