using System.Collections;
string[] people = { "Tom", "Sam", "Bob" };
IEnumerator enumerator = people.GetEnumerator();
while (enumerator.MoveNext())
{
    string item=(string) enumerator.Current;
    Console.WriteLine(item);
}
enumerator.Reset();


RoleEnum re = new RoleEnum();
foreach (var item in re)
{
    Console.WriteLine($"{item.RoleName}");
}

Week week = new Week();
foreach (var item in week)
{
    Console.WriteLine(item);
}
Numbers numbers=new Numbers();
foreach (var item in numbers)
{
    Console.WriteLine(item);
}
class Numbers
{
    public IEnumerator<int> GetEnumerator()
    {
        for(int i=0;i<6;i++)
        {
            yield return i*i;
        }
    }
}
class Week:IEnumerable
{
    string[] days = { "Sunday", "Monday", "Tuesday", "Furthday", "Friday", "Saturday" };

    public IEnumerator GetEnumerator()
    {
        return days.GetEnumerator();
    }
}

public class Role
{
    public string RoleName { get; set; }
}
public class RoleList : IEnumerator<Role>
{
    private List<Role> roles = new List<Role>()
    {
        new Role(){RoleName="role1"},
        new Role(){RoleName="role2"},
        new Role(){RoleName="role3"},
        new Role(){RoleName="role4"},
        new Role(){RoleName="role5"},
        new Role(){RoleName="role6"}
    };
    private int currentIndex = -1;
    public Role Current
    {
        get { return roles[currentIndex]; }
    }

    object IEnumerator.Current => throw new NotImplementedException();

    public void Dispose()
    {
        roles.Clear();
    }

    public bool MoveNext()
    {
        if(currentIndex+1==roles.Count)
        {
            Reset();
            return false;
        }
        currentIndex++;
        return true;
    }

    public void Reset()
    {
        currentIndex = -1;
    }
}

public class RoleEnum:IEnumerable<Role>
{
    RoleList rl=new RoleList();

    public IEnumerator<Role> GetEnumerator()
    {
        return rl;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}