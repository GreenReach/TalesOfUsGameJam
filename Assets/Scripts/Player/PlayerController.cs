using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // Scene Vars
        public GameObject CameraObject;

        // Obj Components
        public Rigidbody2D rb;
        public SpriteRenderer ren;

        // Modifiers
        public float DamageModifier;
        public float SpeedModifier;

        // Movement
        public float Speed;
        public Vector2 Orientation;
        public Direction Direction;
        public Sprite DirectionUp, DirectionDown, DirectionLeft, DirectionRight;

        // health
        public int Health;
        public int MaxHealth;

        // XP
        public int Experience;
        public int NextLevelExperience;



        private void Update()
        {
            // Camera
            Vector3 cameraPos = new Vector3(transform.position.x, transform.position.y, -10);
            CameraObject.transform.position = cameraPos;

            // Direction + Orientation
            Orientation = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                Orientation += Vector2.up;
                Direction = Direction.Up;
                ren.sprite = DirectionUp;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Orientation += Vector2.down;
                Direction = Direction.Down;
                ren.sprite = DirectionDown;
            }

            if (Input.GetKey(KeyCode.A))
            {
                Orientation += Vector2.left;
                Direction = Direction.Left;
                ren.sprite = DirectionLeft;
            }

            if (Input.GetKey(KeyCode.D))
            {
                Orientation += Vector2.right;
                Direction = Direction.Right;
                ren.sprite = DirectionRight;
            }


        }

        private void FixedUpdate()
        {
            rb.velocity = Orientation * Speed;
        }

        public void TakeDamage(int amount)
        {
            Debug.Log($"Took damage: {amount}");
        }

        public void Heal(int amount)
        {
            Debug.Log($"Heal: {amount}");
        }

        public void IncreaseHealth(int amount)
        {
            Debug.Log($"Increase health by: {amount}");
        }
    }
}