using Task9;
using Task9.InputOutputSystem;
using Task9.InputOutputSystem.Interface;

Console.WriteLine("Welcom in hellish task9!");

IInput input = new Input();
IOutput output = new Output();
new Menu(input, output).Run();