class Character{
    public string namn;
    public int hp;
    public int dmg;
    public int accuracy;
    public int armorClass;
    public Character(string namn, int hp, int dmg, int accuracy, int armorClass){
        this.namn=namn;
        this.hp=hp;
        this.dmg=dmg;
        this.accuracy=accuracy;
        this.armorClass=armorClass;
    }
    public void Stats(){
                Console.WriteLine(namn);
                Console.WriteLine("Hp: "+hp);
                Console.WriteLine("Armor Class: "+armorClass);
                Console.WriteLine("Accuracy modifier: +"+accuracy);
                Console.WriteLine("Damage modifier: +"+dmg);
    }
}