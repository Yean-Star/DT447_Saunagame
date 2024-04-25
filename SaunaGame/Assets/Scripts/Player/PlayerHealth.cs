using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxHealth = 100;
    private bool isOnHeal;
    [SerializeField]
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if (!isOnHeal)
        {
            TakeDamage();
        }
        UpdateHP();
        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }
        //TakeDamage();
    }

    public float getHealth()
    {
        return health;
    }
    public void TakeDamage()
    {
        health -= Time.deltaTime;
    }


    public void UpdateHP()
    {
        Debug.Log(health);
    }

    public void RestoreHealth()
    {
        health += Time.deltaTime * 30;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Heal"))
        {
            Debug.Log("Player on the heal platform");
            isOnHeal = true;
            RestoreHealth();
            if(health < 100)
            {
                particle.Play();
            }
            else
            {
                particle.Stop();
            }
            
        }
        else
        {
            isOnHeal = false;
            particle.Stop();
        }
    }


}
