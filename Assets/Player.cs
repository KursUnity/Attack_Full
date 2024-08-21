using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private Enemy _enemy;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("Attack");
            Invoke(nameof(Damage), 0.7f);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _anim.SetTrigger("Attack2");
            Invoke(nameof(Damage), 0.7f);
        }
    }

    private void Damage()
    {
        _enemy.TakeDamage();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy; 
        }
    }
}
