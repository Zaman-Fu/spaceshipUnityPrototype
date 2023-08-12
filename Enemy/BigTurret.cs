using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShipGame.Enemies
{
    public class BigTurret : Enemy
    {
        [SerializeField]
        DefencePlatformBoss attachedBoss;
        bool shootingBigOne=false;
        bool readyForBigOne=false;
        protected override void Initialize()
        {
            base.Initialize();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            StartCoroutine("BigOneCooldown");
        }
        protected override void Move()
        {
            if (shootingBigOne)
            {
                return;
            }
            movement.Move();
            weapons.ElementAt(0).Shoot();
        }

        protected void ShootBigOne()
        {
            shootingBigOne = true;
            StartCoroutine("LaserBeamShot");
        }

        protected void PrepareForBigOne()
        {
            StartCoroutine("BigOneCooldown");
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
            attachedBoss.ActivateHurtbox();
            base.Die();
        }

        IEnumerator LaserBeamShot()
        {
            weapons.ElementAt(1).Shoot();
            yield return new WaitForSeconds(6);
            readyForBigOne = false;
            shootingBigOne = false;
            PrepareForBigOne();
            
        }

        IEnumerator BigOneCooldown()
        {
            yield return new WaitForSeconds(10);
            readyForBigOne = true;
            ShootBigOne();
        }
    }
}
