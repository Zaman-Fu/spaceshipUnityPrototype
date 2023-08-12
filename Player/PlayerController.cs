using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Player

{
    public class PlayerController : MonoBehaviour
    {
        PlayerShip ship;
        Vector2 direction;
        Vector2 directionR;
        [SerializeField]
        string moveAxisVertical;
        [SerializeField]
        string moveAxisHorizontal;
        [SerializeField]
        string aimAxisVertical;
        [SerializeField]
        string aimAxisHorizontal;
        void Start()
        {
            ship = GetComponent<PlayerShip>();
            
        }

        // Update is called once per frame
        void Update()
        {
            //Handle Left Joystick Input
            float x = Input.GetAxis(moveAxisHorizontal);
            float y = Input.GetAxis(moveAxisVertical);
           

            direction = new Vector2(x, y);
            //debug line, TODO:Delete later
            /*
            if (direction!=Vector2.zero)
            {
                Debug.Log(direction);
            }*/
            


            //Handle Right JoyStick Input
            float xr = Input.GetAxis(aimAxisHorizontal);
            float yr = Input.GetAxis(aimAxisVertical);

            directionR = new Vector2(xr, yr);
            
            //debug line, TODO:Delete later
            if (directionR != Vector2.zero)
            {
               // Debug.Log(directionR);
            }


            //Handle Shoot button input
            if (Input.GetAxis("Fire1")!=0)
            {
                ship.Shoot(directionR);
            }

            //Handle Special button input
            if (Input.GetAxis("Fire2") != 0)
            {
                ship.Parry(directionR);
            }
        }

        private void FixedUpdate()
        {
            ship.Move(direction.normalized);

        }



    }

}
