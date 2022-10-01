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
        public GameStructures.Direction Direction;
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

            SpeedModifier = 1;
            DamageModifier = 1;
            UpdateUI();
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
                Direction = GameStructures.Direction.Up;
                ren.sprite = DirectionUp;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Orientation += Vector2.down;
                Direction = GameStructures.Direction.Down;
                ren.sprite = DirectionDown;
            }

            if (Input.GetKey(KeyCode.A))
            {
                Orientation += Vector2.left;
                Direction = GameStructures.Direction.Left;
                ren.sprite = DirectionLeft;
            }

            if (Input.GetKey(KeyCode.D))
            {
                Orientation += Vector2.right;
                Direction = GameStructures.Direction.Right;
                ren.sprite = DirectionRight;
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = Orientation * Speed * SpeedModifier;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            UpdateUI();
        }

        public void IncreaseHealth(int amount)
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            GameManager.UpdateHealthBar(Health, MaxHealth);
            GameManager.UpdateExperienceBar(Experience, NextLevelExperience);
            GameManager.UpdateLevel(Level);
        }

        public void ApplyReward(int rewardId)
        {
            if(rewardId == -1)
            {
                Health = MaxHealth;
                UpdateUI();
            }

            if(rewardId == (int)GameStructures.LevelUpListItems.Horse)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.Horse]++;
                SpeedModifier = GameStructures.speedModifiersValues[GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.Horse]];
            }

            if(rewardId == (int)GameStructures.LevelUpListItems.Ambrosia)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.Ambrosia]++;
                int newMaxHealth = GameStructures.healthUpgradeValues[GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.Ambrosia]];
                Health += newMaxHealth - MaxHealth;
                MaxHealth = newMaxHealth;

            }

            if (rewardId == (int)GameStructures.LevelUpListItems.GiantsHeritage)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.GiantsHeritage]++;
                DamageModifier = GameStructures.damageModifierValues[GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.GiantsHeritage]];
            }

            UpdateUI();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag == "XP/Normal")
            {

                Experience++;

                if(Experience >= NextLevelExperience)
                {

                    GameManager.StartLevelUp();
                    Experience -= NextLevelExperience;
                    NextLevelExperience =(int)((float)NextLevelExperience *  1.25); // increase next level threshold

                    Level++;
                    UpdateUI();
                }

                UpdateUI();
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.tag == "HealthDrop")
            {
                if (Health < MaxHealth)
                {
                    Health += (int)((float)MaxHealth/4);
                    if (Health > MaxHealth) Health = MaxHealth;

                    UpdateUI();
                    Destroy(collision.gameObject);

                }
            }
        }
    }
}