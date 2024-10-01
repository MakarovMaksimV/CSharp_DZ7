using System.Threading.Tasks;

namespace DZ7;

class Program
{
    static void Main(string[] args)
    {
        Task testClass = new Task();

        var ts = testClass.Run3(1, "sdvf", 3, new char[] { 'd', 'f' });

        string str = Task.ObjectToString(ts);
        Console.WriteLine(str);

        object ob = Task.StringToObject(str);



        Console.ReadKey();
    }
}

