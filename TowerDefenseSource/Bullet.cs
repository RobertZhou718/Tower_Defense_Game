using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform Target;
    public float shootspeed = 70f;
    public int damage = 20;
  
    void Update()
    {
        if (Target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float bulletflydistance = shootspeed * Time.deltaTime;

        if (dir.magnitude <= bulletflydistance) {

            Destroy(gameObject);
            MakeDamage(Target);
            return;
        }

        transform.Translate(dir.normalized * bulletflydistance, Space.World);
        transform.LookAt(Target);
    }
    public void Findtarget(Transform target)
    {
        Target = target;
    }
    void MakeDamage(Transform enemy) {
        Enemymovement e = enemy.GetComponent<Enemymovement>();
        e.Hurt(damage);
    }
}
