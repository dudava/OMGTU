class Car
{
    public string name;

    public Car(string name)
    {
        this.name = name;
    }
}
class Garage
{
    List<Car> cars;

    public Garage(List<Car> cars)
    {
        this.cars = cars;
    }

    public delegate void CarWashDelegate(Car car);
    public void WashAllCars(CarWashDelegate washCar)
    {
        foreach (Car car in cars)
        {
            washCar(car);
        }
    }
}
class CarWasher
{
    public void WashCarInCarWasher(Car car)
    {
        Console.WriteLine("Машина \"{0}\" помыта", car.name);
    }
}
class Program
{
    
    public static void Main()
    {
        List<Car> cars = new List<Car>() { new Car("ВАЗ 2110"), new Car("Москвич 412"), new Car("УАЗ 3151"), new Car("ВАЗ 1111 Ока") };
        Garage garage = new Garage(cars);
        CarWasher carWasher = new CarWasher();
        garage.WashAllCars(carWasher.WashCarInCarWasher);
        Console.ReadKey();
    }
}