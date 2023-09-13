using Terminale;

int n = int.Parse(Console.ReadLine()); 
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    Terminal terminal = new Terminal();
    terminal.ProcessInput(input);
    terminal.PrintResult();
    if (i < n - 1)
    {
        Console.WriteLine("-");
    }
}
