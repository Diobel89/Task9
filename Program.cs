using Task9;
using Task9.InputOutputSystem;
using Task9.InputOutputSystem.Interface;
using Task9.Validation.OnStart;

Console.WriteLine("Welcom in hellish task9 part2!");

IInput input = new Input();
IOutput output = new Output();
new OnStartValidation(output).CheckIsDatabaseExistent();
new OnStartValidation(output).Run();

new Menu(input, output).Show();

Console.WriteLine("The end.");