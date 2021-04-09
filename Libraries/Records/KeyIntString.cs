using System;
using System.Collections.Generic;
using System.Text;

namespace Records
{
    
    public class KeyIntString : IEquatable<KeyIntString>
    {
        //private int id;

        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        public int Id { get; }
        public string Str { get; }

        public KeyIntString(int id, string str)
        {
            Id = id;
            Str = str;
        }

        public bool Equals(KeyIntString other)
        {
            throw new NotImplementedException();
        }
    }
}
