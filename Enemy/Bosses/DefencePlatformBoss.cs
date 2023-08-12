using ShipGame.Management;
using ShipGame.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Enemies
{
    public class DefencePlatformBoss : Enemy
    {
        int phase = 1;
        protected override void Move()
        {
            movement.Move();
            foreach (Weapon wep in weapons)
            {
                wep.Shoot();
            }
        }
        
        public void ActivateHurtbox()
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        protected override void Die()
        {
            Debug.Log("Boss has died");
            UIManager.GameOver();
            base.Die();

        }

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
            active=true;//TODO: remove later and add other form of activation
        }

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.Rotate(0, 0, 2 * Time.deltaTime);
            Move();
        }
    }
}

