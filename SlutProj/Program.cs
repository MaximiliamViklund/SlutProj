using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;


Character Active=new(null,-1,-1,-1,-1,-1);
Character Opponent=new(null,-1,-1,-1,-1,-1);
bool play=false;

Menu(Active,Opponent,play);
Console.ReadLine();

static void Menu(Character Active,Character Opponent, bool play){
    string resp;
    Console.WriteLine("Welcome to THE FIGHTING GAME");
    Console.WriteLine("Choose a class to play");
    Console.WriteLine("a) Choose Class");
    Console.WriteLine("b) Read Rules");
    Console.WriteLine("c) Store");
    Console.WriteLine("d) Play");
    Console.WriteLine("q) Quit");
    if(play==true){
        Active.Stats();
    }
    resp=Console.ReadLine().ToLower();

    if(resp=="d"&&play==true){
        Console.Clear();
        Play(Active,Opponent,play);
    }
    else if(resp=="d"&&play==false){
        Console.Clear();
        Console.WriteLine("Choose a class first");
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play);
    }
    else if(resp=="a"){
        play=true;
        Console.Clear();
        Classes(Active,Opponent,play);
    }
    else if(resp=="b"){
        Console.Clear();
        Rules(Active,Opponent,play);
    }
    else if(resp=="c"){
        Console.Clear();
        Store();
    }
    else if (resp=="q"){
        Console.Clear();
    }
    else{
        Console.Clear();
        Console.WriteLine("Not a valid response");
        Console.ReadLine();
        Console.Clear();
        Menu(Active, Opponent, play);
    }
}


static void Classes(Character Active, Character Opponent, bool play){
    string resp;    //string to read ReadLines
    int opponent;   //int to randomize Opponents Class

    //Creating classes and adding them to CharacterList
    //Choose to make a list because it enables me to easily add more charcter classes
    List<Character> ClassList=new();
    Character Assasin=new("Assasin",25,6,4,16,6);
    ClassList.Add(Assasin);
    Character Mage=new("Mage",30,7,5,11,1);
    ClassList.Add(Mage);
    Character Barbarian=new("Barbarian",50,4,3,13,4);
    ClassList.Add(Barbarian);
    Character Fighter=new("Fighter",40,5,3,14,3);
    ClassList.Add(Fighter);



    Random generator=new();

    opponent=generator.Next(1,ClassList.Count);
    Opponent=ClassList[opponent];


    Console.WriteLine("Choose your Class:");
    for (int i = 0; i < ClassList.Count; i++)
    {
        Console.WriteLine();
        Console.WriteLine(i+1);
        ClassList[i].Stats();
    }
    resp=Console.ReadLine().ToLower();
    bool failSafe = int.TryParse(resp, out int resultat);
    resultat--;


    if(failSafe==true&&resultat<=ClassList.Count){
        Active=ClassList[resultat];
    }
    else{
        Console.Clear();
        Console.WriteLine("Not a valid response");
        Console.ReadLine();
        Console.Clear();
        Classes(Active, Opponent,play);
    }
    failSafe=false;
    Console.Clear();
    Console.WriteLine("Your character:");
    Active.Stats();
    Console.ReadLine();
    Console.Clear();
    Menu(Active,Opponent,play);
}

static void Rules(Character Active, Character Opponent, bool play){
    Console.WriteLine("First, you choose a character");
    Console.WriteLine("Each character has different modifiers for damage, accuracy and initiative");
    Console.WriteLine("They also have different hp and armor");
    Console.WriteLine("Before you fight you roll for iniative, this determines who attacks first");
    Console.WriteLine("When making an attack you roll a number between 1 and 20 to determine your accuracy");
    Console.WriteLine("Then your accuracy modifier adds to the number you roll, if your combined score exceeds your opponents armor you adder");
    Console.WriteLine("If you hit you then determine your damage");
    Console.WriteLine("You again roll a random number, this time between 1 and 12, and add your damage modifier");
    Console.WriteLine("First one to hit 0 hp loses");
    Console.WriteLine("Good luck!");
    Console.WriteLine("Press ENTER");
    Console.ReadLine();
    Console.Clear();
    Menu(Active,Opponent,play);
}

