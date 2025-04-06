using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public class Entity
    {
        protected int hp = 100;
        protected bool isDead = false;

        public int GetHp()
        {
            return hp;
        }
        public bool IsDead()
        {
            return isDead;
        }

        public bool SetHp(int hp)
        {
            this.hp -= hp;
            if (hp < 0)
            {
                hp = 0;
                isDead = true;
            }

            return isDead;
        }
    }

    class Attacks
    {
        private int damage;
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }

        }

        private int timeCost;
        public int TimeCost
        {
            get
            {
                return timeCost;
            }
            set
            {
                timeCost = value;
            }
        }
    }

    Attacks swordAtk = new Attacks();
    Attacks fistAtk = new Attacks();
    Attacks amuletAtk = new Attacks();
    class PlayerEntity : Entity
    {
        int age = 20;
        int finalAge;

        public int GetAge()
        {
            return age;
        }
        public int GetFinalAge()
        {
            return finalAge;
        }
        public void SetFinalAge(int age)
        {
            finalAge = age;
        }

        public bool SetAge(int age)
        {
            this.age += age;

            if (age > finalAge)
            {
                isDead = true;
            }

            return isDead;
        }

        public int GetRemainingLife()
        {
            return finalAge - age;
        }
    }
    class EnemyEntity : Entity
    {

    }

    PlayerEntity playerEntity = new PlayerEntity();
    EnemyEntity enemyEntity = new EnemyEntity();

    private void Awake()
    {
        playerEntity.SetFinalAge(Random.Range(50, 100));
        Debug.Log(playerEntity.GetFinalAge());
        swordAtk.Damage = 20;
        swordAtk.TimeCost = 2;

        fistAtk.Damage = 10;
        fistAtk.TimeCost = 1;

        amuletAtk.Damage = -10;
        amuletAtk.TimeCost = 10; 
    }

    bool playerTurn = true;
    bool oponentIsAlive = true;
    float enemyTimer = 5f;
    float timer = 0f;

    private bool playerHasPeopleRespect = true;
    private bool playerHasArmyRespect= true;

    // Player sliders
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private Slider playerAgeSlider;
    
    // Demon sliders
    [SerializeField] private Slider enemyHealthSlider;

    // Timer
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private GameObject turnIndicatorPlayer;
    [SerializeField] private GameObject turnIndicatorEnemy;

    public void PlayerLoosesPeopleRespect()
    {
        playerHasPeopleRespect = false;
    }

    public void PlayerLoosesArmyRespect()
    {
        playerHasArmyRespect = false;
    }
    
    private void UpdateSlideBars()
    {
        playerHealthSlider.value = playerEntity.GetHp();
        playerAgeSlider.maxValue = playerEntity.GetFinalAge();
        playerAgeSlider.value = playerEntity.GetFinalAge() - 20 - playerEntity.GetAge();
        
        enemyHealthSlider.value = enemyEntity.GetHp();
    }
    int aiTurns = 3;
    void Update()
    {
        if (playerEntity.GetHp() <= 20 ||
            enemyEntity.GetHp() <= 20 ||
            playerEntity.GetRemainingLife() <= 20)
        {
            UpdateSlideBars();
            Debug.Log("You can ask the kid for help.");
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Asked the kid for help
                if (playerHasPeopleRespect)
                {
                    // Player is helped
                    // Load next scene
                }
                else
                {
                    // Game over you die
                }
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                // Don't use kid's help
                if (playerHasArmyRespect)
                {
                    // get help from a soldier
                } else
                {
                    // there is nobody to help you.
                }
            }

        }
        else if (playerTurn)
        {
            turnIndicatorPlayer.SetActive(true);
            turnIndicatorEnemy.SetActive(false);
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Sword
                playerTurn = false;

                enemyEntity.SetHp(swordAtk.Damage);
                playerEntity.SetAge(swordAtk.TimeCost);


            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                // Fist
                playerTurn = false;

                enemyEntity.SetHp(fistAtk.Damage);
                playerEntity.SetAge(fistAtk.TimeCost);

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // Amulet
                playerTurn = false;

                playerEntity.SetHp(amuletAtk.Damage);
                playerEntity.SetAge(swordAtk.TimeCost);

            }

            UpdateSlideBars();
            if (playerEntity.IsDead())
            {
                Debug.Log("Game Over");
            }
            else if (enemyEntity.IsDead())
            {
                Debug.Log("Next Scene");
            }
        } else 
        {
            turnIndicatorPlayer.SetActive(false);
            turnIndicatorEnemy.SetActive(true);
            timer += Time.deltaTime;
            timerText.text = ((int)(enemyTimer - timer)).ToString();
            if (timer > enemyTimer)
            {
                timer = 0f;
                playerTurn = true;

                //switch (Random.Range(0, 2))
                //{
                //    case 0:
                //        playerEntity.SetHp(swordAtk.Damage);
                //        break;

                //    case 1:
                //        playerEntity.SetHp(fistAtk.Damage);
                //        break;

                //    default:
                //        Debug.Log("Illegal");
                //        break;
                //}

                switch (aiTurns)
                {
                    case 3:
                        playerEntity.SetHp(30);
                        playerEntity.SetAge(10);
                    break;
                    
                    case 2:
                        playerEntity.SetHp(20);
                    break;

                    case 1:
                        playerEntity.SetHp(30);
                        playerEntity.SetAge(10);
                    break;

                    case 0:
                        playerEntity.SetHp(30);
                        playerEntity.SetAge(10);
                    break ;
                    
                    default:
                        break;
                }
            }

            UpdateSlideBars();
            if (playerEntity.IsDead())
            {
                Debug.Log("Player is dead!!");
            }
            else if (enemyEntity.IsDead())
            {
                Debug.Log("You won, proceed to detective!");
            }
        }
    }
}
