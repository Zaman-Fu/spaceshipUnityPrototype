using ShipGame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Enemies.Movement
{
    public abstract class MovementPattern : MonoBehaviour
    {
        protected Enemy enemy;
        protected Rigidbody2D rb;

        [SerializeField]
        protected float speed;

        [Range(0, .3f)]
        [SerializeField]
        protected float m_MovementSmoothing = .05f;

        protected Vector3 m_velocity = Vector3.zero;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void Initialize()
        {
            enemy = gameObject.GetComponent<Enemy>();
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        public abstract void Move();

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        

    }
}

