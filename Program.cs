using Task9;
using Task9.InputOutputSystem;
using Task9.InputOutputSystem.Interface;
using Task9.OnStart;

Console.WriteLine("Welcom in hellish task9!");

IInput input = new Input();
IOutput output = new Output();
new OnStartValidation(output).CheckIsDatabaseExistent();
new OnStartValidation(output).Run();
new Menu(input, output).Show();