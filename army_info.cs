using System;

namespace OOP_project_idf
{
    internal class InformationAboutTheArmy
    {
        private string dateOfEstablishment;
        private string commandInChief;
        private string attackOptions;

        public InformationAboutTheArmy(string commandInChief, string attackOptions)
        {
            this.dateOfEstablishment = "26 05 1948";
            this.commandInChief = commandInChief;
            this.attackOptions = attackOptions;
        }

        public void PrintInformation()
        {
            Console.WriteLine($" dateOfEstablishment {this.dateOfEstablishment}, commandInChief {this.commandInChief}, attackOptions{this.attackOptions} ");
        }
    }
}