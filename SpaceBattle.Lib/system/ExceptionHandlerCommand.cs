namespace SpaceBattle.Lib;
using Hwdtech;
using Hwdtech.Ioc;


public class HandlerCommand : ICommand
{
    public string ex;

    public HandlerCommand(string ex)
    {
        this.ex = ex;
    }

    public void Execute()
    {
        StreamWriter sw = new StreamWriter("Exceptions.txt");
        sw.WriteLine(ex);
        sw.Close();
    }
}
