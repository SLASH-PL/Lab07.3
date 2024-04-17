using System.Drawing;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

class Program
{
    public static void Main(string[] args)
    {
        
    }

    public static void ListDemo()
    {
        string[] students = { "Beata", "Stefan" };
        IList<string> names = new List<string>(students)
        {
            "Adam",
            "Dupa",
            "Mati",
            "Dominik",
            "Hubert"
        };
        Console.WriteLine(String.Join(", ", names));
        Console.WriteLine(names[0]);
        Console.WriteLine(names[^2]);
        names[0] = "Alicja";
        names.Add("Zenek");
        Console.WriteLine(String.Join(", ", names));
        names.Insert(1,"Drugi");
        Console.WriteLine(String.Join(", ", names));
        names.RemoveAt(3);
        Console.WriteLine(String.Join(", ", names));
        Console.WriteLine(String.Join(", ", names));
        MoveEndToFirst(names);
        Console.WriteLine(String.Join(", ", names));
        Console.WriteLine(names.Contains("Alicja")); //wartosć > -1 znaleziono
        Console.WriteLine(names.IndexOf("Zuza")); // wartość < 0 brak elementu w liście
    }

    public static void MoveEndToFirst(IList<string> list)
    {

        if (list.Count < 2)
        {
            return;
        }
        list.Insert(0, list[^1]);
        list.RemoveAt(list.Count - 1);

    }

    public static void LinkedListDemo()
    {
        LinkedList<int> numbers = new LinkedList<int>();
        numbers.AddLast(1);
        numbers.AddFirst(5);
        numbers.AddLast(3);
        numbers.AddLast(7);
        Console.WriteLine(string.Join(",", numbers));
        var node = numbers.Find(3);
        Console.WriteLine(node.Value);
        Console.WriteLine(node.Next.Value);
        Console.WriteLine(node.Previous.Value);
        numbers.AddAfter(node, new LinkedListNode<int>(11));
        Console.WriteLine(string.Join(",", numbers));



    }

    public static void SetDemo()
    {
        ISet<string> set = new HashSet<string>()
        {
            "A", "B", "C", "A", "B", "F", "G"
        };
        Console.WriteLine(string.Join(",", set));

        int[] arr = { 1, 3, 2, 1, 4, 2, 4, 2, 1, 2, 3, };
        int[] arr2 = { 4, 4, 5, 6, 7, 2, 1 };
        Console.WriteLine(String.Join(", ", new HashSet<int>(arr)));
        var setArr = new HashSet<int>(arr);
        var setArr2 = new HashSet<int>(arr2);
        setArr.IntersectWith(setArr2);
        Console.WriteLine(String.Join(", ", new HashSet<int>(arr)));
        Console.WriteLine(setArr.Contains(9));
        setArr = new HashSet<int>(arr);
        setArr.ExceptWith(setArr2);
        Console.WriteLine("Różnice zbiorów liczb z tablic arr i arr2");
        Console.WriteLine(String.Join(", ", new HashSet<int>(arr)));
    }

    public static void PlayerSetDemo()
    {
        var players = new HashSet<Player>()
        {
            new Player() { Id = 1, Name = "Adam", Points = 123 },
            new Player() { Id = 2, Name = "Ewa", Points = 12 },
            new Player() { Id = 3, Name = "Kuba", Points = 45 },
            new Player() { Id = 3, Name = "Kuba", Points = 45 },
        };
        Console.WriteLine(String.Join(", ", players));

        
    }

}

class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }

    protected bool Equals(Player other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        Console.WriteLine("Calling Equals");
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Player)obj);
    }

    public override int GetHashCode()
    {
        Console.WriteLine("Calling HashCode");
        return Id;
    }


    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Points)}: {Points}";
    }
}

