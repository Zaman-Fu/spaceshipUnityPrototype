using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ShipGame.Weapons
{
    public class BigLaserBeamWeapon : Weapon
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Shoot()
        {
            Debug.Log("Shooting straight");
            if (!readyToFire)
            {
                return;
            }
            Instantiate(projectile, transform.position, transform.rotation).transform.parent=gameObject.transform;
            readyToFire = false;
            StartCoroutine("WeaponCooldown");
        }
    }
}

