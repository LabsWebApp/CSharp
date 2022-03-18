// Анонимные (лямбда) методы.


Delegate simpleDelegate = delegate(int a, double b) { return a + b;};
    

Console.WriteLine(simpleDelegate(1, 2));

simpleDelegate = (a, b) =>
{
    return a + b;
};

simpleDelegate -= (a, b) =>
{
    return a + b;
};


int summand1 = 1;
double summand2 = 2.5, sum = 0;

sum = simpleDelegate(summand1, summand2);

Console.WriteLine($"{summand1} + {summand2} = {sum}");

// Delay.
Console.ReadKey();


// Создаем класс делегата.
delegate double Delegate(int a, double b);