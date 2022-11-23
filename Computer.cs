//  ---------------------------------------------	
// Project: Computer Store
// © Oleksandr Shyryayev
// Written by: Oleksandr Shyryayev, 2210888
//  ---------------------------------------------	

public class Computer 
{
    private String brand;
    private String model;
    private static long snCount = 1_000_000;
    private long SN;
    private double price;
    private static int pcCount = 0;

    public Computer() {
        Console.WriteLine("The computer was created!");
        this.brand = "Apple";
        this.model = "MacBook Pro 2019";
        snCount++;
        this.SN = snCount;
        this.price = 2099.99;
        pcCount++;
    }

    public Computer (String _brand, String _model, long _sn, double _price){
        Console.WriteLine("The computer was created!");
        brand = _brand;
        model= _model;
        SN = _sn;
        price = _price;
        pcCount++;
    }

    public String getBrand() {
        return this.brand;
    }

    public void setBrand(String _brand) {
        this.brand = _brand;
    }

    public String getModel() {
        return this.model;
    }

    public void setModel(String _model) {
        this.model = _model;
    }

    public long getSN() {
        return this.SN;
    }

    public void setSN(long _sn) {
        if(_sn >= 1_000_000)
            this.SN = _sn;
        else
            Console.WriteLine("Serial Number (SN) must be at least seven intengers!");
    }

    public double getPrice() {
        return this.price;
    }

    public void setPrice (double _price) {
        if(_price >= 0)
            this.price = _price;
        else
            Console.WriteLine("Not valid amount!");
    }

    public void showComputer(){
        Console.WriteLine("Computer:");
        Console.WriteLine($"\tBrand: {this.brand}");
        Console.WriteLine($"\tModel: {this.model}");
        Console.WriteLine($"\tSN:    {this.SN}");
        Console.WriteLine($"\tPrice: ${this.price}");
        Console.WriteLine("-------------------------------");
    }

    public static int findNumberOfCreatedComputers() {
        return pcCount;
    }

    public bool equels(Computer c1){
        if (this.brand == c1.getBrand() &&
            this.model == c1.getModel() &&
            this.SN == c1.getSN() &&
            this.price == c1.getPrice()){
            return true;
        }else {
            return false;
        }
    }

}