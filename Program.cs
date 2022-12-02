 //  ---------------------------------------------	
// Project: Computer Store
// © Oleksandr Shyryayev
// Written by: Oleksandr Shyryayev, 2210888
//  ---------------------------------------------	

class Program {
    static int pcCount = Computer.findNumberOfCreatedComputers();
    static int storeCapacity;

    public static int findStoreCapacity() {
        return storeCapacity;
    }

    public static void newComputer(Computer[] arr) {
        string password, brand, model;
        char option;
        int tries = 3, pcNum;
        long sn;
        double price;
        bool exit = false, exit2 = false;

        do {
            Console.Write("Enter password: ");
            password = Console.ReadLine() ?? string.Empty;
            if(password.ToLower() == "password"){
                Console.WriteLine("Access Granted!");
                do {
                    if(storeCapacity > 0){
                        Console.WriteLine($"\nYou can create {storeCapacity} computer(s)");
                    }else {
                        Console.WriteLine($"Store've reached maximum capacity!");
                        break;
                    } 
                    do {                        
                        Console.Write("How many computers would you like to enter?: ");
                        if (!Int32.TryParse(Console.ReadLine(), out pcNum) || pcNum < 0) {
                            Console.WriteLine("Invalid input!");
                        }else{
                            exit = true;
                        }     
                    }while(!exit);
                    if(pcNum <= storeCapacity){
                        for (int i = 0; i < pcNum; i++){
                            Console.Write("Do you want to create default computer (y/n)?: ");
                            option = Convert.ToChar(Console.ReadLine() ?? string.Empty);
                            if(option == 'y' || option == 'Y'){                         
                                arr[pcCount] = new Computer();                                
                                Console.Write($"{pcCount + 1}. ");
                                arr[pcCount].showComputer();
                                pcCount++;
                                storeCapacity--;
                            }else if(option == 'n' || option == 'N'){
                                Console.Write("Brand: ");
                                brand = Console.ReadLine() ?? string.Empty;

                                Console.Write("Model: ");
                                model = Console.ReadLine() ?? string.Empty;
                                
                                do{
                                    Console.Write("Serial Number: ");
                                    if (!Int64.TryParse(Console.ReadLine(), out sn)) {
                                        Console.WriteLine("Invalid input!");
                                    }
                                }while(sn < 1_000_000);

                                do{
                                    Console.Write("Price: $");
                                    if (!Double.TryParse(Console.ReadLine(), out price) || price < 0) {
                                        Console.WriteLine("Invalid input!");
                                    }else {
                                        exit2 = true;
                                    }
                                }while(!exit2);

                                arr[pcCount] = new Computer(brand, model, sn, price);
                                Console.Write($"{i + 1}. ");
                                arr[pcCount].showComputer();
                                pcCount++;
                                storeCapacity--;
                            }else {
                                Console.WriteLine("Wrong input!");
                                i--;
                            }
                        }
                        break;
                    }else {
                        Console.WriteLine($"Only {findStoreCapacity()} computers can be made!\n");
                    }
                } while(pcNum > storeCapacity);
                break;
            }else {
                tries--;
                if(tries == 2) {
                    Console.WriteLine($"{tries} tries left");
                }else if(tries == 1) {
                    Console.WriteLine($"{tries} try left");
                }else {
                    Console.WriteLine("Access Denied!");
                }
            }            
        } while(tries >= 1);
    }


