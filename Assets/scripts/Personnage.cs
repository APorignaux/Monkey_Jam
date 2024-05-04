using System;
using UnityEngine;

public abstract class Personnage : MonoBehaviour
{
    [SerializeField] protected float _speed; //SerializeField sert à ajuster la valeur dynamiquement dans Unity 
    public float Speed
    {
        get => this._speed;
        set => this._speed = value;
    }

    protected bool _isOnGround;
    public bool IsOnGround
    {
        get => this._isOnGround;
        set => this._isOnGround = value;
    }


    protected Rigidbody2D _body; //variable qui contient le corps du joueur (objet à manipuler)
    public Rigidbody2D Body
    {
        get => this._body;
        set => this._body = value;
    }

    protected Animator _animator;

    public abstract void Mouvement(bool state);

}

