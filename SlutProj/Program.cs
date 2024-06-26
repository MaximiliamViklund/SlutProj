﻿
//-----------------------------Pseudokod---------------------------------//
//A function for the main menu so that you can always return to it
//A function for each part of the game
//Class choosing menu
//Shop
//Play
//Put all of these as choices in the main menu functions
//Use the readline function to read the users input in the menu
//Use an if-statement with a switch-statement in it to use different functions depending on input from readline
//Regulate input by using else


//Creates two characters that are used as defaults
Character Active=new(null,-1,-1,-1,-1,-1);
Character Opponent=new(null,-1,-1,-1,-1,-1);
//Creates base health ints to Shop default hp during the game
int activeBaseHp=0;
int opponentBaseHp=0;
bool play=false;
int gold=0;

Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
Console.ReadLine();

static void Text(string text){ //Function takes string and writes it out in green
    Console.ForegroundColor=ConsoleColor.Green;
    Console.WriteLine(text);
    Console.ForegroundColor=ConsoleColor.White;
}


//-------------------------------MAIN MENU------------------------------------------------------------------//
static void Menu(Character Active,Character Opponent, bool play, int activeBaseHp, int opponentBaseHp, int gold){
    Text("Welcome to THE FIGHTING GAME");
    Text("Choose a class to play");
    Console.WriteLine("a) Choose Class");
    Console.WriteLine("b) Read Rules");
    Console.WriteLine("c) Shop");
    Console.WriteLine("d) Play");
    Console.WriteLine("q) Quit");
    if(play==true){
        Console.WriteLine();
        Active.Stats();
    }
    Console.WriteLine();
    Console.WriteLine("Your gold: "+gold);
    string resp=Console.ReadLine().ToLower();


    //Reads resp and uses different functions depending on input
    switch(resp){
        case"a": //Starts class choosing function
        play=true;
        Console.Clear();
        Classes(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "b": //Starts rules function
        Console.Clear();
        Rules(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "c":
        Console.Clear();
        Shop(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "d" when play==false: //Stops user from starting play function if a class has not been choosen
        Console.Clear();
        Console.WriteLine("Choose a class first");
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;
        
        case "d" when play==true:
        Console.Clear();
        Play(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "q":
        Console.Clear();
        break;

        default:
        Console.Clear();
        Console.WriteLine("Not a valid response");
        Console.ReadLine();
        Console.Clear();
        Menu(Active, Opponent, play,activeBaseHp,opponentBaseHp,gold);
        break;
    }
}

//--------------------------------------------Class Chooser--------------------------------------//
static void Classes(Character Active, Character Opponent, bool play, int activeBaseHp, int opponentBaseHp, int gold){
    string resp;    //string to read ReadLines

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


    Text("Enter number associated with the class you want to play:");
    for (int i = 0; i < ClassList.Count; i++)   //For loop writes out all available classes and the number the user needs to enter to choose each class
    {
        Console.WriteLine();
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine(i+1);
        Console.ForegroundColor=ConsoleColor.White;
        ClassList[i].Stats();
    }
    resp=Console.ReadLine().ToLower();
    bool failSafe = int.TryParse(resp, out int resultat);
    resultat--;


    if(failSafe==true&&resultat<ClassList.Count&&resultat>-1){ //Makes sure that user cant input invalid numbers
        Active=ClassList[resultat];
        activeBaseHp=Active.hp;
    }
    else{
        Console.Clear();
        Console.WriteLine("Not a valid response");
        Console.ReadLine();
        Console.Clear();
        Classes(Active, Opponent,play,activeBaseHp,opponentBaseHp,gold);
    }

    int opponent=resultat;
    Random generator=new();
    while(opponent==resultat){opponent=generator.Next(0,ClassList.Count);} //Randomizes opponents class and makes sure it isn't the same as the users class
    Opponent=ClassList[opponent];
    opponentBaseHp=Opponent.hp;

    failSafe=false;
    Console.Clear();
    Console.WriteLine("Your character:");
    Active.Stats();
    Console.ReadLine();
    Console.Clear();
    Menu(Active,Opponent,play, activeBaseHp,opponentBaseHp,gold);
}


//--------------------------------------------------------RULES--------------------------------------------------------------//
static void Rules(Character Active, Character Opponent, bool play, int activeBaseHp, int opponentBaseHp, int gold){ //Writes out rules for the game/how the game works
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
    Text("Press ENTER");
    Console.ReadLine();
    Console.Clear();
    Menu(Active,Opponent,play, activeBaseHp,opponentBaseHp,gold);
}


//--------------------------------------------Shop-----------------------------------------------//
static void Shop(Character Active, Character Opponent, bool play, int activeBaseHp, int opponentBaseHp, int gold){

    Console.WriteLine("Welcome to the Shop!!");
    Console.WriteLine("Anything you buy will be reset if you change your class.");
    Console.WriteLine("What would you like?");
    Console.WriteLine("Your gold: "+gold);
    Console.WriteLine("q) Menu");
    Console.WriteLine();
    Text("a");
    Console.WriteLine("Chainmail Armour");
    Console.WriteLine("+1 to your Armor Class");
    Console.WriteLine("Costs 10 gold");
    Console.WriteLine();
    Text("b");
    Console.WriteLine("Silver Sword");
    Console.WriteLine("+1 to damage");
    Console.WriteLine("Costs 15 gold");
    Console.WriteLine();
    Text("c");
    Console.WriteLine("Eyes of Steel");
    Console.WriteLine("+1 to your accuracy");
    Console.WriteLine("Costs 10 gold");
    Console.WriteLine();
    Text("d");
    Console.WriteLine("Sword of Tyr");
    Console.WriteLine("+3 to damage");
    Console.WriteLine("Costs 30 gold");
    Console.WriteLine();
    string resp=Console.ReadLine().ToLower();

    switch(resp){ //Takes input and amount of gold and changes stats depending on these
        case "a" when gold>=10:
        Console.WriteLine("You bought Chainmail Armour");
        Active.armorClass+=1;
        gold-=10;
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;
        case "a" when gold<10:
        Console.WriteLine("You don't have enough gold for that");
        Console.ReadLine();
        Console.Clear();
        Shop(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "b" when gold>=15:
        Console.WriteLine("You bought a Silver Sword");
        Active.dmg+=1;
        gold-=15;
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;
        case "b" when gold<15:
        Console.WriteLine("You don't have enough gold for that");
        Console.ReadLine();
        Console.Clear();
        Shop(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "c" when gold>=10:
        Console.WriteLine("You bought Eyes of Steel");
        Active.accuracy+=1;
        gold-=10;
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;
        case "c" when gold<10:
        Console.WriteLine("You don't have enough gold for that");
        Console.ReadLine();
        Console.Clear();
        Shop(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "d" when gold>=30:
        Console.WriteLine("You bought The Sword of Tyr");
        Active.dmg+=3;
        gold-=30;
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;
        case "d" when gold<30:
        Console.WriteLine("You don't have enough gold for that");
        Console.ReadLine();
        Console.Clear();
        Shop(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "g" when gold>=200: //Little easteregg hehe
        Console.WriteLine("You are now GOD");
        Active.dmg+=100;
        Active.accuracy+=30;
        Active.armorClass+=25;
        Active.speed+=20;
        Active.hp+=200;
        Console.ReadLine();
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        case "q":
        Console.Clear();
        Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;

        default:
        Console.WriteLine("Not a valid response.");
        Console.ReadLine();
        Console.Clear();
        Shop(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);
        break;
    }
}


//-----------------------------------PLAY---------------------------------------------//
static void Play(Character Active, Character Opponent, bool play, int activeBaseHp, int opponentBaseHp, int gold){
    Random generator=new();
    int dice;
    bool iniative=false;

    Console.WriteLine("Your Character:");
    Active.Stats();
    Console.WriteLine();
    Console.WriteLine("Your Opponents Character:");
    Opponent.Stats();
    Console.ReadLine();
    Console.Clear();

    Text("Let's FIGHT!");
    Text("Press ENTER");
    Console.ReadLine();
    dice=generator.Next(1,21);
    int ActiveInitiative=dice+Active.speed;
    dice=generator.Next(1,21);
    int OpponentInitiative=dice+Opponent.speed;
    if(ActiveInitiative>=OpponentInitiative){iniative=true;} //Makes boolean initiative true if users iniative is higher than the opponents
    Console.WriteLine("You rolled "+ActiveInitiative+" for initiative");
    Console.WriteLine("Your opponent rolled "+OpponentInitiative+" for initiative");
    if(iniative==true){Console.WriteLine("You will start");}else{Console.WriteLine("Your opponent will start");}
    Console.ReadLine();
    Console.Clear();


    while(0<Active.hp&&0<Opponent.hp){ //Loop playing the game
        Console.WriteLine("Your health: "+Active.hp);
        Console.WriteLine("Opponents health: "+Opponent.hp);
        Console.WriteLine();
        if(iniative==true&&Active.hp!=0){ //Makes sure that whoever has higher iniative plays first
            ActiveAttack(Active,Opponent,generator,dice);
            if(Opponent.hp!=0){
                OpponentAttack(Active,Opponent,generator,dice);
            }
        }
        else if(iniative==false&&Opponent.hp!=0){
            OpponentAttack(Active,Opponent,generator,dice);
            if(Active.hp!=0){
                ActiveAttack(Active,Opponent,generator,dice);
            }
        }

        if(Opponent.hp==0){Console.WriteLine("Congrats, you won!");gold+=20;}
        else if(Active.hp==0){
            Console.WriteLine("You lost, better luck next time");
        Console.ReadLine();
        }
        Console.Clear();
    }
    Active.hp=activeBaseHp;
    Opponent.hp=opponentBaseHp;
    Menu(Active,Opponent,play,activeBaseHp,opponentBaseHp,gold);


    static void ActiveAttack(Character Active, Character Opponent, Random generator, int dice){ //Function for users attacks
        int adder=0;
        int hitRoll=21;
        int dmgRoll=13;

        Console.WriteLine();
        Text("Press ENTER to attack");
        Console.ReadLine();
        adder=Modify(Active.accuracy,dice,adder,hitRoll); //Calculates hit roll
        Console.WriteLine("You rolled a "+adder);
        if(adder>=Opponent.armorClass){
            Console.WriteLine("You hit!");
            Text("Press ENTER to roll for damage");
            Console.ReadLine();
            adder=Modify(Active.dmg,dice,adder,dmgRoll); //Calculates damage roll
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
    static void OpponentAttack(Character Active, Character Opponent, Random generator, int dice){ //Function for opponents attack
        int adder=0;
        int hitRoll=21;
        int dmgRoll=13;

        Console.WriteLine("Your Opponent attacks");
        adder=Modify(Opponent.accuracy,dice,adder,hitRoll); //Calculates hit roll
        Console.WriteLine("They rolled a "+adder);

        if(adder>=Active.armorClass){
            Console.WriteLine("Your Opponent hit");
            Console.ReadLine();
            adder=Modify(Opponent.dmg,dice,adder,dmgRoll); //Calculates damage roll
            Console.WriteLine("They deal "+adder+" damage to you");
            Active.hp-=adder;
            if(Active.hp<0){Active.hp=0;} 
            Console.WriteLine("Your health is now "+Active.hp);
            Console.ReadLine();
        }
        else{
            Console.WriteLine("And they missed");
            Console.ReadLine();
        }
    }
    static int Modify(int Modifier, int dice, int adder, int roll){ //Function to calculate rolls
        Random generator=new();
        dice=generator.Next(1,roll);
        adder=dice+Modifier;
        return adder;
    }
}