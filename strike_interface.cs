namespace OOP_project_idf
{
    internal interface StrikeUni
    {
        void Strike();
        int NumberOfHits();
        int Fuel();
        string Efficiency();
        string NameForValidity();
        string Bomb();
        int setNumberOfHits(int numberOfHits);
    }
}