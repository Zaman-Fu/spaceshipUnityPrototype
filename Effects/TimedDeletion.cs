using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Effects
{
    public class TimedDeletion : MonoBehaviour
    {

        [SerializeField]
        float timeout;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("TimeToDie");
        }

        // Update is called once per frame
        void Update()
        {

        }
        IEnumerator TimeToDie()
        {
            yield return new WaitForSeconds(timeout);
            Destroy(gameObject);
        }
    }
}

