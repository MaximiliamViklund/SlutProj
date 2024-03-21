class Character
{
    public string namn;
    public int hp;
    public int dmg;
    public int accuracy;
    public int armorClass;
    public Character(string namn, int hp, int dmg, int accuracy, int armorClass)
    {
        this.namn = namn;
        this.hp = hp;
        this.dmg = dmg;
        this.accuracy = accuracy;
        this.armorClass = armorClass;
    }


    public void Stats()
    {
        Console.WriteLine(namn);
        Console.WriteLine(hp>=0?"Hp: "+hp:null);
        Console.WriteLine(armorClass>=0?"Armor Class: "+armorClass:null);
        Console.WriteLine(accuracy>=0?"Accuracy modifier: +"+armorClass:null);
        Console.WriteLine(dmg>=0?"Damage modifier: +"+dmg:null);
    }
}