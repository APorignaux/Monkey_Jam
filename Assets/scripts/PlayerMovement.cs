using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Monkey_Jam_Game
{
    public class PlayerMovement : Personnage
    {
        [SerializeField] private float _pushingForce; //SerializeField sert à ajuster la valeur dynamiquement dans Unity 
        public float PushingForce
        {
            get => this._pushingForce;
            set => this._pushingForce = value;
        }

        public PlayerManager playerManager;
        [SerializeField]private float jumpingPower = 2f;


        //methdode qui est appellé à chaque fois que le script est chargé (point d'entré)
        public void Awake() 
        {
            //references
            _animator = GetComponent<Animator>();
            _body = GetComponent<Rigidbody2D>(); //va aller dans l'instance joueur et chercher un RigidBody2D, il est ensuite stocké dans cette variable
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetKey(KeyCode.R))
            {
                _body.transform.position = new Vector3(0, -2, 0);
            }

            if (Input.GetKey(KeyCode.G))
            {
                _body.transform.position = new Vector3(50, 5, 0);
            }

        }

        //gestion des collisions
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Token"))
            {
                Destroy(collider.gameObject);
                CoinCollector(collider);
            }
        }

        //collision controller
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PayerIsOnGround(collision);
            if (collision.gameObject.CompareTag("Tiki"))
            {
                UnityEngine.Debug.Log("enter");
                _animator.SetBool("isDamaged", true);
                
                playerManager.TakeDamage(1);
                UnityEngine.Debug.Log("damage");
                if (Body.velocity.x < 0)
                    _body.velocity = new Vector2(-10, Body.velocity.y);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Tiki"))
            {
                UnityEngine.Debug.Log("stay");
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Tiki"))
            {
                UnityEngine.Debug.Log("exit");
                _animator.SetBool("isDamaged", false);
            }
        }

        //gestion des collisions

        public override void Mouvement(bool state)
        {
            if (state)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                Vector3 rightSide = new Vector3(5, 5, 5);
                Vector3 leftSide = new Vector3(-5, 5, 5);
                //ici on va utiliser la methode velocity va mouvoir notre joueur à x et y distance par seconde
                //si on renseigne (1,1) konky kong bougera en diagonale à 1 unité par seconde
                _body.velocity = new Vector2(horizontalInput * _speed, _body.velocity.y);
                if (horizontalInput > 0f)
                {
                    transform.localScale = rightSide;
                }
                else if (horizontalInput < 0f)
                {
                    transform.localScale = leftSide;
                }
                //Input.GetAxis va recupérer les frappes de fleches directionnelles pour nous en 1 ligne au lieu de faire pleins d'if else

                Jump();

                _animator.SetBool("run", horizontalInput != 0); //il faut que le nom du parametre soit le même que la parametre de l'animator voulu
            }
            else UnityEngine.Debug.Log("can't move");

        }

        public void Jump()
        {
            if (Input.GetKey(KeyCode.Space) && IsOnGround)//return true quand space est press
            {
                _body.velocity = new Vector2(_body.velocity.x, jumpingPower);
                IsOnGround = false;
            }

            if (Input.GetButtonUp("Jump") && _body.velocity.y > 0f)
            {
                _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y * 0.5f);
            }
        }

        public void PayerIsOnGround(Collision2D collision)//verifie si DK est sur le sol
        {
            if (collision.gameObject.tag == "Ground")
            {
                IsOnGround = true;
            }
        }

        public void CoinCollector(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Token"))
            {
                playerManager.coinCount++;
            }
        }

        
    }
}


