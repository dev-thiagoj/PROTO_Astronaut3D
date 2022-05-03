using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//COISAS PARA FAZER:

//arrumar para que qdo o inimigo estiver morto n�o matar o player com colis�o ainda
//arrumar para qdo for morto, congelar a posi��o
//arrumar congelamento de eixos na persegui��o

namespace Enemy
{
    public class EnemyWalk : EnemyBase
    {
        [Header("Waypoints")]
        public GameObject[] waypoints;
        public float minDistance = 1f;
        public float speed = 1f;

        private int _index = 0;

        public override void Update()
        {
            base.Update();

            EnemyMove();

        }

        public void EnemyMove()
        {
            if (!_startPursuit)
            {
                if (Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
                {
                    _index++;

                    if (_index >= waypoints.Length)
                    {
                        _index = 0;
                    }
                }

                transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * speed);
                transform.LookAt(waypoints[_index].transform.position);
            }
            
        }

        protected override void Kill()
        {
            base.Kill();
            speed = 0;
        }
    }

}