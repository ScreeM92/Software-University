﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class CustomizedEngine : Engine
    {
        public CustomizedEngine()
            : base(){ }
        
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;

                case "add":
                    AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character newCharacter;
            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    newCharacter = new Warrior(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        200,
                        100,
                        150,
                       (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        2);
                    this.characterList.Add(newCharacter);
                    break;

                case "mage":
                    newCharacter = new Mage(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        150,
                        50,
                        300,
                       (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        5);
                    this.characterList.Add(newCharacter);
                    break;

                case "healer":
                    newCharacter = new Healer(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        75,
                        50,
                        60,
                       (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        6);
                    this.characterList.Add(newCharacter);
                    break;
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            Character characterToAcceptIitem = GetCharacterById(inputParams[1]);
            Item itemToAdd;
            switch (inputParams[2])
            {
                case "axe":
                    itemToAdd = new Axe(inputParams[3]);
                    characterToAcceptIitem.AddToInventory(itemToAdd);
                    break;
                case "shield":
                    itemToAdd = new Shield(inputParams[3]);
                    characterToAcceptIitem.AddToInventory(itemToAdd);
                    break;
                case "injection":
                    itemToAdd = new Injection(inputParams[3]);
                    characterToAcceptIitem.AddToInventory(itemToAdd);
                    break;
                case "pill":
                    itemToAdd = new Pill(inputParams[3]);
                    characterToAcceptIitem.AddToInventory(itemToAdd);
                    break;
                default:
                    break;
            }
        }
    }
}