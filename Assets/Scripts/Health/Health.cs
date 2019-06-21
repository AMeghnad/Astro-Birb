using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Epsilon
{
    public class Health : MonoBehaviour
    {
        protected int health;
        // Start is called before the first frame update
        public virtual void Start()
        {
            health = 100;
        }

        // Update is called once per frame
        public virtual void Update()
        {

        }
    }
}
