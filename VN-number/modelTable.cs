//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VN_number
{
    using System;
    using System.Collections.Generic;
    
    public partial class modelTable
    {
        public int id_model { get; set; }
        public string code { get; set; }
        public int id_firm { get; set; }
        public string decrypte { get; set; }
    
        public virtual firmTable firmTable { get; set; }
    }
}
