using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Strategy.Conceptual
{
    // El Contexto define la interfaz de interés para los clientes.
    class Context
    {
        // El Contexto mantiene una referencia a uno de los objetos Estrategia. El
        // Contexto no conoce la clase concreta de una estrategia. Debería
        // trabajar con todas las estrategias a través de la interfaz Estrategia.
        private IStrategy _strategy;

        public Context()
        { }

        // Por lo general, el Contexto acepta una estrategia a través del constructor, pero
        // también proporciona un setter para cambiarlo en tiempo de ejecución.
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Por lo general, el Contexto permite reemplazar un objeto Estrategia en tiempo de ejecución.
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // El Contexto delega algunos trabajos al objeto Estrategia en lugar de
        // implementar múltiples versiones del algoritmo por sí mismo.
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Ordenando datos usando la estrategia (no estoy seguro de cómo lo hará)");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    // La interfaz Estrategia declara operaciones comunes a todas las versiones soportadas
    // de algún algoritmo.
    //
    // El Contexto utiliza esta interfaz para llamar al algoritmo definido por Estrategias Concretas.
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }


    // Las Estrategias Concretas implementan el algoritmo siguiendo la interfaz base
    // Estrategia. La interfaz las hace intercambiables en el
    // Contexto.
    class ConcreteStrategyA : IStrategy


    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // El código del cliente elige una estrategia concreta y la pasa al
            // contexto. El cliente debe conocer las diferencias entre
            // estrategias para tomar la elección correcta.
            var context = new Context();

            Console.WriteLine("Cliente: La estrategia está configurada para ordenar normalmente.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Cliente: La estrategia está configurada para ordenar en reversa.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}