    public static void changePcInfo(Computer[] arr) {
        string password, brand, model;
        int tries = 3, num;
        char option;
        long sn;
        double price;
        bool exit = false, exit2 = false, exit3 = false;

        do {
            Console.Write("Enter password: ");
            password = Console.ReadLine() ?? string.Empty;
            if(password.ToLower() == "password"){
                Console.WriteLine("Access Granted!");
                Console.WriteLine($"\nYou have {Computer.findNumberOfCreatedComputers()} computers in Store:");
                for (int i = 0; i < arr.Length; i++){
                    if(arr[i] != null){
                        Console.Write($"{i + 1}. ");
                        arr[i].showComputer();
                    }
                }
                if(arr[0] != null){
                    do {
                        Console.WriteLine();
                        do {                       
                            Console.Write("Computer to change: ");
                            if (!Int32.TryParse(Console.ReadLine(), out num)) {
                                Console.WriteLine("Invalid input!");
                            }else{
                                exit = true;
                            }     
                        }while(!exit);
                        if(num <= Computer.findNumberOfCreatedComputers() && num > 0){
                            do {
                                Console.WriteLine();
                                Console.WriteLine(" -----------------------------------------------");
                                Console.WriteLine("|  What information would you like to change?   |");
                                Console.WriteLine("|\t1. Brand                                |");
                                Console.WriteLine("|\t2. Model                                |");
                                Console.WriteLine("|\t3. Serial Number                        |");
                                Console.WriteLine("|\t4. Price                                |");
                                Console.WriteLine("|\t5. Quit                                 |");
                                Console.WriteLine(" -----------------------------------------------");
                                do {                       
                                    Console.Write("Please enter your choice: ");
                                    if (!Char.TryParse(Console.ReadLine(), out option)) {
                                        Console.WriteLine("Invalid input!");
                                    }else{
                                        exit2 = true;
                                    }     
                                }while(!exit2);

                                switch(option){
                                case '1':
                                    Console.Write("New Brand: ");
                                    brand = Console.ReadLine() ?? string.Empty;
                                    arr[num - 1].setBrand(brand);
                                    arr[num - 1].showComputer();
                                    break;

                                case '2':
                                    Console.Write("New Model: ");
                                    model = Console.ReadLine() ?? string.Empty;
                                    arr[num - 1].setModel(model);
                                    arr[num - 1].showComputer();
                                    break;

                                case '3':
                                    do{
                                        Console.Write("New Serial Number: ");
                                        if (!Int64.TryParse(Console.ReadLine(), out sn) || sn <= 0) {
                                            Console.WriteLine("Invalid input!");
                                        }else{
                                            arr[num - 1].setSN(sn);
                                        }
                                    }while(sn < 1_000_000);
                                    arr[num - 1].showComputer();
                                    break;

                                case '4':
                                    do{
                                        Console.Write("New Price: $");
                                        if (!Double.TryParse(Console.ReadLine(), out price) || price < 0) {
                                            Console.WriteLine("Invalid input!");
                                        }else{
                                            arr[num - 1].setPrice(price);
                                            exit3 = true;
                                        }
                                    }while(!exit3);
                                    arr[num - 1].showComputer();
                                    break;

                                case '5':
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("\nError: Invalid choise...");
                                    break;
                                }
                            } while(option != '5');
                            Console.Write($"{num}. ");
                            arr[num - 1].showComputer();
                        }else {
                            Console.Write("Would you like to quit? (y/n): ");
                            char opt = Convert.ToChar(Console.ReadLine() ?? string.Empty);
                            if(opt == 'y' || opt == 'Y') {
                                break;
                            }else {
                                num = - 1;
                            }
                        }
                    } while(num > Computer.findNumberOfCreatedComputers() || num <= 0);
                }else {
                    Console.WriteLine("Nothing to change!");
                }
                break;
            }else{
                tries--;
                if(tries == 2) {
                    Console.WriteLine($"{tries} tries left");
                }else if(tries == 1) {
                    Console.WriteLine($"{tries} try left");
                }else {
                    Console.WriteLine("Access Denied!");
                }
            }
        } while(tries >= 1);        
    }


    public static void findComputersByBrand(Computer[] arr) {
        string brand;
        int flag = arr.Length;

        Console.Write("Enter brand: ");
        brand = Console.ReadLine() ?? string.Empty;
        for (int i = 0; i < arr.Length; i++) {
            if(arr[i] != null) {
                if(brand.ToLower() == arr[i].getBrand().ToLower()) {
                    Console.Write($"{i + 1}. ");
                    arr[i].showComputer();
                    flag--;
                }
            }else if (Computer.findNumberOfCreatedComputers() == 0) {
                Console.WriteLine("Computer with this brand doesn't exist in the store!");
                Console.WriteLine("There are no computers in store!");
                break;
            }
        }
        if(Computer.findNumberOfCreatedComputers() != 0 && flag == arr.Length) {
            Console.WriteLine("There are no computers with this brand in the store!");
        }
    }


