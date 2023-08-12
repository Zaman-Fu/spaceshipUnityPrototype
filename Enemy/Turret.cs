using ShipGame.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace ShipGame.Enemies
{
    public class Turret : Enemy
    {
        [SerializeField]
        MissileLauncherWeapon underWeapon;
        protected override void Initialize()
        {
            base.Initialize();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        protected override void Move()
        {
            movement.Move();
            weapons.ElementAt(0).Shoot();
        }

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        protected override void Die()
        {
            underWeapon.EnableFire();
            base.Die();
        }
    }
}