static void Store(){

}

static void Play(Character Active, Character Opponent, bool play){
    Random generator=new();
    int dice;

    Console.WriteLine("Your Character:");
    Active.Stats();
    Console.WriteLine();
    Console.WriteLine("Your Opponents Character:");
    Opponent.Stats();
    Console.ReadLine();
    Console.Clear();

    Console.WriteLine("Let's FIGHT!");
    Console.WriteLine("Press ENTER");
    Console.ReadLine();
    dice=generator.Next(1,21);
    int ActiveInitiative=dice+Active.speed;
    Console.WriteLine("You rolled "+ActiveInitiative+" for initiative");
    int OpponentInitiative=dice+Opponent.speed;
    Console.WriteLine("Your opponent rolled "+OpponentInitiative+" for initiative");
    Console.ReadLine();
    Console.Clear();

    while(0<Active.hp&&0<Opponent.hp){
        Console.WriteLine("Your health: "+Active.hp);
        Console.WriteLine("Opponents health: "+Opponent.hp);
        Console.WriteLine();
        if(ActiveInitiative>=OpponentInitiative&&Active.hp!=0){
            ActiveAttack(Active,Opponent,generator,dice);
        }
        else if(OpponentInitiative>ActiveInitiative&&Opponent.hp!=0){
            OpponentAttack(Active,Opponent,generator,dice);
        }
        if(ActiveInitiative<OpponentInitiative&&Active.hp!=0){
            ActiveAttack(Active,Opponent,generator,dice);
        }
        else if(OpponentInitiative<=ActiveInitiative&&Opponent.hp!=0){
            OpponentAttack(Active,Opponent,generator,dice);
        }

        if(Opponent.hp==0){Console.WriteLine("Congrats, you won!");}
        else if(Active.hp==0){
            Console.WriteLine("You lost, better luck next time");
        Console.ReadLine();
        }
        Console.Clear();
    }
    Menu(Active,Opponent,play);


    static void ActiveAttack(Character Active, Character Opponent, Random generator, int dice){
        int adder=0;

        Console.WriteLine();
        Console.WriteLine("Press ENTER to attack");
        Console.ReadLine();
        dice=generator.Next(1,21);
        adder=dice+Active.accuracy;
        Console.WriteLine("You rolled a "+adder);
        if(adder>=Opponent.armorClass){
            Console.WriteLine("You hit!");
            Console.WriteLine("Press ENTER to roll for damage");
            Console.ReadLine();
            dice=generator.Next(1,13);
            adder=dice+Active.dmg;
            Console.WriteLine("You dealt "+adder+" damage");
            Opponent.hp-=adder;
            if(Opponent.hp<0){Opponent.hp=0;}
            Console.WriteLine("Opponents health is now "+Opponent.hp);
            Console.ReadLine();
        }
        else{
            Console.WriteLine("You missed");
            Console.ReadLine();
        }
    }
    static void OpponentAttack(Character Active, Character Opponent, Random generator, int dice){
        int adder=0;

        Console.WriteLine("Your Opponent attacks");
        dice=generator.Next(1,21);
        adder=dice+Opponent.accuracy;
        Console.WriteLine("They rolled a "+adder);

        if(adder>=Active.armorClass){
            Console.WriteLine("Your Opponent hit");
            Console.ReadLine();
            dice=generator.Next(1,13);
            adder=dice+Opponent.dmg;
            Console.WriteLine("They deal "+adder+" damage to you");
            Active.hp-=adder;
            if(Active.hp<0){Active.hp=0;} 
            Console.WriteLine("Your health is now "+Active.hp);
            Console.ReadLine();
        }
        else{
            Console.WriteLine("And they missed");
        }
    }
}