    public static void findCheaperThan(Computer[] arr) {
        double price;
        bool exit = false;
        int flag = arr.Length;

            do {                       
                Console.Write("Enter price: $");
                if (!Double.TryParse(Console.ReadLine(), out price) || price < 0) {
                    Console.WriteLine("Invalid input!");
                }else {
                    for (int i = 0; i < arr.Length; i++) {
                        if(arr[i] != null) {
                            if(price >= arr[i].getPrice()) {
                                Console.Write($"{i + 1}. ");
                                arr[i].showComputer();
                                flag--;
                                exit = true;
                            }
                        }else if (Computer.findNumberOfCreatedComputers() == 0){
                            Console.WriteLine("No computers to show!");
                            Console.WriteLine("There are no computers in store!");
                            exit = true;
                            break;                    
                        }
                    }
                    if(Computer.findNumberOfCreatedComputers() != 0 && flag == arr.Length) {
                        Console.WriteLine("No computers to show!");
                        exit = true;
                    }
                }
            }while(!exit);           
    }


    public static void writeReadFile(Computer[] arr){
        string computerList = "computerList.txt";
        try {  
            using (StreamWriter textList = new StreamWriter(computerList)) {
                textList.WriteLine("List of PC(s) in 'Super-Duper Computers' store:\n");
                for (int i = 0; i < arr.Length; i++) {            
                    if(arr[i] != null){
                        textList.WriteLine("-------------------------------");
                        textList.WriteLine($"{i + 1}. Computer:");
                        textList.WriteLine($"\t\tBrand: {arr[i].getBrand()}");
                        textList.WriteLine($"\t\tModel: {arr[i].getModel()}");
                        textList.WriteLine($"\t\tSN:    {arr[i].getSN()}");
                        textList.WriteLine($"\t\tPrice: ${arr[i].getPrice()}");
                    }
                }
            }  
        } catch(Exception exp) {  
            Console.Write(exp.Message);  
        }

        string[] textFile = System.IO.File.ReadAllLines("computerList.txt");
        System.Console.WriteLine("\nContents of computerList.txt file:");
        foreach (string line in textFile) {
            Console.WriteLine("\t" + line);
        }
    }


    static void Main(string[] args) {
        char option;
        bool exit = false, exit2 = false;

        Console.WriteLine("Welcome to 'Super-Duper Computers'!");       
        do{
            Console.Write($"What is maximum Store Capacity today?: ");
            if (!Int32.TryParse(Console.ReadLine(), out storeCapacity) || storeCapacity <= 0) {
                Console.WriteLine("Invalid input!");
            }else{
                exit = true;
            }
        }while(!exit);

        Computer[] inventory = new Computer[storeCapacity];
        Console.WriteLine($"\nMaximum Store Capacity is {storeCapacity} PC today");
        do {
            Console.WriteLine(" -----------------------------------------------------------------");
            Console.WriteLine("|  What do you want to do?                                        |");
            Console.WriteLine("|\t1. Enter new computers (password required)                |");
            Console.WriteLine("|\t2. Change information of a computer (password required)   |");
            Console.WriteLine("|\t3. Display all computers by a specific brand              |");
            Console.WriteLine("|\t4. Display all computers under a certain a price          |");
            Console.WriteLine("|\t5. Quit                                                   |");
            Console.WriteLine(" -----------------------------------------------------------------");
            do {                       
                Console.Write("Please enter your choice: ");
                if (!Char.TryParse(Console.ReadLine(), out option)) {
                    Console.WriteLine("Invalid input!");
                }else{
                    exit2 = true;
                }     
            }while(!exit2);

            switch(option){
            case '1':
                Console.Clear();
                newComputer(inventory);
                Console.WriteLine();
                break;

            case '2':
                Console.Clear();
                changePcInfo(inventory);
                Console.WriteLine();
                break;

            case '3':
                Console.Clear();
                findComputersByBrand(inventory);
                Console.WriteLine();
                break;

            case '4':
                Console.Clear();
                findCheaperThan(inventory);
                Console.WriteLine();
                break;

            case '5':
                Console.Clear();                
                Console.WriteLine("Good bye!");
                Console.WriteLine("Exiting program...");
                writeReadFile(inventory);
                break;

            default:
                Console.Clear();  
                Console.WriteLine("\nError: Invalid choise...");
                break;
            }

        } while(option != '5');
    }
}