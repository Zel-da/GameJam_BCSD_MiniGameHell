using Assets.PixelHeroes.Scripts.CharacterScripts;
using UnityEngine;
using AnimationState = Assets.PixelHeroes.Scripts.CharacterScripts.AnimationState;

namespace Assets.PixelHeroes.Scripts.ExampleScripts
{
    public class JumpJump4 : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.O))
            {
                _inputY = 1;

                if (Controller.isGrounded)
                {
                    JumpDust.Play(true);
                }
            }
        }

        public void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (Time.frameCount <= 1)
            {
                Controller.Move(new Vector3(0, Gravity) * Time.fixedDeltaTime);
                return;
            }

            var state = Character.GetState();

            if (state == AnimationState.Dead)
            {
                if (_inputX == 0) return;

                Character.SetState(AnimationState.Running);
            }

            if (_inputX != 0)
            {
                Turn(_inputX);
            }

            if (Controller.isGrounded)
            {
                if (state == AnimationState.Jumping)
                {

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
                }
            }
            else
            {
                _motion = new Vector3(RunSpeed * _inputX, _motion.y);
                Character.SetState(AnimationState.Jumping);
            }

            _motion.y += Gravity;

            Controller.Move(_motion * Time.fixedDeltaTime);

            Character.Animator.SetBool("Grounded", Controller.isGrounded);
            Character.Animator.SetBool("Moving", Controller.isGrounded && _inputX != 0);
            Character.Animator.SetBool("Falling", !Controller.isGrounded && Controller.velocity.y < 0);

            if (_inputX != 0 && _inputY != 0 || Character.Animator.GetBool("Action"))
            {
                _activityTime = Time.time;
            }

            _inputX = _inputY = 0;

            if (Controller.isGrounded && !Mathf.Approximately(Controller.velocity.x, 0))
            {
                var velocity = MoveDust.velocityOverLifetime;

                velocity.xMultiplier = 0.2f * -Mathf.Sign(Controller.velocity.x);

                if (!MoveDust.isPlaying)
                {
                    MoveDust.Play();
                }
            }
            else
            {
                MoveDust.Stop();
            }
        }

        private void Turn(int direction)
        {
            var scale = Character.transform.localScale;

            scale.x = Mathf.Sign(direction) * Mathf.Abs(scale.x);

            Character.transform.localScale = scale;
        }
    }
}