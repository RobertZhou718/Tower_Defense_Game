using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform Target;
    public Transform RotatePart;
    public GameObject Bullet;
    public Transform Shootpoint;
    public ParticleSystem Shooteffect;
    public int value;
    public int level;
    public float shootrate = 1f;
    private float shootcountdown = 0f;
    public float range = 20;
    AudioSource attact;
    // Start is called before the first frame update
    void Start()
    {
        attact = gameObject.GetComponent<AudioSource>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) {
            return;
        }
        Vector3 dir = Target.position - transform.position;
        Vector3 rotation =  Quaternion.Lerp(RotatePart.rotation, Quaternion.LookRotation(dir),Time.deltaTime * 10f).eulerAngles;
        RotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (shootcountdown <= 0f) {
            shoot();
            shootcountdown = 1f / shootrate;
        }
        shootcountdown -= Time.deltaTime;
    }
    void UpdateTarget() {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortest = Mathf.Infinity;
        GameObject nearestenemy = null;
        foreach (GameObject enemy in Enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortest) {
                shortest = distance;
                nearestenemy = enemy;
            }
            if (nearestenemy != null && shortest < range)
            {
                Target = nearestenemy.transform;
            }
            else {
                Target = null;
            }
        }
    }
    void shoot() {
        attact.Play();
        Shooteffect.Play();
        GameObject bulletGO = (GameObject)Instantiate(Bullet, Shootpoint.position, Shootpoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null) {
            bullet.Findtarget(Target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
