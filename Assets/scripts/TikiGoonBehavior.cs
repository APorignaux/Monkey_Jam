using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikiBehavior : MonoBehaviour
{
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

    public void Awake() //methdode qui est appellé à chaque fois que le script est chargé (point d'entré)
    {
        //references 
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>(); //va aller dans l'instance joueur et chercher un RigidBody2D, il est ensuite stocké dans cette variable
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        //ici on va utiliser la methode velocity va mouvoir notre joueur à x et y distance par seconde
        //si on renseigne (1,1) konky kong bougera en diagonale à 1 unité par seconde
        _body.velocity = new Vector2(_body.velocity.x * Speed/2 * _speed, _body.velocity.y);
    }
}
