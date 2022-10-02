using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // Scene Vars
        public GameObject CameraObject;
        public RobertGameManager GameManager;

        // Weapons
        public GameObject SwordWeapon;
        public GameObject BowWeapon;
        public GameObject SpellBookWeapon;

        // Obj Components
        public Rigidbody2D rb;
        public SpriteRenderer ren;

        // Passive Modifiers
        public float DamageModifier;
        public float SpeedModifier;

        public int PermanentHealthAddition;
        public float PermanentDamageAddition;

        // Movement
        public float Speed;
        public Vector2 Orientation;
        public GameStructures.Direction Direction;
        public Sprite DirectionUp, DirectionDown, DirectionLeft, DirectionRight;

        // health
        public int Health;
        public int MaxHealth = 500;

        // XP
        public int Experience = 0;
        public int NextLevelExperience = 10;
        public int Level = 1;

        private void Start()
        {

            SpeedModifier = 1;
            DamageModifier = 1;

            PermanentHealthAddition = (int)PlayerPrefs.GetFloat(GameStructures.HpIncreaseAmountKey);
            MaxHealth += PermanentHealthAddition;
            Health = MaxHealth;

            PermanentDamageAddition = (int)PlayerPrefs.GetFloat(GameStructures.DamageIncreaseFactorKey);
            DamageModifier += PermanentDamageAddition;

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

            int newHealth = (int)PlayerPrefs.GetFloat(GameStructures.HpIncreaseAmountKey);
            if(newHealth > PermanentHealthAddition)
            {
                int diff = newHealth - PermanentHealthAddition;
                Health += diff;
                MaxHealth += diff;
                PermanentHealthAddition += diff;
                UpdateUI();
            }

            float newDamage = (int)PlayerPrefs.GetFloat(GameStructures.DamageIncreaseFactorKey);
            if (newDamage > PermanentDamageAddition)
            {
                float diff = newDamage - PermanentDamageAddition;
                DamageModifier += diff;
                PermanentDamageAddition += diff;
                UpdateUI();
            }

        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            UpdateUI();

            if (Health <= 0)
                GameManager.GameOver();
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
            GameManager.UpdateItemLevels();
        }

        public void ApplyReward(int rewardId)
        {
            if(rewardId == -1)
            {
                Health = MaxHealth;
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
                Health += newMaxHealth;
                MaxHealth += newMaxHealth;

            }

            if (rewardId == (int)GameStructures.LevelUpListItems.GiantsHeritage)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.GiantsHeritage]++;
                DamageModifier += GameStructures.damageModifierValues[GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.GiantsHeritage]];
            }


            if(rewardId == (int)GameStructures.LevelUpListItems.Sword)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.Sword]++;
                SwordWeapon.GetComponent<Sword>().LevelUp();
            }

            if (rewardId == (int)GameStructures.LevelUpListItems.Bow)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.Bow]++;
                BowWeapon.GetComponent<RangeBow>().LevelUp();
            }

            if (rewardId == (int)GameStructures.LevelUpListItems.SpellBook)
            {
                GameManager.ItemsLevels[(int)GameStructures.LevelUpListItems.SpellBook]++;
                SpellBookWeapon.GetComponent<MagicBookController>().LevelUp();
            }
            UpdateUI();
        }

        public void GetXP()
        {
            Experience++;

            if (Experience >= NextLevelExperience)
            {

                GameManager.StartLevelUp();
                Experience -= NextLevelExperience;
                NextLevelExperience = (int)((float)NextLevelExperience * 2.5); // increase next level threshold

                Level++;
                UpdateUI();
            }

            UpdateUI();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag == "XP/Normal")
            {

                //Experience++;

                //if(Experience >= NextLevelExperience)
                //{

                //    GameManager.StartLevelUp();
                //    Experience -= NextLevelExperience;
                //    NextLevelExperience =(int)((float)NextLevelExperience *  1.25); // increase next level threshold

                //    Level++;
                //    UpdateUI();
                //}

                //UpdateUI();
                //Destroy(collision.gameObject);
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