using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool _isDead = false;
    private void Update()
    {
        if (transform.position.y < -1f && !_isDead)
            Die();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        Invoke(nameof(ReloadLevel), 1.5f); 
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _isDead = false;
    }
}
