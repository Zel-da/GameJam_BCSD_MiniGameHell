using Assets.PixelHeroes.Scripts.CharacterScripts;
using UnityEngine;
using AnimationState = Assets.PixelHeroes.Scripts.CharacterScripts.AnimationState;

namespace Assets.PixelHeroes.Scripts.ExampleScripts
{
    public class CharacterControls : MonoBehaviour
    {
        public Character Character;
        public CharacterController Controller; // https://docs.unity3d.com/ScriptReference/CharacterController.html
        public float RunSpeed = 1f;
        public float JumpSpeed = 3f;
        public float CrawlSpeed = 0.25f;
        public float Gravity = -0.2f;
        public ParticleSystem MoveDust;
        public ParticleSystem JumpDust;

        private Vector3 _motion = Vector3.zero;
        private int _inputX, _inputY;
        private float _activityTime;

        public void Start()
        {
            Character.SetState(AnimationState.Idle);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) Character.Animator.SetTrigger("Attack");
            else if (Input.GetKeyDown(KeyCode.J)) Character.Animator.SetTrigger("Jab");
            else if (Input.GetKeyDown(KeyCode.P)) Character.Animator.SetTrigger("Push");
            else if (Input.GetKeyDown(KeyCode.H)) Character.Animator.SetTrigger("Hit");
            else if (Input.GetKeyDown(KeyCode.I)) { Character.SetState(AnimationState.Idle); _activityTime = 0; }
            else if (Input.GetKeyDown(KeyCode.R)) { Character.SetState(AnimationState.Ready); _activityTime = Time.time; }
            else if (Input.GetKeyDown(KeyCode.B)) Character.SetState(AnimationState.Blocking);
            else if (Input.GetKeyUp(KeyCode.B)) Character.SetState(AnimationState.Ready);
            else if (Input.GetKeyDown(KeyCode.D)) Character.SetState(AnimationState.Dead);

            // Builder characters only.
            else if (Input.GetKeyDown(KeyCode.S)) Character.Animator.SetTrigger("Slash");
            else if (Input.GetKeyDown(KeyCode.O)) Character.Animator.SetTrigger("Shot");
            else if (Input.GetKeyDown(KeyCode.F)) Character.Animator.SetTrigger("Fire1H");
            else if (Input.GetKeyDown(KeyCode.E)) Character.Animator.SetTrigger("Fire2H");
            else if (Input.GetKeyDown(KeyCode.C)) Character.SetState(AnimationState.Climbing);
            else if (Input.GetKeyUp(KeyCode.C)) Character.SetState(AnimationState.Ready);
            else if (Input.GetKeyUp(KeyCode.L)) Character.Blink();


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _inputX = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _inputX = 1;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _inputY = 1;

            }
        }

        public void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var state = Character.GetState();

            if (state == AnimationState.Dead)
            {
                if (_inputX == 0) return;

                Character.SetState(AnimationState.Running);
            }



            _motion = state == AnimationState.Crawling
                ? new Vector3(CrawlSpeed * _inputX, 0)
                : new Vector3(RunSpeed * _inputX, JumpSpeed * _inputY);

            if (_inputX != 0 || _inputY != 0)
            {
                if (_inputY > 0)
                {
                    Character.SetState(AnimationState.Jumping);
                }
                else
                {
                    switch (state)
                    {
                        case AnimationState.Idle:
                        case AnimationState.Ready:
                            Character.SetState(AnimationState.Running);
                            break;
                    }
                }
            }
            else
            {
                switch (state)
                {
                    case AnimationState.Crawling:
                    case AnimationState.Climbing:
                    case AnimationState.Blocking:
                        break;
                    default:
                        var targetState = Time.time - _activityTime > 5 ? AnimationState.Idle : AnimationState.Ready;

                        if (state != targetState)
                        {
                            Character.SetState(targetState);
                        }

                        break;
                }

                    _motion = new Vector3(RunSpeed * _inputX, _motion.y);
                    Character.SetState(AnimationState.Jumping);
                }

                _motion.y += Gravity;

                if (_inputX != 0 && _inputY != 0 || Character.Animator.GetBool("Action"))
                {
                    _activityTime = Time.time;
                }

                _inputX = _inputY = 0;

            }

        }
    }