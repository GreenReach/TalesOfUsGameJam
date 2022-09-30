using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // Scene Vars
        public GameObject CameraObject;
        public RobertGameManager GameManager;

        // Obj Components
        public Rigidbody2D rb;
        public SpriteRenderer ren;

        // Passive Modifiers
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
        public int NextLevelExperience = 10;
        public int Level;

        private void Start()
        {
            Experience = 0;
            NextLevelExperience = 10;
            Level = 1;

            Health = 50;
            MaxHealth = 100;

            GameManager.UpdateLevel(1);
            GameManager.UpdateExperienceBar(0);
            GameManager.UpdateHealthBar((float)Health / (float)MaxHealth);
        }


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
            Health -= amount;
        }

        public void IncreaseHealth(int amount)
        {
            Debug.Log($"Increase health by: {amount}");
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag == "XP/Normal")
            {

                Experience++;

                if(Experience >= NextLevelExperience)
                {
                    // TODO Lvl Up call to UI to chose reward

                    Experience -= NextLevelExperience;
                    NextLevelExperience =(int)((float)NextLevelExperience *  1.25); // increase next level threshold

                    Level++;
                    GameManager.UpdateLevel(Level);
                }

                GameManager.UpdateExperienceBar((float)Experience / (float)NextLevelExperience);
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.tag == "HealthDrop")
            {
                if (Health < MaxHealth)
                {
                    Health += (int)((float)MaxHealth/4);
                    if (Health > MaxHealth) Health = MaxHealth;

                    GameManager.UpdateHealthBar((float)Health / (float)MaxHealth);
                    Destroy(collision.gameObject);

                }
            }
        }
    }
}