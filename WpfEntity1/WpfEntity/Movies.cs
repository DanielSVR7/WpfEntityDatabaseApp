//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movies
    {
        public int id { get; set; }
        public string Название { get; set; }
        public Nullable<int> Год { get; set; }
        public int Жанр { get; set; }
        public override string ToString()
        {
            return Название;
        }
    }

}
