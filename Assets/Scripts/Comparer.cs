using System.Collections;

class Comparer : IComparer
{
    public int Compare(object y, object x)
    {
        return (new CaseInsensitiveComparer()).Compare(((Player)x).Score, ((Player)y).Score);

    }
}