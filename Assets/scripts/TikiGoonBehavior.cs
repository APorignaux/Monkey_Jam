using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikiBehavior : MonoBehaviour
{
    public GameObject Point_A;
    public GameObject Point_B;

    private Transform currentPoint;

    [SerializeField] private float _speed; //SerializeField sert à ajuster la valeur dynamiquement dans Unity 
    public float Speed
    {
        get => this._speed;
        set => this._speed = value;
    }


    private Rigidbody2D _body; //variable qui contient le corps du joueur (objet à manipuler)
    public Rigidbody2D Body
    {
        get => this._body;
        set => this._body = value;
    }

    private Animator _animator;

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
        _animator.SetBool("isRunning", true);//enclenche la marche du tiki
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;//transform.positon est la position en temps réel du joueur
        if (currentPoint == Point_B.transform)
        {
            _body.velocity = new Vector2(_speed,0);
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
}
