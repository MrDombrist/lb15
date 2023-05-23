using lb15;

Map<int,string> a = new Map<int, string>(5);
string s = Console.ReadLine();
string[] str = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < str.Length; i++)
{
    a.Add(Convert.ToInt32(str[i]), str[i]);
}
Console.WriteLine(a.ToString());