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
    List<Character> ClassList=new();
    ClassList.Add(Active);
    Character Assasin=new("Assasin",25,6,4,16,6);
    ClassList.Add(Assasin);
    Character Mage=new("Mage",30,7,5,11,1);
    ClassList.Add(Mage);
    Character Barbarian=new("Barbarian",50,4,3,13,4);
    ClassList.Add(Barbarian);
    Character Fighter=new("Fighter",40,5,3,14,3);
    ClassList.Add(Fighter);



    Random generator=new();

    opponent=generator.Next(1,ClassList.Count+1);
    Opponent=ClassList[opponent];


    Console.WriteLine("Choose your Class:");
    Console.WriteLine();
    Console.WriteLine("1");
    Assasin.Stats();
    Console.WriteLine();
    Console.WriteLine("2");
    Mage.Stats();
    Console.WriteLine();
    Console.WriteLine("3");
    Barbarian.Stats();
    Console.WriteLine();
    Console.WriteLine("4");
    Fighter.Stats();
    resp=Console.ReadLine().ToLower();
    bool failSafe = int.TryParse(resp, out int resultat);


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
    Console.WriteLine("Each character has different modifiers for damage and accuracy");
    Console.WriteLine("They also have different hp and armor");
    Console.WriteLine("When making an attack you roll a number between 1 and 20 to determine your accuracy");
    Console.WriteLine("Then your accuracy modifier adds to the number you roll, if your combined score exceeds your opponents armor you hit");
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
    Active.Stats();
    Opponent.Stats();

    Console.WriteLine("Let's FIGHT!");
    Console.ReadLine();
    dice=generator.Next(1,21);
    int ActiveInitiative=dice+Active.speed;
    Console.WriteLine($"You rolled ",ActiveInitiative,"for initiative");
    int OpponentInitiative=dice+Opponent.speed;
    Console.WriteLine($"Your opponent rolled ", OpponentInitiative, " for initiative");

    while(0<Active.hp&&0<Opponent.hp){
        if(ActiveInitiative>=OpponentInitiative){
            ActiveAttack(Active,Opponent,generator,dice);
        }
        else if(OpponentInitiative>ActiveInitiative){
            OpponentAttack(Active,Opponent,generator,dice);
        }
        if(ActiveInitiative<OpponentInitiative){
            ActiveAttack(Active,Opponent,generator,dice);
        }
        else if(OpponentInitiative<=ActiveInitiative){
            OpponentAttack(Active,Opponent,generator,dice);
        }
        if(Active.hp<0){Active.hp=0;}        
        if(Opponent.hp<0){Opponent.hp=0;}
        if(Opponent.hp==0&&Active.hp==0){Console.WriteLine("It's a tie!");}
        else if(Opponent.hp==0){Console.WriteLine("Congrats, you won!");}
        else if(Active.hp==0){Console.WriteLine("You lost, better luck next time");}
    }


    static void ActiveAttack(Character Active, Character Opponent, Random generator, int dice){

        Console.WriteLine("Press ENTER to attack");
        Console.ReadLine();
        dice=generator.Next(1,21);
        Console.WriteLine($"You rolled ",dice+Active.accuracy);
        if(dice+Active.accuracy>=Opponent.armorClass){
            Console.WriteLine("You hit!");
            Console.WriteLine("Press ENTER to roll for damage");
            Console.ReadLine();
            dice=generator.Next(1,13);
            Console.WriteLine($"You dealt ",dice+Active.dmg," damage");
            Opponent.hp-=dice+Active.dmg;
            Console.WriteLine($"Opponents health: ",Opponent.hp);
            Console.ReadLine();
        }
        else{
            Console.WriteLine("You missed");
            Console.ReadLine();
        }
    }
    static void OpponentAttack(Character Active, Character Opponent, Random generator, int dice){
        Console.WriteLine("Your Opponent attacks");
        dice=generator.Next(1,21);
        Console.WriteLine($"Your opponent rolled ",dice+Opponent.accuracy);

        if(dice+Opponent.accuracy>=Active.armorClass){
            Console.WriteLine("Your Opponent hit");
            Console.ReadLine();
            dice=generator.Next(1,13);
            Console.WriteLine($"Your Opponent dealt ",dice+Opponent.dmg," damage");
            Active.hp-=dice+Opponent.dmg;
            Console.WriteLine($"Your health: ",Active.hp);
            Console.ReadLine();
        }    
    }
}