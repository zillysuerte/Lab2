
namespace Lab2
{
    class Program
    {
        
        static void Main(string[] args)
        {
         
            EquationSolver equationSolver = new EquationSolver();

            try
            {
                int command = 0;
                do
                {
                    Console.WriteLine("Use one of commands:");
                    Console.WriteLine(" 1 - to select type of an equation and solve it");
                    Console.WriteLine(" 2 - to get existing solution from memory");
                    Console.WriteLine(" 3 - to exit");
                    command = int.Parse(Console.ReadLine());
                    if (command == 1)
                    {
                        Console.WriteLine("Select the type of equation:");
                        Console.WriteLine("1 - k * x + b = 0");
                        Console.WriteLine("2 - a * x^2 + b * x + c = 0");
                        try
                        {
                            var degree = int.Parse(Console.ReadLine());
                            if (degree == 1)
                            {
                                Console.WriteLine("Input the factors:");

                                try
                                {
                                    Console.Write("Factor 'k':");
                                    var k = double.Parse(Console.ReadLine());
                                    Console.Write("Free member 'b':");
                                    var b = double.Parse(Console.ReadLine());


                                    EquationMember bx = new EquationMember(b, 0);
                                    EquationMember kx = new EquationMember(k, 1);

                                    var parts = new EquationMember[] { bx, kx };

                                    Equation equation = new Equation(parts);
                                    Solution solution = equation.Result;

                                    equationSolver.Add(solution);
                                    Console.WriteLine(solution.ToString());

                                    ////////
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (degree == 2)
                            {
                                Console.WriteLine("Input the factors:");

                                try
                                {
                                    Console.Write("Factor 'a':");
                                    var a = double.Parse(Console.ReadLine());
                                    Console.Write("Factor 'b':");
                                    var b = double.Parse(Console.ReadLine());
                                    Console.Write("Factor 'c':");
                                    var c = double.Parse(Console.ReadLine());



                                    EquationMember cx = new EquationMember(c, 0);
                                    EquationMember bx = new EquationMember(b, 1);
                                    EquationMember ax = new EquationMember(a, 2);

                                    var parts = new EquationMember[] { cx, bx, ax };

                                    Equation equation = new Equation(parts);
                                    Solution solution = equation.Result;
                                    equationSolver.Add(solution);
                                    Console.WriteLine(solution.ToString());
                                    ////////
                                }
                                catch (FormatException ex)
                                {
                                    throw new Exception("factors need to be number");
                                }
                            }
                            else
                            {
                                throw new Exception("not expected variant of the equation (need 1 or 2)");
                            }
                        }
                        catch (FormatException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else if (command == 2)
                    {
                        Console.WriteLine("Input the index:");
                        try
                        {
                            var index = int.Parse(Console.ReadLine())-1;
                            if (index < 0 || index >= equationSolver.Size())
                            {
                                Console.WriteLine("not existing index");
                                ////??
                            }
                            else
                            {
                                Console.WriteLine("#" + (index+1) + " " + equationSolver.GetEquationAt(index).ToString());
                            }
                        }
                        catch (FormatException ex)
                        {
                            throw new Exception("index need to be int and > 0");
                        }
                    } else if (command == 3)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("not expected command (need 1,2 or 3)");
                    }
                } while ((command != 3));
            } catch (FormatException ex)
            {
                throw new Exception("not expected command (need 1,2 or 3)");
            }
        }
    }
}