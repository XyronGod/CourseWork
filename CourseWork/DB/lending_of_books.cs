//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class lending_of_books
    {
        public int IDLending { get; set; }
        public string Reader { get; set; }
        public int Book { get; set; }
        public System.DateTime DateOfIssue { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public string Employee { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
