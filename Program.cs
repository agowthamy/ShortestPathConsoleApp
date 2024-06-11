// Program.cs
using ShortestRouteAPI.Models;
using ShortestRouteAPI.Services;

class Program
{
    static void Main(string[] args)
    {
        var shortestPathOptimizerService = new ShortestPathOptimizerService();

        var graphNodes = new List<Node>
        {
            new Node { Name = "A", Edges = { { "B", 1 }, { "C", 4 } } },
            new Node { Name = "B", Edges = { { "A", 1 }, { "F", 3 } } },
            new Node { Name = "C", Edges = { { "A", 6 }, { "D", 8 } } },
            new Node { Name = "D", Edges = { { "C", 8 }, { "E", 4 } } },
            new Node { Name = "E", Edges = { { "B", 2 }, { "F", 3 }, { "D", 4 } } },
            new Node { Name = "F", Edges = { { "B", 2 }, { "E", 3 } } }
        };

        DisplayGraphNodes(graphNodes);


        Console.WriteLine("Enter From Node:");
        var fromNode = Console.ReadLine().ToUpper();

        Console.WriteLine("Enter To Node:");
        var toNode = Console.ReadLine().ToUpper();

        var shortestPathData = shortestPathOptimizerService.ShortestPath(fromNode, toNode, graphNodes);

        if (shortestPathData != null)
        {
            Console.WriteLine($"Shortest path: {string.Join(", ", shortestPathData.NodeNames)}");
            Console.WriteLine($"Total distance: {shortestPathData.Distance}");
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }

    static void DisplayGraphNodes(List<Node> graphNodes)
    {
        Console.WriteLine("Graph Nodes and their Edges:");

        foreach (var node in graphNodes)
        {
            Console.Write($"Node {node.Name}: ");
            foreach (var edge in node.Edges)
            {
                Console.Write($"({edge.Key}, Distance: {edge.Value}) ");
            }
            Console.WriteLine();
        }
    }
}

