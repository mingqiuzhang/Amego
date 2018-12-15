using UnityEngine;
using System.Collections;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class CharacterMovement_Physics : MonoBehaviour
    {

        public enum AimType
        {
            Movement,
            Mouse,
            Thumbstick,
            Vehicle,
        }

        public enum CharacterState
        {
            frozen,
            idle,
            moving
        }

        public int m_PlayerNumber = 1;
        public float m_TurnSpeed = 180f;

        [Header("Input Axes")]
        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";
        public string horizontalThumbstick = "Horizontal_Thumbstick";
        public string verticalThumbstick = "Vertical_Thumbstick";
        public string attackAxis = "Fire1";

        [Header("Movment Properties")]
        public float maxSpeed = 10f;
        public float acceleration = 10f;

        [Header("Aim Properties")]
        public AimType aimType = AimType.Movement;
        public float angularSpeed = 5f;
        public Camera MainCamera;

        [Header("Attack Properties")]
        public Weapon primaryAttack;
        public Transform attackPoint;

        //Private Memeber Variables
        private Rigidbody _rigidbody;
        public Vector3 _characterVelocity = Vector3.zero;
        private Vector3 _thumbstickVector = Vector3.zero;

        private bool _canMove = true;
        private bool _canAim = true;
        private bool _canAttack = true;

        private AnimationHandler animationHandler;
        private Vector3 _storedVelocity = Vector3.zero;
        private CharacterState state = CharacterState.idle;
        private Plane _groundPlane;

        private float m_MovementInputValue = 0f;        
        private float m_TurnInputValue = 0f;

        private bool _canFireArrow = false;

        private Weapon_Projectile _fire_control_system;

        private EquipedWeaponSwitch _weapon_switch_system;

        private void Awake()
        { 
            _rigidbody = this.GetComponent<Rigidbody>();
        }


        void Start()
        {
            _rigidbody = this.GetComponent<Rigidbody>();
            animationHandler = GetComponent<AnimationHandler>();
            _groundPlane = new Plane(Vector3.up, this.transform.position);

            if (attackPoint == null) attackPoint = this.transform;

            _fire_control_system = this.GetComponent<Weapon_Projectile>();

            _weapon_switch_system = this.GetComponent<EquipedWeaponSwitch>();
        }

        private void Update()
        {
            if (_canMove) Move();
            if (_canAim) Aim();
            if (_canAttack) Attack();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.magnitude < maxSpeed)
            {
                _rigidbody.AddForce(_characterVelocity, ForceMode.Acceleration);
            }
            Turn();
            animationHandler.SetAnimatorVelocity(_rigidbody.velocity.magnitude);
        }

        /// <summary>
        /// Handles the basic movement input, sets the character velocity local variable.
        /// </summary>
        private void Move()
        {

            // Initialize a local force vector variable
            Vector3 forceVector = Vector3.zero;

            // Add the input from the Input Manager to the X & Z axes of the forceVector
            forceVector.x = Input.GetAxis(horizontalAxis) * acceleration;
            forceVector.z = Input.GetAxis(verticalAxis) * acceleration;

            // If the aim type has been set to vehicle movement add the forward vector of character times the force to the character velocity, 
            // otherwise just add the force vector
            if (aimType == AimType.Vehicle)
            {
                _characterVelocity = (this.transform.forward * forceVector.z);
            }
            else
            {
                _characterVelocity = forceVector;
            }

        }

        /// <summary>
        /// Switch case to determine which type of aim to use to orient the character.
        /// </summary>
        private void Aim()
        {
            switch (aimType)
            {
                case AimType.Movement:
                    if (_characterVelocity.magnitude != 0f) this.transform.forward = _characterVelocity;
                    break;

                case AimType.Vehicle:
                    this.transform.Rotate(Vector3.up, Input.GetAxis(horizontalAxis) * angularSpeed);
                    break;

                case AimType.Mouse:
                    MouseAim();
                    break;

                case AimType.Thumbstick:
                    ThumbstickAim();
                    break;
            }
        }

        /// <summary>
        /// Uses a plane based raycast to orient the player toward the mouse position on screen.
        /// </summary>
        private void MouseAim()
        {
            Ray screenRay = MainCamera.ScreenPointToRay(Input.mousePosition);
            float intersection = 0.0f;

            // Set the raycast plane to the position of the player facing up
            _groundPlane.SetNormalAndPosition(Vector3.up, this.transform.position);

            // Perform a raycast to track the intersection distance of the ray
            if (_groundPlane.Raycast(screenRay, out intersection))
            {
                // Calculate the hit point on the plane and set the look at of the character transform
                Vector3 hitPoint = screenRay.GetPoint(intersection);
                this.transform.LookAt(hitPoint);
            }
        }

        /// <summary>
        /// Handles the aim from the thumbstick input & sets the forward transform vector of the character.
        /// </summary>
        private void ThumbstickAim()
        {
            // Set the thumbstick vector from input axes
            _thumbstickVector.x = Input.GetAxis(horizontalThumbstick);
            _thumbstickVector.z = Input.GetAxis(verticalThumbstick);

            // Set the aim only if the magnitude of the vector is significant, avoids thumbstick drift 
            if (_thumbstickVector.magnitude > 0.1f)
            {
                this.transform.forward = _thumbstickVector;
            }
        }

        private void Attack()
        {
            if (primaryAttack == null) return;

            if (Input.GetAxis(attackAxis) > 0.5f)
            {
                if (_weapon_switch_system.weapon == EquipedWeaponSwitch.CurrentWeapon.bow ||
                _weapon_switch_system.weapon == EquipedWeaponSwitch.CurrentWeapon.staff)
                {
                    if (_fire_control_system._canFire == false)
                    {
                        return;
                    }
                    else
                    {
                        animationHandler.PlayAttackAnimation(_weapon_switch_system.weapon);
                        
                    }
                }
                else
                {

                    animationHandler.PlayAttackAnimation(_weapon_switch_system.weapon);
                    print("attack");
                }          
            }
        }



        private void Turn ()
        {
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
           _rigidbody.MoveRotation (_rigidbody.rotation * turnRotation);
        }
        /// <summary>
        /// Freeze the character in place, store the current character velocity, or unfreeze the character and resume character velocity.
        /// </summary>
        /// <param name="value">If set to <c>true</c> value.</param>
        public void Freeze(bool value)
        {
            _canMove = !value;
            _canAim = !value;

            if (value)
            {
                _storedVelocity = _rigidbody.velocity;
                _rigidbody.velocity = Vector3.zero;
            }
            else
            {
                _rigidbody.velocity = _storedVelocity;

            }
        }

        //These Methods Are To Be Used By Other Scripts, They Will Change These Character Boolean Values.
        public void set_canMove(bool b)
        {
            _canMove = b;
        }
        public void set_canAim(bool b)
        {
            _canAim = b;
        }
        public void set_canAttack(bool b)
        {
            _canAttack = b;
        }

        public Rigidbody return_rigidbody()
        {
            return _rigidbody;
        }

    }

