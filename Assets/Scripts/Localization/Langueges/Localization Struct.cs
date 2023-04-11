namespace MyTanks2D
{
    [System.Serializable]
    public struct LocalizationStruct
    {
        public string Rus_Back_Main_Menu;
        public string Eng_Back_Main_Menu;

        public LocalizationStruct(string rus_Back_Main_Menu, string eng_Back_Main_Menu)
        {
            Rus_Back_Main_Menu = rus_Back_Main_Menu;
            Eng_Back_Main_Menu = eng_Back_Main_Menu;
        }
    }
}
