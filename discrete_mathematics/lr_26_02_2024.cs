static List<int> FindCommVertices(int vert, List<int[]> ribs)
{
    List<int> verts = new List<int>();
    foreach (int[] rib in ribs)
    {
        if (vert == rib[0]) verts.Add(rib[1]);
        else if (vert == rib[1]) verts.Add(rib[0]);
    }
    return verts;
}

static List<int> BuildComponent(int cur_vert, List<int[]> ribs, List<int> component)
{
    List<int> verts = FindCommVertices(cur_vert, ribs);
    foreach (int vert in verts)
    {
        if (!component.Contains(vert))
        {
            component.Add(vert);
        }
        else
        {
            continue;
        }
        BuildComponent(vert, ribs, component);
    }
    return component;
}

static List<int> DiffLists(List<int> listToRemove, List<int> removeElements)
{
    List<int> diffList = new List<int>(listToRemove);
    foreach (int el in removeElements)
    {
        diffList.Remove(el);
    }
    return diffList;
}


List<int[]> ribs = new List<int[]>();
List<int> vertices = new List<int>();
while (true)
{
    string input = Console.ReadLine();
    if (input == "END")
    {
        break;
    }
    string[] str_ribs = input.Split(' ');
    int[] rib = Array.ConvertAll(str_ribs, int.Parse);
    ribs.Add(rib);
    if (!vertices.Contains(rib[0])) vertices.Add(rib[0]);
    if (!vertices.Contains(rib[1])) vertices.Add(rib[1]);
}
List<List<int>> components = new List<List<int>>();
while (vertices.Count > 0)
{
    int vert = vertices[0];
    List<int> component = BuildComponent(vert, ribs, new List<int>() { vert });
    components.Add(component);
    vertices = DiffLists(vertices, component);
}
Console.WriteLine("Компонент связности {0}:", components.Count);
foreach (List<int> component in components)
{
    Console.WriteLine(String.Join(" ", component));
}
