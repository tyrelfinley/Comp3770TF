using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    static public int bossUpdateDamage = 0;
    static public int partyUpdateDamage = 0;

    public TMP_Text bossHealth, bossDamage, partyHealth, partyDamage;
    public Button Menu;

    class GameCharacter
    {
        public int maxhealth;
        public int health;

        public bool CheckHealth()
        {
            if (health <= 0)
                return true;
            return false;
        }

        public int GetHealth()
        { 
            return health; 
        }

        public void TakeDamage(int amount)
        {
            this.health -= amount;
        }
    }

    class DamageDealer : GameCharacter
    {
        public int damageLow;
        public int damageHigh;

        public DamageDealer(int hp, int low, int high)
        {
            this.maxhealth = hp;
            this.health = hp;
            this.damageLow = low;
            this.damageHigh = high;
        }

        public void DoDamage(GameCharacter Target)
        {
            int amount = UnityEngine.Random.Range(this.damageLow, this.damageHigh);
            Target.TakeDamage(amount);
            partyUpdateDamage += amount;
        }
    }

    class Healer : GameCharacter
    {
        public int mana;

        public Healer(int hp , int mana)
        {
            this.maxhealth = hp;
            this.health = hp;
            this.mana = mana;
        }

        public void Heal(GameCharacter Target, bool specialCast)
        {
            int manaCost = 5;
            if (this.mana < manaCost) return;
            Target.health += 15;
            if (specialCast == true) return;
            this.mana -= manaCost;
        }

        public void BigHeal(GameCharacter Target, bool specialCast)
        {
            int manaCost = 10;
            if (this.mana < manaCost) return;
            Target.health += 25;
            if (specialCast == true) return;
            this.mana -= manaCost;
        }

        public void RegenMana()
        { 
            this.mana += 3; 
        }
    }

    class Boss : GameCharacter
    {
        public int AOElow;
        public int AOEhigh;
        public int Singlelow;
        public int Singlehigh;

        public Boss(int hp, int aoelow, int aoehigh, int singelow, int singlehigh)
        {
            this.maxhealth = hp;
            this.health=hp;
            this.AOElow = aoelow;
            this.AOEhigh = aoehigh;
            this.Singlelow = singelow;
            this.Singlehigh = singlehigh;
        }

        public void Single(GameCharacter Target)
        {
            int amount = UnityEngine.Random.Range(this.Singlelow, this.Singlehigh);
            Target.TakeDamage(amount);
            bossUpdateDamage += amount;
        }

        public void AOE(GameCharacter[] Targets)
        {
            for (int i = 0; i < Targets.Length; i++) 
            {
                int amount = UnityEngine.Random.Range(this.AOElow, this.AOEhigh);
                Targets[i].TakeDamage(amount);
                bossUpdateDamage += amount;
            }
        }
    }

    static DamageDealer Mage = new DamageDealer(1000, 5, 30);
    static DamageDealer Rogue = new DamageDealer(1500, 15, 25);
    static DamageDealer MoonkinDruid = new DamageDealer(1250, 5, 15);
    static DamageDealer Warrior = new DamageDealer(3000, 5, 10);
    static Healer Priest = new Healer(900, 1000);
    
    static Boss boss = new Boss(5000, 5, 20, 40, 50);

    GameCharacter[] AOETargets = {Mage, Rogue, MoonkinDruid, Priest};
    GameCharacter[] Party = {Mage, Rogue, MoonkinDruid, Priest, Warrior};
    GameCharacter[] HealTargets = {Priest, Priest, Mage, Rogue, MoonkinDruid, Warrior};
    GameCharacter[] Characters = { Mage, Rogue, Warrior, MoonkinDruid, Priest, boss };

    public bool CheckHealths()
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            if(Characters[i].CheckHealth() == true)
            {
                return true;
            }
        }
        return false;
    }

    public int GetTotalHealth()
    {
        int totalHealth = 0;
        for (int i = 0; i < Party.Length; i++)
        {
            totalHealth += Party[i].GetHealth();
        }
        return totalHealth;
    }
    public void defaultLevel()
    {
        boss.Single(Warrior);
        boss.AOE(AOETargets);
        Warrior.DoDamage(boss);
        Rogue.DoDamage(boss);
        Mage.DoDamage(boss);
        MoonkinDruid.DoDamage(boss);
        Priest.RegenMana();
        Priest.BigHeal(Warrior, false);
        Priest.Heal(HealTargets[UnityEngine.Random.Range(0, HealTargets.Length)], false);
    }

    public void updateLevelText(int bDMG, int pDMG, int bhealth, int phealth)
    {
        partyDamage.text = "" + pDMG;
        partyHealth.text = "" + phealth;
        bossDamage.text = "" + bDMG;
        bossHealth.text = "" + bhealth;
    }

    int count = 0;

    private void ResetSimulation()
    {
        count = 0;
        partyUpdateDamage = 0;
        bossUpdateDamage = 0;
        boss.health = boss.maxhealth;
        Warrior.health = Warrior.maxhealth;
        Rogue.health = Rogue.maxhealth;
        Mage.health = Mage.maxhealth;
        MoonkinDruid.health = MoonkinDruid.maxhealth;
        Priest.health = Priest.maxhealth;
        Priest.mana = 1000;
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
        ResetSimulation();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // level 1
            if (count == 1)
            {
                Debug.Log("Level 1");
                Debug.Log("Warrior : " + Warrior.GetHealth() + " Mage : " + Mage.GetHealth() + " Rogue : " + Rogue.GetHealth() + " MoonkinDruid : " + MoonkinDruid.GetHealth() + " Priest : " + Priest.GetHealth() + " Boss : " + boss.GetHealth());
                Menu.gameObject.SetActive(true);
                Menu.onClick.AddListener(LoadMenu);
            }
            if (CheckHealths() == true)
            {
                count++;
                return;
            }

            defaultLevel();
            updateLevelText(bossUpdateDamage, partyUpdateDamage, boss.GetHealth(), GetTotalHealth());
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // level 2
            if (count == 1)
            {
                Debug.Log("Level 2");
                Debug.Log("Warrior : " + Warrior.GetHealth() + " Mage : " + Mage.GetHealth() + " Rogue : " + Rogue.GetHealth() + " MoonkinDruid : " + MoonkinDruid.GetHealth() + " Priest : " + Priest.GetHealth() + " Boss : " + boss.GetHealth());
                Menu.gameObject.SetActive(true);
                Menu.onClick.AddListener(LoadMenu);
            }
            if (CheckHealths() == true)
            {
                count++;
                return;
            }

            defaultLevel();
            if (Warrior.GetHealth() <= 1500)
            {
                if (UnityEngine.Random.Range(0, 1) == 0)
                {
                    Priest.BigHeal(Warrior, true);
                }
                else
                {
                    Priest.Heal(Warrior, true);
                }
            }
            updateLevelText(bossUpdateDamage, partyUpdateDamage, boss.GetHealth(), GetTotalHealth());
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            // level 3
            if (count == 1)
            {
                Debug.Log("Level 3");
                Debug.Log("Warrior : " + Warrior.GetHealth() + " Mage : " + Mage.GetHealth() + " Rogue : " + Rogue.GetHealth() + " MoonkinDruid : " + MoonkinDruid.GetHealth() + " Priest : " + Priest.GetHealth() + " Boss : " + boss.GetHealth());
                Menu.gameObject.SetActive(true);
                Menu.onClick.AddListener(LoadMenu);
            }
            if (CheckHealths() == true)
            {
                count++;
                return;
            }

            defaultLevel();
            double damage = bossUpdateDamage / 100;
            Warrior.TakeDamage((int)Math.Round(damage));
            updateLevelText(bossUpdateDamage, partyUpdateDamage, boss.GetHealth(), GetTotalHealth());
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
        }
    }
}
