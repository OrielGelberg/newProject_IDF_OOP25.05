using System.Collections.Generic;

namespace OOP_project_idf
{
    internal interface Terrorist_organization
    {
        string getCommander();
        string getDateEstablished();
        void setCpmmander(string newCommander);
        List<Terrorist> getTerrorist();
        void KillTerrorist(string name);
    }
}