using UnityEngine;
using UnityEngine.UI;
public class Enemymovement : MonoBehaviour
{
    Animator anim;
    public float speed = 3f;
    private Transform nextposition;
    private int pointsnum = 0;
    public int health = 100;
    public bool Dead = false;
    public Slider slider;
    public bool enemy1;
    public bool enemy2;
    public bool enemy3;
    public static bool lose;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (enemy1) {
            nextposition = Navigation.points[0];
        }
        if (enemy2) {
            nextposition = Navigation2.points[0];
        }
        if (enemy3)
        {
            nextposition = Navigation3.points[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.forward = Camera.main.transform.forward;
        slider.transform.rotation = Camera.main.transform.rotation;
        Vector3 dir = nextposition.position - transform.position;
        transform.LookAt(nextposition);
        if (!Dead) {
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        
        if (Vector3.Distance(transform.position, nextposition.position) < 0.2f)
        {
            if (enemy1) {
                if (pointsnum < Navigation.points.Length - 1)
                {
                    pointsnum++;
                    nextposition = Navigation.points[pointsnum];
                }
                else {
                    lose = true;
                }
                
            }
            
            if (enemy2) {
                if (pointsnum < Navigation2.points.Length - 1)
                {
                    pointsnum++;
                    nextposition = Navigation2.points[pointsnum];
                }
                else
                {
                    lose = true;
                }
            }
            if (enemy3)
            {
                if (pointsnum < Navigation3.points.Length - 1)
                {
                    pointsnum++;
                    nextposition = Navigation3.points[pointsnum];
                }
                else
                {
                    lose = true;
                }
            }
        }
       
    }
    public void Hurt(int damage) {
        if (Level3Generate.Level3) {
            Shop.instance.Currentmoney += damage/2;
        }
        health -= damage;
        slider.value = health;
        if (health <= 0) {   
            Die();
        }
    }
    void Die() {
        Dead = true;
       
        Destroy(gameObject);
        Shop.instance.Currentmoney += 50;
        if (enemy1)
        {
            Generate.Num -= 1;
            Level1Generate.Wave1Num -= 1;
            Level2Generate.Wave1Num -= 1;
            Level3Generate.Wave1Num -= 1;
            if (Level1Generate.wave3) {
                Level1Generate.Wave3Num3 -= 1;
            }
            if (Level2Generate.wave4) {
                Level2Generate.Wave4Num -= 1;
            }
            
        }
        if (enemy2)
        {

            Level1Generate.Wave2Num -= 1;
            Level2Generate.Wave2Num -= 1;
            Level3Generate.Wave2Num -= 1;
            if (Level1Generate.wave3) {
                Level1Generate.Wave3Num3 -= 1;
            }
            if (Level2Generate.wave4)
            {
                Level2Generate.Wave4Num -= 1;
            }

        }
        if (enemy3)
        {
            Level2Generate.Wave3Num -= 1;
            Level3Generate.Wave3Num -= 1;
            if (Level2Generate.wave4)
            {
                Level2Generate.Wave4Num -= 1;
            }
        }
        


    }
}
