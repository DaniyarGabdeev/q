//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp5
{
    using System;
    using System.Collections.Generic;
    
    public partial class zakaz
    {
        public int id_zakaz { get; set; }
        public string title { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> id_sotrudnic { get; set; }
    
        public virtual sotrudnic sotrudnic { get; set; }
    }
}
