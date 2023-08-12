using ShipGame.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Player
{
    public class PlayerShip : MonoBehaviour,Damageable
    {
        int lives = 3;
        int energy = 10;
        int maxEnergy = 100;
        Rigidbody2D rb;

        [SerializeField]
        float m_speed;
        [SerializeField]
        Weapon equippedWeapon;
        [SerializeField]
        PlayerShield playerShield;

        [SerializeField]
        SpriteRenderer spriteRenderer;
        [SerializeField]
        Collider2D shipCollider;


        [Range(0, .3f)][SerializeField] 
        private float m_MovementSmoothing = .05f;

        Vector3 m_velocity= Vector3.zero;
        bool isInvincible=false;
        [SerializeField]
        GameObject deathExplosion;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            UIManager.UpdateLives(lives);
            UIManager.UpdatePower(energy);
        }

        // Update is called once per frame
        void Update()
        {

        }



        //Called by controller for movement
        public void Move(Vector2 direction)
        {

            Vector3 targetVelocity=direction*m_speed;
            rb.velocity =Vector3.SmoothDamp(rb.velocity,targetVelocity,ref m_velocity,m_MovementSmoothing);
        }
        public void Shoot(Vector2 direction)
        {
            //Have weapon instatiate projectile at given direction
            Debug.Log("Shootin' at direction: " + direction);
            equippedWeapon.Shoot(direction);
        }

        public void Parry(Vector2 direction)
        {
            //Have shield appear a certain distance away at a given direction
            playerShield.Activate(direction);
            
            
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Got Hit");
            if(!isInvincible)
            {
                //Make invincible and run invincibility coroutine.
                isInvincible = true;
                lives--;
                if(lives<0)
                    Die();
              
                UIManager.UpdateLives(lives);
                StartCoroutine("HitCooldown");
               
            }
            
        }

        public void AddEnergy(int energyToAdd)
        {
            
            energy+=energyToAdd;

            if(energy<0)
            {
                energy=0;
            }
            if( energy>100)
            {
                energy = 100;
            }
            
            UIManager.UpdatePower(energy);
        }
        public int GetEnergy()
        {
            return energy;
        }

        //TODO: add presets or coefficients for affecting energy gain.
        public void Grazed()
        {
            AddEnergy(1);
        }
        public void Die()
        {
            Instantiate(deathExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            UIManager.GameOver();
        }

        IEnumerator HitCooldown()
        {
            for(int i= 0; i < 5; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);// the blinking effect.
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            isInvincible = false;
        }
    }

}

