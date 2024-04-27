using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    public void Mouvement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rightSide = new Vector3(5, 5, 5);
        Vector3 leftSide = new Vector3(-5, 5, 5);
        //ici on va utiliser la methode velocity va mouvoir notre joueur à x et y distance par seconde
        //si on renseigne (1,1) konky kong bougera en diagonale à 1 unité par seconde
        _body.velocity = new Vector2(horizontalInput * _speed, _body.velocity.y);
        if(horizontalInput > 0f)
        {
            transform.localScale = rightSide;
        }
        else if(horizontalInput < 0f)
        {
            transform.localScale = leftSide;
        }
        //Input.GetAxis va recupérer les frappes de fleches directionnelles pour nous en 1 ligne au lieu de faire pleins d'if else

        if (Input.GetKey(KeyCode.Space))//return true quand space est press
        {
            _body.velocity = new Vector2(_body.velocity.x, _speed);
        }

        _animator.SetBool("run", horizontalInput != 0); //il faut que le nom du parametre soit le même que la parametre de l'animator voulu
    }
}
