using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikiBehavior : Tiki
{
    void Start()
    {
        //references 
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>(); //va aller dans l'instance joueur et chercher un RigidBody2D, il est ensuite stocké dans cette variable
        currentPoint = Point_B.transform; //le point que le tiki est en train d'atteindre
        _animator.SetBool("isRunning", true);//enclenche la marche du tiki
    }

    void Update()
    {
        Mouvement(true);
    }

    public override void Mouvement(bool state)
    {
        float point = currentPoint.position.x - transform.position.x;//transform.positon est la position en temps réel du joueur
        if (currentPoint.position.x == Point_B.transform.position.x)
        {
            _body.velocity = new Vector2(_speed, 0);
        }
        else _body.velocity = new Vector2(-_speed, 0);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == Point_B.transform)
        {
            currentPoint = Point_A.transform; //arrive à la fin de patrouille et change de direction
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == Point_A.transform)
        {
            currentPoint = Point_B.transform; //arrive à la fin de patrouille et change de direction
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiki")) //sert à ne pas rester bloquer sur les murs et autres tiki
        {
            if(currentPoint == Point_B.transform)
            {
                currentPoint = Point_A.transform;
            }

            else currentPoint = Point_B.transform;
        }
    }
}
