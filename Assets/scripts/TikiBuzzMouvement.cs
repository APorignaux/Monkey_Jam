using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikiBuzzMouvement : Tiki
{
    //public void Awake() //methdode qui est appellé à chaque fois que le script est chargé (point d'entré)
    //{

    //}

    // Start is called before the first frame update
    void Start()
    {
        //references 
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>(); //va aller dans l'instance joueur et chercher un RigidBody2D, il est ensuite stocké dans cette variable
        currentPoint = Point_B.transform; //le point que le tiki est en train d'atteindre
        _animator.SetBool("isFlying", true);//enclenche la marche du tiki
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement(true);
    }

    public override void Mouvement(bool state)
    {
        Vector2 point = currentPoint.position - transform.position;//transform.positon est la position en temps réel du joueur
        if (currentPoint == Point_B.transform)
        {
            _body.velocity = new Vector2(_speed, 0);
        }
        else _body.velocity = new Vector2(-_speed, 0);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == Point_B.transform)
        {
            currentPoint = Point_A.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == Point_A.transform)
        {
            currentPoint = Point_B.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (currentPoint == Point_B.transform)
            {
                currentPoint = Point_A.transform;
            }

            else currentPoint = Point_B.transform;
        }
    }
}
