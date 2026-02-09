using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class dND : MonoBehaviour
{
    public enum characterClasses
    {
        Aasimar,
        Dragonborn,
        Dwarf,
        Elf,
        Gnome,
        Goliath,
        Halfling,
        Human,
        Orc,
        Tiefling
    }
    public enum feats
    {
        none,
        Tough,
        Stout,
    }
    [System.Serializable]
    public class playerInfo
    {
        [Header("Character Info")]
        public string characterName;
        public int characterLevel;
        public int conScore;
        public characterClasses characterClass;
        public feats characterFeat;
        [Tooltip("If set to false HP will be rolled instead!")]public bool hpAveraged;
        public int ID;
    }
    
    public int characterID;

    public List<playerInfo> players = new List<playerInfo>();

    public void CalculateCharacter()
    {
        if (players.Count == 0 || characterID < 0 || characterID >= players.Count)
            return;

        playerInfo p = players[characterID];

        // Constitution modifier
        int conModifier = Mathf.FloorToInt((p.conScore - 10) / 2f);

        // Base hit die (using d8)
        float hitDie;

        if (p.hpAveraged)
        {
            hitDie = 4.5f; // average of d8
        }
        else
        {
            hitDie = Random.Range(1, 9); // rolled d8
        }

        // HP per level
        float hpPerLevel = hitDie + conModifier;

        // Race bonus per level
        int raceBonus = 0;
        switch (p.characterClass)
        {
            case characterClasses.Dwarf:
                raceBonus = 2;
                break;
            case characterClasses.Orc:
            case characterClasses.Goliath:
                raceBonus = 1;
                break;
        }

        // Feat bonus per level
        int featBonus = 0;
        switch (p.characterFeat)
        {
            case feats.Tough:
                featBonus = 2;
                break;
            case feats.Stout:
                featBonus = 1;
                break;
        }

        // Total HP
        int totalHP = Mathf.FloorToInt(
            (hpPerLevel * p.characterLevel) +
            (raceBonus * p.characterLevel) +
            (featBonus * p.characterLevel)
        );

        Debug.Log(
            "My character " + p.characterName +
            " is a level " + p.characterLevel + " " +
            p.characterClass +
            " with " + p.conScore + " CON and the " +
            p.characterFeat +
            " feat. I want the HP " +
            (p.hpAveraged ? "averaged" : "rolled") +
            ". Total HP: " + totalHP
        );
    }


    public void EstablishID()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].ID = i;
        }
    }

    void OnValidate()
    {
        EstablishID();
        CalculateCharacter();
    }
}