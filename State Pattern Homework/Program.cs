namespace State_Pattern_Homework;

interface IState { // State changes when Do function called
    void Do(IDevice device);
}

// This interface is not about State Pattern it is additional principe for open closed principle
interface IDevice {
    public IState State { get; set; }
    void PowerButton();
}

class Computer : IDevice {

    public IState State { get; set; }

    public Computer() {
        State = new OffState();
    }
    public void PowerButton() 
        => State.Do(this);
}

class OffState : IState {
    public void Do(IDevice device) {
        Console.WriteLine("Cihaz açıldı");
        device.State = new OnState();
    }
}

class OnState : IState { 
    public void Do(IDevice device) {
        Console.WriteLine("Cihaz bağlandı");
        device.State = new OffState();
    }
}

internal class Program {
    static void Main(string[] args) { 
        IDevice device = new Computer();
        device.PowerButton();
        device.PowerButton();
        device.PowerButton();
        device.PowerButton();

    }
}