using System.ComponentModel;
using System.ComponentModel.Design;
Character Active=new(null,-1,-1,-1,-1);
bool play=false;

Menu(Active, play);
Console.ReadLine();

static void Menu(Character Active, bool play){
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
        Console.WriteLine("Test");
        Console.ReadLine();
        Console.Clear();
        Play(Active);
    }
    else if(resp=="d"&&play==false){
        Console.Clear();
        Console.WriteLine("Choose a class first");
        Console.ReadLine();
        Console.Clear();
        Menu(Active, play);
    }
    else if(resp=="a"){
        play=true;
        Console.Clear();
        Classes(Active, play);
    }
    else if(resp=="b"){
        Console.Clear();
        Rules(Active, play);
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
        Menu(Active, play);
    }
}


static void Classes(Character Active, bool play){
    string resp;
    Character Assasin=new("Assasin",25,6,4,16);
    Character Mage=new("Mage",30,7,5,11);
    Character Barbarian=new("Barbarian",50,4,3,13);
    Character Fighter=new("Fighter",40,5,3,14);

    Console.WriteLine("Choose your Class:");
    Console.WriteLine();
    Assasin.Stats();
    Console.WriteLine();
    Mage.Stats();
    Console.WriteLine();
    Barbarian.Stats();
    Console.WriteLine();
    Fighter.Stats();
    resp=Console.ReadLine().ToLower();

    if(resp=="assasin"){
        Active=Assasin;
    }
    else if(resp=="mage"){
        Active=Mage;
    }
    else if(resp=="barbarian"){
        Active=Barbarian;
    }
    else if(resp=="fighter"){
        Active=Fighter;
    }
    else{
        Console.Clear();
        Console.WriteLine("Not a valid response");
        Console.ReadLine();
        Console.Clear();
        Classes(Active, play);
    }
    Console.Clear();
    Console.WriteLine("Your character:");
    Active.Stats();
    Console.ReadLine();
    Console.Clear();
    Menu(Active, play);
}

static void Rules(Character Active, bool play){
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
    Menu(Active, play);
}

static void Store(){

}

static void Play(Character Active){ 

}