using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    class ExtendedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
            base.ExecuteCommand(inputParams);
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character;
            Team team;
            switch (inputParams[5].ToLower())
            {
                case "red":
                    team = Team.Red;
                    break;
                case "blue":
                    team = Team.Blue;
                    break;
                default:
                    throw new ApplicationException("Wrong color team.");
            }

            switch (inputParams[1])
            {
                case "warrior":
                    string id = inputParams[2];
                    int x = int.Parse(inputParams[3]);
                    int y = int.Parse(inputParams[4]);
                    team = (Team)Enum.Parse(typeof(Team), inputParams[5]);

                    Characters.Warrior war = new Characters.Warrior(id, x, y, team);
                    this.characterList.Add(war);
                    break;
                case "mage":
                    string idM = inputParams[2];
                    int xM = int.Parse(inputParams[3]);
                    int yM = int.Parse(inputParams[4]);
                    team = (Team)Enum.Parse(typeof(Team), inputParams[5]);

                    Characters.Mage mag = new Characters.Mage(idM, xM, yM, team);
                    this.characterList.Add(mag);
                    break;
                case "healer":
                    string idH = inputParams[2];
                    int xH = int.Parse(inputParams[3]);
                    int yH = int.Parse(inputParams[4]);
                    team = (Team)Enum.Parse(typeof(Team), inputParams[5]);

                    Characters.Healer hel = new Characters.Healer(idH, xH, yH, team);
                    this.characterList.Add(hel);
                    break;
                default:
                    throw new ApplicationException("No such kind of hero.");
                    break;
            }
            
            base.CreateCharacter(inputParams);
        }

        protected new void AddItem(string[] inputParams)
        {
            string idName = inputParams[1];
            Character idCharacter = this.characterList.Find(ch => ch.Id == idName);
            //Find or First
            

            switch (inputParams[2])
            {
                case "shield":
                    string id = inputParams[3];
                    idCharacter.AddToInventory(new Shield(id));
                    break;
                case "axe":
                    string idA = inputParams[3];
                    idCharacter.AddToInventory(new Axe(idA));
                    break;
                case "injection":
                    string idI = inputParams[3];
                    idCharacter.AddToInventory(new Injection(idI));
                    break;
                case "pill":
                    string idP = inputParams[3];
                    idCharacter.AddToInventory(new Pill(idP));
                    break;
                default:
                    break;
            }
        }
    }
}
